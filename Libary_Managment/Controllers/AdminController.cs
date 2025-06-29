using Microsoft.AspNetCore.Mvc;

namespace Libary_Managment.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
