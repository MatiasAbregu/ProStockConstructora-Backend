using Backend.BD.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Obras
{
    public class VerObraConDepositoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int DepositoId { get; set; }
        public string TipoDeposito { get; set; }
    }
}
