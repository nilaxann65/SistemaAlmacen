using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Producto_Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProducto_Venta { get; set; }
        [Required]
        public int id_Venta { get; set; }
        [Required]
        public int id_Producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }

        [ForeignKey("id_Venta")]
        public Venta Venta { get; set; }
        
        [ForeignKey("id_Producto")]
        public Producto Producto { get; set; }
    }
}
