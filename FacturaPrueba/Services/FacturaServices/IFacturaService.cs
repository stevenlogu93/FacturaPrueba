using FacturaPrueba.Models;

namespace FacturaPrueba.Services.FacturaServices
{
    public interface IFacturaService
    {
        IEnumerable<Factura> ConsultarTodos();

        Factura ConsultarporId(int id);
        
        void RegistrarFactura(Factura factura);

        void ActualizarFactura(Factura factura);

        void AddDetalleToFactura(int facturaId, List<DetalleFactura> detalleFactura);
    }
}
