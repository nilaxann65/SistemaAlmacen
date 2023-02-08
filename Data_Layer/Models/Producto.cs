using Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public Estado estado { get; set; }
        [Required]
        public int idCategoria { get; set; }

        [ForeignKey("idCategoria")]
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Producto_Venta> Productos_Venta { get; set; }
    }
}
