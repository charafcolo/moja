using DAO.DAO;
using DAO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class EntrepriseController : Controller
    {
        private readonly IEntrepriseDAO _dao;

        public EntrepriseController(IEntrepriseDAO dao)
        {
            _dao = dao;
        }


        // GET: EntrepriseController
        public async Task<ActionResult> Index()
        {
            return View(await _dao.GetAll());
        }

        // GET: EntrepriseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EntrepriseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntrepriseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entreprise entreprise)
        {
            try
            {
                _dao.Create(entreprise);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EntrepriseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntrepriseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EntrepriseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntrepriseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
