using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DTO.DTOs_Recursos;
using Backend.DTO.Enum;

namespace Backend.DTO.DTOs_MaterialesYmaquinarias
{
    public class RecursosCargarDTO
    {
        public string CodigoISO { get; set; }
        public EnumTipoMaterialoMaquina Tipo { get; set; }
        public string Nombre { get; set; }
        public TipoMaterialDTO TipoMaterial { get; set; }
        public UnidadDeMedidaDTO UnidadDeMedida { get; set; }
        public string? Descripcion { get; set; }
    }
}
