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
        public string CodigoDeposito { get; set; }
        public string NombreDeposito { get; set; }
        public string TipoDeposito { get; set; }
        public string Ubicacion { get; set; }
        public string Provincia { get; set; }
    }
}
