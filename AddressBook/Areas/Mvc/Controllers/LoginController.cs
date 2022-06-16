using AddressBook.Api.Models;
using AddressBook.Areas.Mvc.Sessions;
using AddressBook.Areas.Mvc.ViewModels;
using AddressBook.Data;
using AddressBook.Data.Entities;
using AddressBook.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AddressBook.Areas.Mvc.Controllers
{
    [Area("Mvc")]
    public class LoginController : Controller
    {
        private readonly IUsersRepo _userRepo;
        private readonly AuthService _authService;

        public LoginController(IUsersRepo userRepo, AuthService authService)
        {
            this._userRepo = userRepo;
            this._authService = authService;
        }

        public IActionResult Index()
        {
            UserSession session = UserSession.GetSession(this.HttpContext.Session);

            if (session.LogedIn)
                return RedirectToAction("Index", "Dashboard");
            
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginViewModel model)
        {
            User user = await this._userRepo.Authenticate(model.Email, model.Password);

            if (user == null)
                // Login failed
                // TODO: Add a message
                // OPTIONS: Use [TempData]
                return View("Index", new LoginViewModel {  Email = model.Email });

            TokenModel token = this._authService.GenerateJwtToken(user);

            UserSession.CreateAuthenticatedSession(this.HttpContext.Session, user, token);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
