namespace backend_autores.Models.DTORequests
{
    public class DTOProductoCreate
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public int categoriaId { get; set; }
        public int proveedorId {get; set;}
        public string VarCode { get; set; }
    }
}