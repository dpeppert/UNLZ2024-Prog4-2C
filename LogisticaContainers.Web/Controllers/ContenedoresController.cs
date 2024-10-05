using LogisticaContainers.Managers;
using LogisticaContainers.Managers.Entidades; 
using LogisticaContainers.Repos;
using LogisticaContainers.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using System.Linq;

namespace LogisticaContainers.Web.Controllers
{
    public class ContenedoresController : Controller
    {
        private IContainerManager _containerManager;
        private IEstadoContainerRepository _estadoContainerRepository;
         

        public ContenedoresController (IContainerManager containerManager, IEstadoContainerRepository estadoContainerRepository)
        {
            _containerManager = containerManager;
            _estadoContainerRepository = estadoContainerRepository;

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

            var container = _containerManager.GetContainer(id);

            ContainerModel containerModel = new ContainerModel();
            containerModel.model = container;
            containerModel.ListaEstadosItem = new List<SelectListItem>();
            var estados = _estadoContainerRepository.GetEstadosContainer();
            foreach(var estado in estados)
            {
                containerModel.ListaEstadosItem.Add(new SelectListItem { Value = estado.IdEstadoContainer.ToString(), Text = estado.Descripcion });
            }

            return View(containerModel);
        }

        // GET: ContenedoresController/Create
        public ActionResult Create()
        {
            ContainerModel containerModel = new ContainerModel();
            containerModel.model = null;
            containerModel.ListaEstadosItem = new List<SelectListItem>();
            var estados = _estadoContainerRepository.GetEstadosContainer();
            foreach (var estado in estados)
            {
                containerModel.ListaEstadosItem.Add(new SelectListItem { Value = estado.IdEstadoContainer.ToString(), Text = estado.Descripcion });
            }
            return View(containerModel);
        }

        // POST: ContenedoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Container container = new Container 
                {
                    DescripcionContainer = collection["model.DescripcionContainer"],
                    IdEstadoContainer = int.Parse(collection["model.IdEstadoContainer"]) 
                };
                int idUsuario = GetUserIdentityId();

                _containerManager.CrearContainer(container, idUsuario);

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
            var container = _containerManager.GetContainer(id);
            var estados = _estadoContainerRepository.GetEstadosContainer();

            ContainerModel containerModel = new ContainerModel();
            containerModel.model = container;
            containerModel.ListaEstadosItem = new List<SelectListItem>();
            foreach (var estado in estados)
            {
                containerModel.ListaEstadosItem.Add(new SelectListItem { Value = estado.IdEstadoContainer.ToString(), Text = estado.Descripcion });
            }

            return View(containerModel);
        }

        // POST: ContenedoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Container  container = new Container 
                {
                    DescripcionContainer = collection["model.DescripcionContainer"],
                    IdEstadoContainer = int.Parse(collection["model.IdEstadoContainer"])
                };
                int idUsuario = GetUserIdentityId();

                _containerManager.ModificarContainer(id, container, idUsuario);

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
            var container = _containerManager.GetContainer(id);
            var estados = _estadoContainerRepository.GetEstadosContainer();

            ContainerModel containerModel = new ContainerModel();
            containerModel.model = container;
            containerModel.ListaEstadosItem = new List<SelectListItem>();
            foreach (var estado in estados)
            {
                containerModel.ListaEstadosItem.Add(new SelectListItem { Value = estado.IdEstadoContainer.ToString(), Text = estado.Descripcion });
            }
            return View(containerModel);
        }

        // POST: ContenedoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {


                int idUsuario = GetUserIdentityId();

                _containerManager.EliminarContainer(id, idUsuario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        private int GetUserIdentityId()
        {
            return 1; //Ver en la clase 7
        }

    }
}
