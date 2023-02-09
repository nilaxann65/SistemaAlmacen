using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idVenta { get; set; }
        public DateTime fecha { get; set; }
        public decimal tazas { get; set; }
        public decimal total { get; set; }

        public virtual ICollection<Producto_Venta> Productos_Venta { get; set; }
    }
}
