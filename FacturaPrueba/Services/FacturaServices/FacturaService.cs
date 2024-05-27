using FacturaPrueba.Models;
using FacturaPrueba.Repositories;
using FacturaPrueba.Repositories.DetalleFacturaRepository;

namespace FacturaPrueba.Services.FacturaServices
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _FacturaRepository;
        private readonly IDetalleFacturaRepository _DetalleFacturaRepository;

        public FacturaService(IFacturaRepository facturaRepository, IDetalleFacturaRepository detalleFacturaRepository)
        {
            _FacturaRepository = facturaRepository;
            _DetalleFacturaRepository = detalleFacturaRepository;
        }

        public void ActualizarFactura(Factura factura)
        {
            _FacturaRepository.ActualizarFactura(factura);
        }

        public void AddDetalleToFactura(int facturaId, List<DetalleFactura> detalleFactura)
        {
            var factura = _FacturaRepository.ConsultarporId(facturaId);
            if (factura != null)
            {
                foreach(var detalle in detalleFactura)
                {
                    factura.DetalleFacturas.Add(detalle);
                    factura.Total += detalle.Cantidad * detalle.PrecioUnitario;
                    _DetalleFacturaRepository.AgregarDetalleFactura(detalle);
                    _FacturaRepository.ActualizarFactura(factura);
                }
                
            }
        }

        public Factura ConsultarporId(int id)
        {
            return _FacturaRepository.ConsultarporId(id);
        }

        public IEnumerable<Factura> ConsultarTodos()
        {
            return _FacturaRepository.ConsultarTodos();
        }

        public void RegistrarFactura(Factura factura)
        {
            _FacturaRepository.RegistrarFactura(factura);
        }
    }
}
