using AddressBook.WebApi.Data;
using AddressBook.WebApi.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AddressBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _userRepo;

        public UsersController(IUsersRepo userRepo)
        {
            this._userRepo = userRepo;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<User>> Get(string email)
        {
            try
            {
                User user = await this._userRepo.GetDetails(email);

                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> Authenticate(User paylod)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(paylod.Username) || string.IsNullOrWhiteSpace(paylod.Password))
                    return BadRequest();

                User user = await this._userRepo.Authenticate(paylod.Username, paylod.Password);

                if (user == null)
                    return Unauthorized();

                return Ok(user);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
