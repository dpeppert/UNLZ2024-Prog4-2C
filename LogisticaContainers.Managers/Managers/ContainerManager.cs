using LogisticaContainers.Managers.Entidades;
using LogisticaContainers.ModelFactories;
using LogisticaContainers.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaContainers.Managers
{
    public interface IContainerManager
    { 
        IEnumerable<ContainerVM> GetContainers();
        ContainerVM GetContainer(int IdContainer);
        int CrearContainer(ContainerVM container, int IdUsuarioAlta);
        bool ModificarContainer(int IdContainer, ContainerVM container, int IdUsuarioModificacion);
        bool EliminarContainer(int IdContainer, int IdUsuarioBaja);
    }


    public class ContainerManager : IContainerManager
    {
        private IContainerRepository _repo;
        private IContainerModelFactory _modelFactory;

        public ContainerManager(IContainerRepository repo, IContainerModelFactory modelFactory)
        {
            _repo = repo;
            _modelFactory = modelFactory;
        }

        /// <summary>
        /// Obtiene un ContainerVm por Id 
        /// </summary>
        /// <param name="IdContainer">Id del Contenedor</param>
        /// <returns></returns>
        public ContainerVM GetContainer(int IdContainer)
        {
            var container = _repo.GetContainer(IdContainer);
            return _modelFactory.CrearModelo(container);


        }

        /// <summary>
        /// Obtiene una lista de Containers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContainerVM> GetContainers()
        {
            return _repo.GetContainersCompleto();
        }

        /// <summary>
        /// Crea un Container en la Base de Datos
        /// </summary>
        /// <param name="containerVm">Datos del contenedor</param>
        /// <param name="IdUsuarioAlta">Id del usuario de la acción</param>
        /// <returns></returns>
        public int CrearContainer(ContainerVM containerVm, int IdUsuarioAlta)
        {
            var container = _modelFactory.CrearEntidad(containerVm);
            container.IdUsuarioAlta = IdUsuarioAlta;
            container.FechaAlta = DateTime.Now;
            var cont = _repo.CrearContainer(container);

            return cont; 

        }

        /// <summary>
        /// Elimina un container
        /// </summary>
        /// <param name="IdContainer">Id del Contenedor</param>
        /// <param name="IdUsuarioBaja">Id del usuario de la acción</param>
        /// <returns></returns>
        public bool EliminarContainer(int IdContainer, int IdUsuarioBaja)
        {
            return _repo.EliminarContainer(IdContainer, IdUsuarioBaja);
            
        }

        /// <summary>
        /// Modifica los datos de un container a partir de un Id por los que se envían en el ContainerVM
        /// </summary>
        /// <param name="IdContainer">Id del container a modificar</param>
        /// <param name="containerVm">Datos del contenedor</param>
        /// <param name="IdUsuarioModificacion">Id del usuario de la acción</param>
        /// <returns></returns>
        public bool ModificarContainer(int IdContainer, ContainerVM containerVm, int IdUsuarioModificacion)
        {
            //Obtengo lo que me viene del formulario 
            var container = _modelFactory.CrearEntidad(containerVm);

            //Obtengo lo que viene de la base de datos
            var containerEnDb = _repo.GetContainer(IdContainer);

            //En el objeto que viene de la base de datos, le "pego" los valores que me vienen del formulario
            containerEnDb = _modelFactory.FusionarEntidades(container, containerEnDb);
            containerEnDb.IdUsuarioModificacion = IdUsuarioModificacion;
            containerEnDb.FechaModificacion = DateTime.Now;
            var cont = _repo.ModificarContainer(IdContainer, containerEnDb );

            return cont;
        }
    }
}
