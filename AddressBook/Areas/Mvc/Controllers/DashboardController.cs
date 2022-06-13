using AddressBook.Data;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Mvc.Controllers
{
    [Area("Mvc")]
    public class DashboardController : Controller
    {
        public DashboardController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
