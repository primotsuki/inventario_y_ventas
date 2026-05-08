using System.Data.Entity;
using backend_autores.DB;
using backend_autores.Models;
using backend_autores.Models.DTORequests;
namespace backend_autores.Services
{
    public interface ICategoriaService
    {
        Task<Categoria> CreateCategoria(DTOCategoriacreate cat);
        Task<List<Categoria>> getCategoriaByName(string name);
        Task<Categoria> updateCategoria(int catId, DTOCategoriacreate categoria);
    }
    public class CategoriaService: ICategoriaService
    {
        private readonly AppDbContext _db;

        public CategoriaService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Categoria> CreateCategoria(DTOCategoriacreate cat)
        {
            var categoria = new Categoria
            {
                Nombre = cat.name
            };
            _db.Categorias.Add(categoria);
            await _db.SaveChangesAsync();
            return categoria;
        }

        public async Task<List<Categoria>> getCategoriaByName(string name)
        {
            if (name.Length <= 3 || name == null)
            {
                return await _db.Categorias.ToListAsync();
            } else
            {
                return await _db.Categorias
                        .Where(p=> p.Nombre.Contains(name))
                        .ToListAsync();
            }
        }
        public async Task<Categoria> updateCategoria(int catId, DTOCategoriacreate categoria)
        {
            var cat_update = await _db.Categorias.FirstOrDefaultAsync(p=>p.Id == catId);
            if (cat_update != null)
            {
                cat_update.Nombre = categoria.name;
                await _db.SaveChangesAsync();
            }
            return null;
        }
    }
}