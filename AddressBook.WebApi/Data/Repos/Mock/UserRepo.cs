using AddressBook.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
                    Password = "P@ssw0rd123"
                }
            };
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            // Fetch user details
            User user = this._users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return await Task.FromResult(false);

            // Encrypt incoming password
            string encryptedPassword = password;

            // Compare with encrypted password
            return await Task.FromResult(password == encryptedPassword);
        }

        public async Task<User> GetDetails(string username) =>
            await Task.FromResult(this._users.FirstOrDefault(u => u.Username == username));
    }
}
