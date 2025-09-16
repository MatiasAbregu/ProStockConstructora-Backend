using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DTO.Enum;

namespace Backend.DTO.DTOs_Obras
{
    public class ObraAsociarDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public required string NombreObra { get; set; }
        public EnumEstadoObra EstadoObra { get; set; } = EnumEstadoObra.EnProceso;
    }
}
