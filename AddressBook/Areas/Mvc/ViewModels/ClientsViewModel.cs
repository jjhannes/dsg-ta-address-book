using AddressBook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Areas.Mvc.ViewModels
{
    public class ClientsViewModel
    {
        public IEnumerable<Client> Clients { get; set; }

        public string Query { get; set; }
    }
}
