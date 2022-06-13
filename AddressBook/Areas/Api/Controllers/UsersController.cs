using AddressBook.Data;
using AddressBook.Data.Entities;
using AddressBook.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AddressBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _userRepo;
        private readonly Services.AuthService _authService;

        public UsersController(IUsersRepo userRepo, Services.AuthService authService)
        {
            this._userRepo = userRepo;
            this._authService = authService;
        }

        [HttpPost("auth")]
        public async Task<ActionResult<TokenModel>> Authenticate(AuthModel paylod)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(paylod.Username) || string.IsNullOrWhiteSpace(paylod.Password))
                    return BadRequest();

                User user = await this._userRepo.Authenticate(paylod.Username, paylod.Password);

                if (user == null)
                    return Unauthorized();

                TokenModel token = this._authService.GenerateJwtToken(user);

                if (token == null || string.IsNullOrWhiteSpace(token.AccessToken))
                    return Unauthorized();

                return Ok(token);
            }
            catch (Exception error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }
    }
}
