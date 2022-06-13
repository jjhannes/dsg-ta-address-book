using AddressBook.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.WebApi.Data.Repos.Mock
{
    public class ClientRepo : IClientRepo
    {
        private readonly List<Client> _clients;

        public ClientRepo()
        {
            this._clients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    Name = "Jack",
                    Surname = "Sparrow",
                    Company = "Black Pearl",
                    ContactNumber = "0105555225",
                    Email = "jack.sparrow@black-pearl.ss",
                    Created = new DateTime(1860, 5, 13)
                },
                new Client
                {
                    Id = 1,
                    Name = "Mike",
                    Surname = "Tyson",
                    Company = "Pro Boxing",
                    ContactNumber = "0105556453",
                    Email = "mike.tyson@pro-box.usa",
                    Created = new DateTime(1966, 6, 30)
                }
            };
        }

        public async Task<IEnumerable<Client>> GetAll() => 
            await Task.FromResult(this._clients);

        public async Task<Client> GetByEmail(string email) =>
            await Task.FromResult(this._clients.FirstOrDefault(c => c.Email == email));

        public async Task<Client> GetById(int id) => 
            await Task.FromResult(this._clients.FirstOrDefault(c => c.Id == id));

        public async Task<bool> SaveChanges() => 
            await Task.FromResult(true);
    }
}
