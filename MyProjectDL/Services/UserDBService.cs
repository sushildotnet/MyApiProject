using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProjectDL.Entities;
using MyProjectDL.Interfaces;

namespace MyProjectDL.Services
{
    public class UserDBService : IUserDBService
    {
        private readonly MyProjectDbContext _context;
        public static bool contextInUse { get; set; }

        public UserDBService(MyProjectDbContext context)
        {
            _context = context;
        }

        public User AuthenticateUser(string userName, string password)
        {
            var usr = _context.Users.Where(u => u.Username == userName && u.Password == password)
                .SingleOrDefault();
            return usr;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var prd = _context.Users.Find(id);
            _context.Users.Remove(prd);
            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var usrs = _context.Users.ToList();
            return usrs;
        }

        public User GetUserById(int id)
        {
            var usr = _context.Users.Find(id);
            return usr;
        }

        public async Task<int> SaveUser(User user)
        {
            contextInUse = true;
            var prd = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Password = user.Password,
                Username = user.Username
            };
            _context.Users.Add(prd);
            await _context.SaveChangesAsync();

            contextInUse = false;
            return prd.Id;
        }

        public async Task<bool> UpdateUser(User user)
        {
            if (!contextInUse)
            {
                var usr = _context.Users.Find(user.Id);

                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                usr.Password = user.Password;
                usr.Username = user.Username;

                var rows = await _context.SaveChangesAsync();

                return rows > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
