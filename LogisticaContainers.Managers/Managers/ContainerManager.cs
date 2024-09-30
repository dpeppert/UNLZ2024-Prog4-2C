
using LogisticaContainers.Entidades;
using LogisticaContainers.ModelFactories;
using LogisticaContainers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaContainers.Managers
{
    public interface IContainerManager
    {
        Container CrearContainer();
        IEnumerable<ContainerVM> GetContainers();
    }


    public class ContainerManager : IContainerManager
    {
        private IContainerRepository _containerRepo;
        private IContainerModelFactory _containerModelFactory;

        public ContainerManager(IContainerRepository containerRepo, IContainerModelFactory containerModelFactory)
        {
            _containerRepo = containerRepo;
            _containerModelFactory = containerModelFactory;
        }

        public IEnumerable<ContainerVM> GetContainers()
        {
            return _containerModelFactory.CrearModelos(_containerRepo.GetContainers());
        }

        public Container CrearContainer()
        {
            return null;
/*            Container container = new Container
            {
                IdContainer = 6,
                DescripcionContainer = "ASD-QE-12",
                EstaCargado = false,
                IdUsuarioAlta =1, 
                FechaAlta = DateTime.Now
            };

            return container; */

        }
    }
}
