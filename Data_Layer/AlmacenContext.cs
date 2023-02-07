using Data;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer
{
    public class AlmacenContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto_Venta> Producto_Ventas { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        public AlmacenContext(DbContextOptions<AlmacenContext> options) 
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto_Venta>()
                .HasOne(b => b.Venta)
                .WithMany(b => b.Productos_Venta)
                .HasForeignKey(b => b.id_Venta);
            
            modelBuilder.Entity<Producto_Venta>()
                .HasOne(b => b.Producto)
                .WithMany(b => b.Productos_Venta)
                .HasForeignKey(b => b.id_Producto);
        }
    }
}