using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_MaterialesYmaquinarias
{
    public class MaterialYmaquinaActualizarDTO
    {
        public int DepositoId { get; set; }
        public int? UnidadMedidaId { get; set; }
        public int Cantidad { get; set; }
    }
}
