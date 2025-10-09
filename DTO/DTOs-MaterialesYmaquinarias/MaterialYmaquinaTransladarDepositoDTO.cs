using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_MaterialesYmaquinarias
{
    public class MaterialYmaquinaTransladarDepositoDTO
    {
        public int DepositoOrigenId { get; set; }
        public int DepositoDestinoId { get; set; }
        public int MaterialYmaquinaId { get; set; }
        public string CodigoISO { get; set; }
        public int Cantidad { get; set; }
    }
}
