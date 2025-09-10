using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Ubicacion
    {
        [Key]
        public int Id { get; set; }
        public string CodigoUbicacion { get; set; }
        public string Domicilio { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }

    }
}
