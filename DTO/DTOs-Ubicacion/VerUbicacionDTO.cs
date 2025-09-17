using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Ubicacion
{
    public class VerUbicacionDTO 
    {
        public int Id { get; set; }
        public string CodigoUbicacion { get; set; }
        public string UbicacionDomicilio { get; set; }
        public string Provincia { get; set; }

    }
}
