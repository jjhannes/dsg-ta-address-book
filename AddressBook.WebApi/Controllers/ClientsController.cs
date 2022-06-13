using AddressBook.WebApi.Attributes;
using AddressBook.WebApi.Data;
using AddressBook.WebApi.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepo _clientRepo;

        public ClientsController(IClientRepo clientRepo)
        {
            this._clientRepo = clientRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            try
            {
                IEnumerable<Client> clients = await _clientRepo.GetAll();

                return Ok(clients);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Client>>> Get(int id)
        {
            try
            {
                Client client = await _clientRepo.GetById(id);

                if (client == null)
                    return NotFound();

                return Ok(client);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<Client>>> Get(string email)
        {
            try
            {
                Client client = await _clientRepo.GetByEmail(email);

                if (client == null)
                    return NotFound();

                return Ok(client);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
