using System;
using MyProjectBL.Models;
using MyProjectDL.Entities;

namespace MyProjectBL.ResponseModels
{
    public class AuthenticateUserResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public string Role { get; set; }
    }
}
