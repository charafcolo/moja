using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class EntrepriseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
