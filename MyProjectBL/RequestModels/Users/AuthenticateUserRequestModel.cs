using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using MyProjectBL.ResponseModels;

namespace MyProjectBL.RequestModels
{
    public class AuthenticateUserRequestModel : IRequest<AuthenticateUserResponseModel>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
