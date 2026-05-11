namespace backend_autores.Models.DTORequests
{
    public class DTOLoteProducto
    {
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public decimal PrecioCompra { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}