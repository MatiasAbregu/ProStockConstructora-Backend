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
        public string MaterialoMaquinaNombre { get; set; }
        public string? UnidadMedida { get; set; }
        public int Cantidad { get; set; }
    }
}
