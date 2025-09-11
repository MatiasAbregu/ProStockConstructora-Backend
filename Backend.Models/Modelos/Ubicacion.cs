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

        [Required(ErrorMessage = "El codigo de ubicacion es obligatorio.")]
        public string CodigoUbicacion { get; set; } = null!;

        [Required(ErrorMessage = "El domicilio es obligatorio.")]
        public string Domicilio { get; set; } = null!;

        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; } = null!;
    }
}
