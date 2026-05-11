using System.Data.Entity;
using backend_autores.DB;
using backend_autores.Models;
using backend_autores.Models.DTORequests;

namespace backend_autores.Services
{
    public interface ILoteProductoService
    {
        Task<LoteProducto> CreateLoteProducto(DTOLoteProducto req);
        
    }
    public class LoteProductoService
    {
        private readonly AppDbContext _db;

        public LoteProductoService( AppDbContext db)
        {
            _db = db;
        }

        public async Task<LoteProducto> CreateLoteProducto(DTOLoteProducto req)
        {
            var lote = new LoteProducto
            {
                Cantidad = req.Cantidad,
                ProductoId = req.ProductoId,
                PrecioCompra = req.PrecioCompra,
                FechaIngreso = req.FechaIngreso,
                ProveedorId = req.ProveedorId
            };
            _db.LoteProductos.Add(lote);
            await _db.SaveChangesAsync();
            return lote;
        }
    }
}