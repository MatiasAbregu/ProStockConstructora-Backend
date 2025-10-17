using Backend.DTO.DTOs_Ubicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Depositos
{
    public class DepositoAsociarDTO
    {
        public int Id { get; set; }
        public string TipoDeposito { get; set; } = "Disponible";
        public int ObraId { get; set; }
        public UbicacionDTO Ubicacion { get; set; }
    }
}
