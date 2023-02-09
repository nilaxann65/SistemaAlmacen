using Helpers;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class AlmacenContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto_Venta> Producto_Ventas { get; set; }

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

            //Seeders

            Categoria cat1 = new Categoria { idCategoria = 1, nombre = "Lacteos" };
            Categoria cat2 = new Categoria { idCategoria = 2, nombre = "Carnes" };
            modelBuilder.Entity<Categoria>().HasData(new Categoria[] { cat1, cat2 });

            Producto prod1 = new Producto { idProducto = 1, nombre = "Leche", idCategoria = 1, precio = 10, stock = 10, estado = Estado.Activo };
            Producto prod2 = new Producto { idProducto = 2, nombre = "Queso", idCategoria = 1, precio = 20, stock = 10, estado = Estado.Activo };
            Producto prod3 = new Producto { idProducto = 3, nombre = "Carne de res", idCategoria = 2, precio = 30, stock = 10, estado = Estado.Activo };
            Producto prod4 = new Producto { idProducto = 4, nombre = "Carne de cerdo", idCategoria = 2, precio = 40, stock = 10, estado = Estado.Activo };
            modelBuilder.Entity<Producto>().HasData(new Producto[] { prod1, prod2, prod3, prod4 });
        }
    }
}