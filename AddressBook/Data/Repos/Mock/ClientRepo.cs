using AddressBook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data.Repos.Mock
{
    public class ClientRepo : IClientRepo
    {
        private List<Client> _clients;

        public ClientRepo()
        {
            this._clients = StaticData.Clients;
        }

        public async Task<IEnumerable<Client>> GetAll() =>
            await Task.FromResult(this._clients);

        public async Task<Client> GetByEmail(string email) =>
            await Task.FromResult(this._clients.FirstOrDefault(c => c.Email == email));

        public async Task<Client> GetById(int id) =>
            await Task.FromResult(this._clients.FirstOrDefault(c => c.Id == id));

        public async Task<bool> SaveChanges() =>
            await Task.FromResult(true);

        public Task<Client> Create(Client client)
        {
            int lastId = this._clients
                .OrderBy(c => c.Id)
                .Last()
                .Id;

            client.Id = lastId + 1;

            this._clients.Add(client);

            return Task.FromResult(client);
        }

        public async Task Remove(Client client)
        {
            await Task.Run(() => this._clients.Remove(client));
        }
    }
}
