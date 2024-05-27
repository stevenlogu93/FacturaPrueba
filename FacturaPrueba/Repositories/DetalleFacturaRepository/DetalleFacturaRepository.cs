using FacturaPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace FacturaPrueba.Repositories.DetalleFacturaRepository
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private readonly FacturaContext _FacturaContext;

        public DetalleFacturaRepository(FacturaContext facturaContext)
        {
            _FacturaContext = facturaContext;
        }

        public void AgregarDetalleFactura(DetalleFactura detalleFactura)
        {
            _FacturaContext.DetalleFacturas.Add(detalleFactura);
            _FacturaContext.SaveChanges();
        }
    }
}
