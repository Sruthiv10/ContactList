using Microsoft.AspNetCore.Mvc;

namespace ContactList.API.Controllers
{
    public class ContactListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
