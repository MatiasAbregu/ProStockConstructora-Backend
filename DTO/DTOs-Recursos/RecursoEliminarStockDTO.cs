using Backend.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Recursos
{
    public class RecursoEliminarStockDTO
    {
        public int StockId { get; set; }
        public string CodigoISO { get; set; }
        public string Nombre { get; set; }
        public EnumTipoMaterialoMaquina Tipo { get; set; }
        public string? TipoMaterial { get; set; }
        public string? UnidadMedida { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
    }
}
