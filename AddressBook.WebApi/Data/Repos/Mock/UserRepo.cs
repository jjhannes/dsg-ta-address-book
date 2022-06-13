using AddressBook.WebApi.Data.Entities;
using AddressBook.WebApi.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.WebApi.Data.Repos.Mock
{
    public class UserRepo : IUsersRepo
    {
        private readonly List<User> _users;

        public UserRepo()
        {
            this._users = new List<User>
            {
                new User
                {
                    Username = "jj.hannes.swanepoel@gmail.com",
                    FirstName = "Hannes",
                    LastName = "Swanepoel",
                    Password = "P@ssw0rd123"
                }
            };
        }

#nullable enable
        public async Task<User?> Authenticate(string username, string password)
        {
            // Fetch user details
            User? user = this._users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return await Task.FromResult<User?>(null);

            // Compare with encrypted password
            if (password == user.Password)
            {
                return await Task.FromResult(user);
            }
            else
                return await Task.FromResult<User?>(null);
        }
#nullable disable

        public async Task<User> GetById(int id) =>
            await Task.FromResult(this._users.FirstOrDefault(u => u.Id == id));
    }
}
