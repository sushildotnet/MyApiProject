using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyProjectBL.Models;
using MyProjectBL.RequestModels;
using MyProjectBL.ResponseModels;
using MyProjectDL;
using MyProjectDL.Interfaces;
using MediatR;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using MyProjectDL.Entities;

namespace MyProjectBL.Handlers.QueryHandlers
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserRequestModel, AuthenticateUserResponseModel>
    {
        //TODO: read from configuration file
        public string ClientSecret { get; set; } = "this is my custom Secret key for authnetication";

        private IUserDBService _userDBService;
        private readonly AppSettings _appSettings;
        public AuthenticateUserQueryHandler(IUserDBService userDBService, IOptions<AppSettings> appSettings)
        {
            _userDBService = userDBService;
            _appSettings = appSettings.Value;
        }
        public async Task<AuthenticateUserResponseModel> Handle(AuthenticateUserRequestModel request, CancellationToken cancellationToken)
        {
            var response = new AuthenticateUserResponseModel();

            var user = _userDBService.AuthenticateUser(request.Username, request.Password);

            // return null if user not found
            if (user == null) return null;
            response = new AuthenticateUserResponseModel()
            {
                FirstName = user.FirstName,
                IsAdmin = user.IsAdmin,
                Role = user.IsAdmin ? Role.Admin : Role.User,
                Id = user.Id,
                LastName = user.LastName,
                Username = user.Username,
                Token = user.Id > 0 ? generateJwtToken(user) : ""
            };

            return response;

        }


        /// <summary>
        /// generate token that is valid for 7 days
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? Role.Admin : Role.User)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
