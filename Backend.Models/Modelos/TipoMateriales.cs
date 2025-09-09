using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    
    public class TipoMateriales
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}
