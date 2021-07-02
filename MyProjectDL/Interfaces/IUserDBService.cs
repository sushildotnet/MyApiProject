using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProjectDL.Entities;

namespace MyProjectDL.Interfaces
{
    public interface IUserDBService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        Task<int> SaveUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        User AuthenticateUser(string userName, string password);
    }
}
