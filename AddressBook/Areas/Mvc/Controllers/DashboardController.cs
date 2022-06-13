using AddressBook.Data;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Mvc.Controllers
{
    [Area("Mvc")]
    public class DashboardController : Controller
    {
        private readonly IUsersRepo _userRepo;
        private readonly IClientRepo _clientRepo;

        public DashboardController(IUsersRepo userRepo, IClientRepo clientRepo)
        {
            this._userRepo = userRepo;
            this._clientRepo = clientRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
