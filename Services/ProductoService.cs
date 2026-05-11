using backend_autores.Models;
using backend_autores.Models.DTORequests;
using backend_autores.DB;
using System.Data.Entity;

namespace backend_autores.Services
{
    public interface IProductoService
    {
        Task<Producto> CreateProducto(DTOProductoCreate producto);
        Task<List<Producto>> getProductosByParams( DTOPRoductoParamsRequest Params);
        Task<Producto> updateProducto(DTOProductoCreate prodcuto, int Id);
    }
    public class ProductoService: IProductoService
    {
        private readonly AppDbContext _db;

        public ProductoService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Producto> CreateProducto(DTOProductoCreate req)
        {
            var prod = new Producto
            {
              categoriaId = req.categoriaId,
              Nombre = req.Nombre,
              Descripcion = req.Descripcion,
              Precio = req.Precio,
              ImagenUrl = req.ImagenUrl,
                proveedorId = req.proveedorId 
            };
            _db.Productos.Add(prod);
            await _db.SaveChangesAsync();
            return prod;
        }
        public async Task<Producto> updateProducto(DTOProductoCreate req, int Id)
        {
            var prod_update = await _db.Productos.FirstOrDefaultAsync(p => p.Id == Id);

              prod_update.categoriaId = req.categoriaId;
              prod_update.Nombre = req.Nombre;
              prod_update.Descripcion = req.Descripcion;
              prod_update.Precio = req.Precio;
              prod_update.ImagenUrl = req.ImagenUrl;
                prod_update.proveedorId = req.proveedorId; 

            await _db.SaveChangesAsync();
            return prod_update;
        }
        public async Task<List<Producto>> getProductosByParams( DTOPRoductoParamsRequest Params)
        {
             var productos = _db.Productos;

             if(Params.categoriaId!=null)
            {
                productos.Where(p=> p.categoriaId == Params.categoriaId);
            }
            if(Params.proveedorId != null)
            {
                productos.Where(p => p.proveedorId == Params.proveedorId);
            }

            if(Params.name != null)
            {
                productos.Where(p => p.Nombre.Contains(Params.name));
            }
            return await productos.ToListAsync();
        }
    } 
}