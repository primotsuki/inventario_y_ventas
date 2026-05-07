using Microsoft.EntityFrameworkCore;
using backend_autores.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace backend_autores.DB
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<LoteProducto> LoteProductos { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}