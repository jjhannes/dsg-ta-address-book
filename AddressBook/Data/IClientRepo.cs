using AddressBook.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    public interface IClientRepo
    {
        Task<IEnumerable<Client>> GetAll();
        
        Task<Client> GetById(int id);

        Task<Client> GetByEmail(string id);

        Task<Client> Create(Client client);

        Task Remove(Client client);

        Task<bool> SaveChanges();
    }
}
