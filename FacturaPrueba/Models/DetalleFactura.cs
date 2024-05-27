using System;
using System.Collections.Generic;

namespace FacturaPrueba.Models
{
    public partial class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public string Producto { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = null!;
        public int? UsuarioIngreso { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; } = null!;
    }
}
