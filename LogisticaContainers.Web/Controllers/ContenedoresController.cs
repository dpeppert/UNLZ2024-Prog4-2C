using LogisticaContainers.Managers;
using LogisticaContainers.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticaContainers.Web.Controllers
{
    public class ContenedoresController : Controller
    {
        private IContainerManager _containerManager;

        private List<ContenedorVM> _contenedores { get; set; }

        public ContenedoresController (IContainerManager containerManager)
        {

            this._containerManager = containerManager;
            _contenedores = new List<ContenedorVM> ();
            _contenedores.Add(new ContenedorVM
            {
                IdContenedor = 1,
                FechaRegistracion = DateTime.Now,
                NumeroSerie = "asda-01",
                Direccion = "Avenida Siempreviva 2792"
            });

            _contenedores.Add(new ContenedorVM
            {
                IdContenedor = 2,
                FechaRegistracion = DateTime.Now,
                NumeroSerie = "asdasdasda-22321",
                Direccion = "Calle Falsa 123"
            });


        }
        // GET: ContenedoresController
        public ActionResult Index()
        {

            var contenedor = this._containerManager.CrearContainer();
            _contenedores.Add(new ContenedorVM
            {
                Direccion = contenedor.DescripcionContainer,
                FechaRegistracion = contenedor.FechaAlta,
                IdContenedor = contenedor.IdContainer,
                NumeroSerie = contenedor.DescripcionContainer
            });
            ContainerManager containerManager = new ContainerManager(); 
            return View(_contenedores);
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
