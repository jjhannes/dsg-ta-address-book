using AddressBook.Data;
using AddressBook.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Areas.Mvc.Controllers
{
    [Area("Mvc")]
    public class ClientDetailsController : Controller
    {
        private readonly IClientRepo _clientRepo;

        public ClientDetailsController(IClientRepo clientRepo)
        {
            this._clientRepo = clientRepo;
        }

        public async Task<ViewResult> Index(int id)
        {
            Client client = await this._clientRepo.GetById(id);

            return View(client);
        }
    }
}
