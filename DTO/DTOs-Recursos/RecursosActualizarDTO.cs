using Backend.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_MaterialesYmaquinarias
{
    public class RecursosActualizarDTO
    {
        public int DepositoId { get; set; }
        public int MaterialesyMaquinasId { get; set; }
        public EnumTipoMaterialoMaquina Tipo { get; set; }
        public int? UnidadMedidaId { get; set; }
        public int Cantidad { get; set; }
    }
}
