using Backend.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_MaterialesYmaquinarias
{
    public class RecursosVerDTO
    {
        public int RecursosId { get; set; }
        public string CodigoISO { get; set; }
        public EnumTipoMaterialoMaquina Tipo { get; set; }
        public string? TipoMaterial { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? UnidadMedidaId { get; set; }    
    }
}
