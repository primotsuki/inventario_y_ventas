using System.ComponentModel.DataAnnotations.Schema;

namespace backend_autores.Models
{
    [Table("productos")]
    public class Producto
    {
        [Column("producto_id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("precio")]
        public decimal Precio { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("imagen_url")]
        public string ImagenUrl { get; set; }
        [Column("categoria_id")]
        public int categoriaId { get; set; }
        public Categoria Categoria { get; set; }
        [Column("var_code")]
        public string VarCode { get; set; }
    }
}