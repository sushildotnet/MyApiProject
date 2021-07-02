using System;
using System.Collections.Generic;
using MyProjectBL.Models;

namespace MyProjectBL.ResponseModels
{
    public class GetUsersResponseModel
    {
        public List<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
