using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LogisticaContainers.Managers.Entidades.Auditoria;

namespace LogisticaContainers.Managers.Entidades
{
    public class Usuario : Audit
    {
        public int IdUsuario { get; set; }
        public string GoogleIdentificador { get; set; }
        public string NombreCompleto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }

        public bool Borrado { get; set; }

    }
}
