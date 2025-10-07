using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DTO.Enum;

namespace Backend.DTO.DTOs_MaterialesYmaquinarias
{
    public class MaterialYmaquinaCargarDTO
    {
        public string CodigoISO { get; set; }
        public EnumTipoMaterialoMaquina Tipo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int? TipoMaterial { get; set; }
        public int? UnidadMedidaId { get; set; }
        public string? Descripcion { get; set; }
    }
}
