using FacturaPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FacturaPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly FacturaContext _dbcontext;

        public HomeController(FacturaContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
