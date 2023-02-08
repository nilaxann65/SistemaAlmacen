using Data.Models;
using Helpers;

namespace Data
{
    public class ProductoRepository
    {
        private readonly AlmacenContext _context;
        public ProductoRepository(AlmacenContext context)
        {
            _context = context;
        }

        public void Add(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }
        
        public Producto Get(int id)
        {
            return _context.Productos
                .Where(producto => producto.estado == Estado.Activo)
                .FirstOrDefault(producto => producto.idProducto == id);
        }

        public IEnumerable<Producto> Get(int limit, int page)
        {
            return _context.Productos
                .Skip(page)
                .Take(limit)
                .ToList()
                .Where(producto => producto.estado == Estado.Activo);
        }
        public void Update(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }
        public void Delete(Producto producto)
        {
            _context.Productos.Remove(producto);
            _context.SaveChanges();
        }
    }
}
