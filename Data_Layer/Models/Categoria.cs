using Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCategoria { get; set; }
        public string nombre { get; set; }
        public Estado estado { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
