using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class VentaModel
    {
        public int idVenta { get; set; }
        public DateTime fecha { get; set; }
        public decimal tazas { get; set; }
        public decimal total { get; set; }

        public static VentaModel operator +(VentaModel ventaModel, Venta venta)
        {
            ventaModel.idVenta = venta.idVenta;
            ventaModel.fecha = venta.fecha;
            ventaModel.tazas = venta.tazas;
            ventaModel.total = venta.total;
            return ventaModel;
        }

        public static Venta operator +(Venta venta, VentaModel ventaModel)
        {
            venta.idVenta = ventaModel.idVenta;
            venta.fecha = ventaModel.fecha;
            venta.tazas = ventaModel.tazas;
            venta.total = ventaModel.total;
            return venta;
        }
    }

    public class Producto_VentaDTO : IValidatableObject
    {
        [Required]
        public int id_Producto { get; set; }
        [Required]
        public int cantidad { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (cantidad <= 0 || id_Producto <= 0)
            {
                yield return new ValidationResult("Formato de dato invalido");
            }
        }
    }
    
    public class VentaDTO : IValidatableObject
    {
        [Required]
        public List<Producto_VentaDTO> Productos { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Productos == null || Productos.Count == 0)
            {
                yield return new ValidationResult("No se ha seleccionado ningun producto", new[] { "Productos" });
            }
        }
    }
}
