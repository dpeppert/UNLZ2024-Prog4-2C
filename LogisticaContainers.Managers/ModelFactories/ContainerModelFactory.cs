using LogisticaContainers.Managers.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaContainers.ModelFactories
{
    public interface IContainerModelFactory
    {
        ContainerVM CrearModelo(Container container);
        IEnumerable<ContainerVM> CrearModelos(IEnumerable<Container> containers);
        Container CrearEntidad(ContainerVM container);
    }

    public class ContainerModelFactory : IContainerModelFactory
    {

        public ContainerVM CrearModelo(Container container)
        {
            return new ContainerVM
            {
                IdContainer = container.IdContainer,
                DescripcionContainer = container.DescripcionContainer,
                IdEstadoContainer = container.IdEstadoContainer
            };
        }

        public IEnumerable<ContainerVM> CrearModelos(IEnumerable<Container> containers)
        {
            List<ContainerVM> result = new List<ContainerVM>();
            foreach (var container in containers)
            {
                result.Add(this.CrearModelo(container));
            }

            return result;


        }

        public Container CrearEntidad(ContainerVM containerVM)
        {
            return new Container
            {
                DescripcionContainer = containerVM.DescripcionContainer,
                IdContainer = containerVM.IdContainer,
                IdEstadoContainer = containerVM.IdEstadoContainer
            };
        }
    }

    public class ContainerVM
    {
        public int IdContainer { get; set; }
        public string DescripcionContainer { get; set; }
        public int IdEstadoContainer { get; set; } 
        public string Estado { get; set; }
    }
}
