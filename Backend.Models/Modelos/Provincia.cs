using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Provincia
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nombre de provincia obligatorio.")]
        [Column(TypeName = "varchar(80)")]
        public string Nombre { get; set; }
    }
}
