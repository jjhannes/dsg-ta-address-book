using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AddressBook.Areas.Mvc.Controllers
{
    [Area("Mvc")]
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile fileUpload)
        {
            // TODO: Upload

            // TODO: Save data

            return await Task.Run(() => View());
        }
    }
}
