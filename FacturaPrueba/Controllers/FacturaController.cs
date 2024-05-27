using FacturaPrueba.Models;
using FacturaPrueba.Models.ViewModel;
using FacturaPrueba.Services.FacturaServices;
using Microsoft.AspNetCore.Mvc;

namespace FacturaPrueba.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaService _FacturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _FacturaService = facturaService;
        }

        public IActionResult Index()
        {
            var facturas = _FacturaService.ConsultarTodos();
            return View(facturas);
        }

        public IActionResult VerDetalle(int id)
        {
            var factura = _FacturaService.ConsultarporId(id);
            if (factura == null)
            {
                return NotFound();
            }
            var viewModel = new FacturaVM
            {
                Objfactura = factura,
                ListdetalleFactura = factura.DetalleFacturas.ToList()
            };
            return View(viewModel);
        }

        public IActionResult CrearFactura()
        {
            var viewModel = new FacturaVM
            {
                Objfactura = new Factura(),
                ListdetalleFactura = new List<DetalleFactura>()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult RegistrarFactura(FacturaVM viewModel)
        {
            if (ModelState.IsValid)
            {
                _FacturaService.RegistrarFactura(viewModel.Objfactura);
                _FacturaService.AddDetalleToFactura(viewModel.Objfactura.IdFactura, viewModel.ListdetalleFactura);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(CrearFactura));
        }
    }
}   