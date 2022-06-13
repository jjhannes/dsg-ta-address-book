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
    public class ClientsController : Controller
    {
        private readonly IClientRepo _clientRepo;

        public ClientsController(IClientRepo clientRepo)
        {
            this._clientRepo = clientRepo;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Client> clients = await this._clientRepo.GetAll();

            return View("Index", clients.OrderBy(c => c.Name));
        }

        public async Task<IActionResult> Details(int id)
        {
            Client client = await this._clientRepo.GetById(id);

            return View("Details", client);
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
            catch (Exception)
            {
                // Log?
                // Display error on page?
                return RedirectToAction("Index");
            }
        }
    }
}
