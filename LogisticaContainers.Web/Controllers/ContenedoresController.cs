using LogisticaContainers.Entidades;
using LogisticaContainers.Managers;
using LogisticaContainers.ModelFactories;
using LogisticaContainers.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticaContainers.Web.Controllers
{
    public class ContenedoresController : Controller
    {
        private IContainerManager _containerManager;
        private IContainerModelFactory _containerModelFactory;

        public ContenedoresController (IContainerManager containerManager)
        {

            this._containerManager = containerManager;

        }
        // GET: ContenedoresController
        public ActionResult Index()
        {

            var containers = _containerManager.GetContainers();
            
            return View(containers);
        }

        // GET: ContenedoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContenedoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContenedoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ContenedoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContenedoresController/Edit/5
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

        // GET: ContenedoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContenedoresController/Delete/5
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
