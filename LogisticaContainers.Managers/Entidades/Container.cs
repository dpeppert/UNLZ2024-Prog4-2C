using LogisticaContainers.Managers.Entidades.Auditoria;

namespace LogisticaContainers.Entidades
{
    public class Container : Audit
    {

        public int IdContainer { get; set; }
        public string DescripcionContainer { get; set; }

        public int IdEstadoContainer{ get; set; }


    }





}
