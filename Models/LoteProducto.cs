using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_autores.Models
{
    [Table("lote_productos")]
    public class LoteProducto
    {
        [Key]
        [Column("lote_id")]
        public int Id { get; set; }
        [Column("cantidad")]
        public int Cantidad { get; set; }
        [Column("producto_id")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        [Column("proveedor_id")]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        [Column("precio_compra")]
        public decimal PrecioCompra { get; set; }
        [Column("fecha_ingreso")]
        public DateTime FechaIngreso { get; set; }

    }
}