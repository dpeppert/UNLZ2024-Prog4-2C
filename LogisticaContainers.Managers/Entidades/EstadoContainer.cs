using LogisticaContainers.Managers.Entidades.Auditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaContainers.Entidades
{
    public class EstadoContainer: Audit
    {
        public int IdEstadoContainer { get; set; }
        public string Descripcion { get; set; }
    }
}
