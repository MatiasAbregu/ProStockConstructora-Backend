using Backend.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_MaterialesYmaquinarias
{
    public class MaterialYmaquinaCargarAdepositoDTO
    {
        public int DepositoId { get; set; }
        public int MaterialYmaquinaId { get; set; }
        public EnumTipoMaterialoMaquina Tipo { get; set; }
        public string CodigoISO { get; set; }
        public int Cantidad { get; set; }
    }
}
