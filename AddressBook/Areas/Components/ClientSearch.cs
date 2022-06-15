using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Areas.Components
{
    public class ClientSearch : ViewComponent
    {
        public ClientSearch()
        {

        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
