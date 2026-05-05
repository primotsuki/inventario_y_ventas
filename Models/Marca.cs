using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_autores.Models
{
    [Table("marcas")]
    public class Marca
    {
        [Key]
        [Column("marca_id")]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}