using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_autores.Models
{
    [Table("detalle_ventas")]
    public class DetalleVenta
    {
        [Key]
        [Column("detalle_id")]
        public int Id { get; set; }
        [Column("venta_id")]
        public int VentaId { get; set; }

        public int producto_id { get; set; }
        public Producto Producto { get; set; }
        [Column("cantidad")]
        public int Cantidad { get; set; }
        [Column("precio_unitario")]
        public decimal PrecioUnitario { get; set; }
        [Column("subtotal")]
        public decimal subtotal {get; set;}
        [Column("created_at")]
        public DateTime createdAt { get; set; }
    }
}