using AddressBook.WebApi.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.WebApi.Data
{
    public interface IClientRepo
    {
        Task<IEnumerable<Client>> GetAll();
        
        Task<Client> GetById(int id);

        Task<Client> GetByEmail(string id);

        Task<bool> SaveChanges();
    }
}
