using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Deposito
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo del deposito es obligatorio.")]
        public string TipoDeposito { get; set; } = null!;

        [Required(ErrorMessage = "La obra del deposito es obligatorio.")]
        public int ObraId { get; set; }
        public Obra Obra { get; set; } = null!;

        [Required(ErrorMessage = "La ubicacion del deposito es obligatorio.")]
        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; } = null!;
    }
}