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

namespace MyProjectBL.Handlers.QueryHandlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersRequestModel, GetUsersResponseModel>
    {
        private IUserDBService _userDBService;
        public GetUsersQueryHandler(IUserDBService userDBService)
        {
            _userDBService = userDBService;
        }
        public async Task<GetUsersResponseModel> Handle(GetUsersRequestModel request, CancellationToken cancellationToken)
        {
            var response = new GetUsersResponseModel();

            response.Users = _userDBService.GetAllUsers().Select(p => new UserModel()
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Id = p.Id,
                Username = p.Username
            }).ToList();

            return response;
        }
    }

}
