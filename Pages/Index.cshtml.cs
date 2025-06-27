using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VentasApp.Models;
using VentasApp.Datos;

namespace VentasApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Categoria> Categorias { get; set; } = new();
        public List<Producto> Productos { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? CategoriaSeleccionada { get; set; }

        public void OnGet()
        {
            var db = new Database();
            Categorias = db.ObtenerCategoriasConVentas2019();

            if (CategoriaSeleccionada.HasValue)
            {
                Productos = db.ObtenerProductosVendidosEn2019PorCategoria(CategoriaSeleccionada.Value);
            }
        }
    }
}