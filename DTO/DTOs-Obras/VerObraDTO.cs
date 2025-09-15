using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Obras
{
    public class VerObraDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public required string Nombre { get; set; }
        public required string Estado { get; set; }
    }
}
