using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
