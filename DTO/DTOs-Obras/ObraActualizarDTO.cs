using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Enums;

namespace Backend.DTO.DTOs_Obras
{
    public class ObraActualizarDTO 
    {
        public int Id { get; set; }
        public string NombreObra { get; set; }
        public string EstadoObra { get; set; }  
    }
}

