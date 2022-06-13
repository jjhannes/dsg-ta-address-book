using AddressBook.Data.Entities;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    public interface IUsersRepo
    {
        Task<User> Authenticate(string username, string password);

        Task<User> GetById(int id);
    }
}
