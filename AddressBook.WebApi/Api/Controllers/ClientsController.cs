using AddressBook.Api.Attributes;
using AddressBook.Data;
using AddressBook.Data.Entities;
using AddressBook.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepo _clientRepo;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepo clientRepo, IMapper mapper)
        {
            this._clientRepo = clientRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> Get()
        {
            try
            {
                IEnumerable<Client> clients = await _clientRepo.GetAll();

                return Ok(this._mapper.Map<IEnumerable<ClientModel>>(clients));
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClientModel>> Get(int id)
        {
            try
            {
                Client client = await _clientRepo.GetById(id);

                if (client == null)
                    return NotFound("Id doesn't exist.");

                return Ok(this._mapper.Map<ClientModel>(client));
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Client>> Get(string email)
        {
            try
            {
                Client client = await _clientRepo.GetByEmail(email);

                if (client == null)
                    return NotFound("Email doesn't exist.");

                return Ok(this._mapper.Map<ClientModel>(client));
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Post(ClientModel model)
        {
            try
            {
                Client existingClient = await this._clientRepo.GetByEmail(model.Email);

                if (existingClient != null)
                    return BadRequest("Email already in use.");

                Client client = this._mapper.Map<Client>(model);
                Client newClient = await this._clientRepo.Create(client);

                if (await this._clientRepo.SaveChanges())
                    return Ok(this._mapper.Map<ClientModel>(newClient));

                return BadRequest("Could not create new client.");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Client>> Put(int id, ClientModel model)
        {
            try
            {
                Client existingClient = await this._clientRepo.GetById(id);

                if (existingClient == null)
                    return BadRequest("Id doesn't exist.");

                this._mapper.Map(model, existingClient);

                if (await this._clientRepo.SaveChanges())
                    return Ok(this._mapper.Map<ClientModel>(existingClient));

                return BadRequest("Could not update client.");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPut("{email}")]
        public async Task<ActionResult<Client>> Put(string email, ClientModel model)
        {
            try
            {
                Client existingClient = await this._clientRepo.GetByEmail(email);

                if (existingClient == null)
                    return BadRequest("Email doesn't exist.");

                this._mapper.Map(model, existingClient);

                if (await this._clientRepo.SaveChanges())
                    return Ok(this._mapper.Map<ClientModel>(existingClient));

                return BadRequest("Could not update client.");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Client existingClient = await this._clientRepo.GetById(id);

                if (existingClient == null)
                    return NotFound("Id doesn't exist.");

                await this._clientRepo.Remove(existingClient);

                if (await this._clientRepo.SaveChanges())
                    return Ok();

                return BadRequest("Could not remove client.");
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
