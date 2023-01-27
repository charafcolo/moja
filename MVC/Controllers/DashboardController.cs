using DAO;
using DAO.DAO;
using DAO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC.ViewModels;
using System.Security.Claims;

namespace MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserDAO _dao;
        private readonly UserManager<ApplicationUser> _user;
        public DashboardController(IUserDAO dao, UserManager<ApplicationUser> user)
        {
            _dao = dao;
            _user = user;
        }

        // GET: DashboardController
        [Authorize]
        public async Task<ActionResult> Index()
        {
            IQueryable<Candidature> cIqueryable = await _dao.GetCandidatureByUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<Candidature> c = cIqueryable.ToList();
            return View(c);
        }

        // GET: DashboardController/Create
        [Authorize]
        public ActionResult Create()
        {
            AddCandidatureViewModel model = new();
            
            return View(model);
        }

        // POST: DashboardController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddCandidatureViewModel viewModel)
        {
            try
            {
                if(ModelState.IsValid) { 
                Entreprise newEntreprise = new(viewModel.EntrepriseName) { City = viewModel.EntrepriseCity};
                Candidature createCandidature = new(viewModel.PostName, viewModel.ModificationDate, viewModel.Status, viewModel.Comment);
                createCandidature.Entreprise = newEntreprise;
                await _dao.AddCandidature(User.FindFirstValue(ClaimTypes.NameIdentifier), createCandidature);

                return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection c)
        {
            try
            {
                await _dao.DeleteCandidature(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
