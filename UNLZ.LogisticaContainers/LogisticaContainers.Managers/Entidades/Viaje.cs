using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticaContainers.Managers.Entidades.Auditoria;

namespace LogisticaContainers.Managers.Entidades
{
    public class Viaje : Audit
    {
        public int IdViaje { get; set; }
        public int IdContainer { get; set; }
        public int IdHangarOrigen { get; set; }
        public int IdHangarDestino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }



    }
}
