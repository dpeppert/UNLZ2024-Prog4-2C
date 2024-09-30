using LogisticaContainers.Entidades;
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
            List<ContainerVM> results = new List<ContainerVM>();
            foreach (var container in containers)
            {
                results.Add(this.CrearModelo(container));

            }

            return results;
        }
    }


    public class ContainerVM 
    {

        public int IdContainer { get; set; }
        public string DescripcionContainer { get; set; }

        public int IdEstadoContainer { get; set; }


    }

    public class ContainerModel
    {

        public int IdContainer { get; set; }
        public string DescripcionContainer { get; set; }

        public int IdEstadoContainer { get; set; }


    }

}
