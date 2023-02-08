using Data.Models;
using Helpers;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProductoModel : IValidatableObject
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public Estado estado { get; set; }
        public int idCategoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (precio == 0 || idCategoria < 1)
                yield return new ValidationResult("Datos Invalidos");
        }

        public static Producto operator +(Producto producto, ProductoModel productoModel)
        {
            producto.idProducto = productoModel.idProducto;
            producto.nombre = productoModel.nombre;
            producto.precio = productoModel.precio;
            producto.stock = productoModel.stock;
            producto.estado = productoModel.estado;
            producto.idCategoria = productoModel.idCategoria;
            return producto;
        }
        public static ProductoModel operator +(ProductoModel productoModel, Producto producto)
        {
            productoModel.idProducto = producto.idProducto;
            productoModel.nombre = producto.nombre;
            productoModel.precio = producto.precio;
            productoModel.stock = producto.stock;
            productoModel.estado = producto.estado;
            productoModel.idCategoria = producto.idCategoria;
            return productoModel;
        }
    }
}