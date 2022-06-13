using AddressBook.Data;
using AddressBook.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Areas.Mvc.Controllers
{
    [Area("Mvc")]
    public class ClientListController : Controller
    {
        private readonly IClientRepo _clientRepo;

        public ClientListController(IClientRepo clientRepo)
        {
            this._clientRepo = clientRepo;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Client> clients = await this._clientRepo.GetAll();

            return View(clients.OrderBy(c => c.Name));
        }

        public async Task<RedirectToActionResult> Delete(int id)
        {
            try
            {
                Client target = await this._clientRepo.GetById(id);

                if (target != null)
                    await this._clientRepo.Remove(target);

                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                // Log?
                // Display error on page?
                return RedirectToAction("Index");
            }
        }
    }
}
