using DAO.DAO;
using DAO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.ApiRequest;
using MVC.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserDAO _dao;
        private readonly UserManager<ApplicationUser> _user;

        public HomeController(ILogger<HomeController> logger, IUserDAO dao, UserManager<ApplicationUser> user)
        {
            _logger = logger;
            _dao = dao;
            _user = user;
        }

        public IActionResult Index()
        {
            return View(RequestPoleEmploi.RetourResult(_dao.GetPost(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}