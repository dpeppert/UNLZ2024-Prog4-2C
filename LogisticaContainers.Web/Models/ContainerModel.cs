using LogisticaContainers.Managers.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticaContainers.Web.Models
{
    public class ContainerModel
    {
        public Container model { get; set; }
        public List<SelectListItem> ListaEstadosItem { get; set; }
    }
}
