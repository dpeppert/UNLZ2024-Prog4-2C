using LogisticaContainers.Managers.Entidades;
using LogisticaContainers.ModelFactories;
using LogisticaContainers.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaContainers.Managers
{
    public interface IContainerManager
    { 
        IEnumerable<ContainerVM> GetContainers();
        int CrearContainer(Container container);
    }


    public class ContainerManager : IContainerManager
    {
        private IContainerRepository _repo;
        private IContainerModelFactory _modelFActory;

        public ContainerManager(IContainerRepository repo, IContainerModelFactory modelFactory)
        {
            _repo = repo;
            _modelFActory = modelFactory;
        }


        public int CrearContainer(ContainerVM container)
        {
            var 
            var cont = _repo.CrearContainer(container);

            return cont; 

        }
    
        public IEnumerable<ContainerVM> GetContainers()
        {
            return _repo.GetContainersVM();
        }
    
    }
}
