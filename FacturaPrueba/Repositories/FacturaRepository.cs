using FacturaPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace FacturaPrueba.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly FacturaContext _context;

        public FacturaRepository(FacturaContext context)
        {
            _context = context;
        }

        public IEnumerable<Factura> ConsultarTodos()
        {
            return _context.Facturas.Include(f => f.DetalleFacturas).ToList();
        }

        public Factura ConsultarporId(int id)
        {
            return _context.Facturas.Include(f => f.DetalleFacturas).FirstOrDefault(f => f.IdFactura == id);
        }

        public void RegistrarFactura(Factura factura)
        {
            _context.Facturas.Add(factura);
            _context.SaveChanges();
        }

        public void ActualizarFactura(Factura factura)
        {
            _context.Facturas.Update(factura);
            _context.SaveChanges();
        }
    }
}
