using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_autores.Models
{
    [Table("categorias")]
    public class Categoria
    {
        [Key]
        [Column("categoria_id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}