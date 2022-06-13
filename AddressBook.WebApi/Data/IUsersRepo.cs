using AddressBook.WebApi.Data.Entities;
using System.Threading.Tasks;

namespace AddressBook.WebApi.Data
{
    public interface IUsersRepo
    {
        Task<User> Authenticate(string username, string password);

        Task<User> GetDetails(string username);
    }
}
