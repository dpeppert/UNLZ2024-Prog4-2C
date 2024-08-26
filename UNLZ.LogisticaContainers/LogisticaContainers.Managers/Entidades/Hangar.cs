using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticaContainers.Managers.Entidades.Auditoria;

namespace LogisticaContainers.Managers.Entidades
{
    public class Hangar : Audit
    {
        public int IdHangar { get; set; }

        public string Nombre { get; set; }

    }



}
