using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_autores.Models
{
    [Table("proveedores")]
    public class Proveedor
    {
        [Key]
        [Column("proveedor_id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("contacto")]
        public string Contacto { get; set; }
        [Column("telefono")]
        public string Telefono { get; set; }
    }
}