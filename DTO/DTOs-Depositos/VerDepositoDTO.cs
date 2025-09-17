using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Depositos
{
    public class VerDepositoDTO
    {
        public int Id { get; set; }
        public string TipoDeposito { get; set; }
        public int ObraId { get; set; }
        public string NombreObra { get; set; }
        public int UbicacionId { get; set; }
<<<<<<< HEAD
        public string Ubicacion { get; set; }

=======
        public string NombreUbicacion { get; set; }
>>>>>>> 32b618a0e3c5866bcc78fa1f1c224cc266fbf03b
    }
}
