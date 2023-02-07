using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string contrasena { get; set; }
        public int id_TipoUsuario { get; set; }
        
        [ForeignKey("id_TipoUsuario")]
        public TipoUsuario TipoUsuario { get; set; }
    }
}
