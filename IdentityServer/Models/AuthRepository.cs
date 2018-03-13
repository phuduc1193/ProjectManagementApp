using BusinessModel.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AuthRepository : IAuthRepository
    {
        private IdentityDbContext db;

        public AuthRepository(IdentityDbContext context)
        {
            db = context;
        }

        public User GetUserById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;
            var user = db.Users.Where(u => u.Id == Convert.ToInt32(id)).FirstOrDefault();
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = db.Users.Where(u => String.Equals(u.Username, username)).FirstOrDefault();
            return user;
        }

        public bool ValidatePassword(string username, string plainTextPassword)
        {
            var user = db.UserCredentials.Where(u => String.Equals(u.Username, username)).FirstOrDefault();
            if (user == null) return false;
            if (String.Equals(plainTextPassword, user.Password)) return true;
            return false;
        }
    }
}
