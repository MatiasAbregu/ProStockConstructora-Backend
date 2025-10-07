using Backend.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_MaterialesYmaquinarias
{
    public class MaterialYmaquinaVerDTO
    {
        public int Id { get; set; }

        public required string CodigoISO { get; set; }

        public required string Nombre { get; set; }

        public int? UnidadMedidaId { get; set; }

        public int Cantidad { get; set; }
    }
}
