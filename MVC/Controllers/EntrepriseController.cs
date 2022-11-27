using DAO.DAO;
using DAO.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.Services;

namespace MVC.Controllers
{
    public class EntrepriseController : Controller
    {
        // J'ai rajouté une couche Service.
        //Désormais le controller appelle la couche Service et la couche service appelle la couche DAO

        // Pour pouvoir utiliser la couche 'service' il faut rajouter dans program.cs : 
        // builder.Services.AddScoped<IEntrepriseService, EntrepriseService>();

        private readonly IEntrepriseService _service;

        public EntrepriseController(IEntrepriseService service)
        {
            _service = service;
        }

        // GET: EntrepriseController
        public async Task<ActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: EntrepriseController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Entreprise? entreprise = await _service.GetById(id);

            if (entreprise == null) return NotFound();

            return View(entreprise);
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
                _service.Create(entreprise);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EntrepriseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Entreprise? entreprise = await _service.GetById(id);

            if (entreprise == null) return NotFound();

            return View(entreprise);
        }

        // POST: EntrepriseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Entreprise entreprise)
        {
            try
            {
                _service.Update(entreprise);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EntrepriseController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Entreprise? entreprise = await _service.GetById(id);

            if (entreprise == null) return NotFound();

            return View();
        }

        // POST: EntrepriseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Entreprise entreprise)
        {
            Entreprise? found = await _service.GetById(id);

            if (entreprise == null) return NotFound();

            try
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
