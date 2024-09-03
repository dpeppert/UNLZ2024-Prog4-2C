using LogisticaContainers.Managers.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaContainers.Managers.Managers
{
    public class ContainerManager
    {
        public ContainerManager()
        {

        }


        public Container CrearContainer()
        {
            Container container = new Container
            {
                IdContainer = 1,
                DescripcionContainer = "ASD-QE-12",
                EstaCargado = false,
                IdUsuarioAlta =1, 
                FechaAlta = DateTime.Now
            };

            return container; 

        }
    }
}
