using LogisticaContainers.ModelFactories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticaContainers.Web.Models
{
    public class ContainerModel
    {
        public ContainerVM model { get; set; }
        public List<SelectListItem> ListaEstadosItem { get; set; }
    }
}
