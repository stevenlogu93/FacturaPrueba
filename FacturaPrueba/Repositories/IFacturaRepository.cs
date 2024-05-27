using FacturaPrueba.Models;

namespace FacturaPrueba.Repositories
{
    public interface IFacturaRepository
    {
        IEnumerable<Factura> ConsultarTodos();

        Factura ConsultarporId(int id);

        void RegistrarFactura(Factura factura);

        void ActualizarFactura(Factura factura);
    }
}
