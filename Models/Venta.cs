using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_autores.Models
{
    [Table("ventas")]
    public class Venta
    {
        [Key]
        [Column("venta_id")]
        public int Id { get; set; }
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        [Column("total")]
        public decimal Total { get; set; }
        [Column("descuento")]
        public decimal Descuento { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
        [Column("cliente")] 
        public string Cliente { get; set; }
        [Column("metodo_pago")]
        public string MetodoPago { get; set; }
        [Column("descripcion_descuento")]   
        public string descripcionDescuento { get; set; }
    
    }
}