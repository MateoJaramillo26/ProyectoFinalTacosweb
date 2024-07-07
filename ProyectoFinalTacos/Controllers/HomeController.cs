using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalTacos.Models;
using ProyectoFinalTacos.ViewModels;
using System.Threading.Tasks;
using System.Diagnostics;
using ProyectoFinalTacos.Data;

namespace ProyectoFinalTacos.Controllers
{
    public class HomeController : Controller
    {
       private readonly ProyectoFinalTacosContext _context;

        public HomeController(ProyectoFinalTacosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Producto.ToListAsync();
            var model = new ProductsViewmodel
            {
                Products = products
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
