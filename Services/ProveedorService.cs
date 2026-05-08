using System.Data.Entity;
using backend_autores.DB;
using backend_autores.Models;
using backend_autores.Models.DTORequests;
namespace backend_autores.Services
{
    public interface IProveedorService
    {
        Task<Proveedor> CreateProducto(DTOProveedorCreate proveedor);
        Task<List<Proveedor>> getProveedoresByName(string name);
        Task<Proveedor> updateProveedor(int provId, DTOProveedorCreate proveedor);
    }

    public class ProveedorService: IProveedorService
    {
        private readonly AppDbContext _db;

        public ProveedorService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Proveedor> CreateProducto(DTOProveedorCreate proveedor)
        {
            var prov = new Proveedor()
            {
                Nombre = proveedor.nombre,
                Contacto = proveedor.contacto,
                Telefono = proveedor.telefono
            };

            _db.Proveedores.Add(prov);
            await _db.SaveChangesAsync();
            return prov;
        }
        public async Task<List<Proveedor>> getProveedoresByName(string name)
        {
            if (name.Length <= 3 || name == null)
            {
                return await _db.Proveedores.ToListAsync();
            } else
            {
                return await _db.Proveedores
                        .Where(p=> p.Nombre.Contains(name))
                        .ToListAsync();
            }
        }
        public async Task<Proveedor> updateProveedor(int proveId, DTOProveedorCreate proveedor)
        {
            var prov_update = await _db.Proveedores.FirstOrDefaultAsync(p=>p.Id == proveId);
            if (prov_update != null)
            {
                prov_update.Nombre = proveedor.nombre;
                prov_update.Contacto = proveedor.contacto;
                prov_update.Telefono = proveedor.telefono;
                await _db.SaveChangesAsync();
            }
            return null;
        }
    }
}