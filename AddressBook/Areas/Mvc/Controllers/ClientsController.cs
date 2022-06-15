using AddressBook.Areas.Mvc.ViewModels;
using AddressBook.Data;
using AddressBook.Data.Entities;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ClientsController(IClientRepo clientRepo, IMapper mapper)
        {
            this._clientRepo = clientRepo;
            this._mapper = mapper;
        }

        public async Task<ViewResult> Index()
        {
            IEnumerable<Client> clients = await this._clientRepo.GetAll();

            ClientsViewModel model = new ClientsViewModel
            {
                Clients = clients.OrderBy(c => c.Name)
            };

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(ClientsViewModel model)
        {
            ClientsViewModel outputModel = new ClientsViewModel();

            IEnumerable<Client> clients = await this._clientRepo.GetAll();

            if (string.IsNullOrWhiteSpace(model.Query))
            {
                outputModel.Clients = clients;

                return RedirectToAction("Index", "Clients");
            }

            IEnumerable<Client> filteredClients = clients.Where(c =>
                c.Name.ToLower().Contains(model.Query.ToLower()) ||
                c.Surname.ToLower().Contains(model.Query.ToLower()));

            outputModel.Clients = filteredClients;
            outputModel.Query = model.Query;

            return View("Index", outputModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            Client client = await this._clientRepo.GetById(id);

            if (client == null)
            {
                // User could not be found; redirect to the list to refresh
                // TODO: Implement some message
                return RedirectToAction("Index");
            }

            return View("Details", client);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Update(Client client)
        {
            try
            {
                Client existingClient = await this._clientRepo.GetById(client.Id);

                if (existingClient == null)
                {
                    // There could not be found; redirect back to the list
                    // TODO: Implement a message
                    return RedirectToAction("Index");
                }

                existingClient = this._mapper.Map(client, existingClient);

                if (await this._clientRepo.SaveChanges())
                    return RedirectToAction("Details", new { id = client.Id });

                // There was a problem saving
                // TODO: Implement a message
                return RedirectToAction("Details", new { id = client.Id });
            }
            catch (Exception)
            {
                // Log?
                // Display error on page?
                return RedirectToAction("Details", new { id = client.Id });
            }
        }

        public async Task<RedirectToActionResult> Delete(int id)
        {
            try
            {
                Client target = await this._clientRepo.GetById(id);

                if (target == null)
                {
                    // User could not be found; redirect to the list to refresh
                    // TODO: Implement some message
                    return RedirectToAction("Index");
                }

                await this._clientRepo.Remove(target);

                if (await this._clientRepo.SaveChanges())
                    return RedirectToAction("Index");

                // There was a problem; redirect to the list to refresh
                // TODO: Implement a message
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // There was a problem; redirect to the list to refresh
                // TODO: Implement a message
                return RedirectToAction("Index");
            }
        }
    }
}
