using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Deposito
    {
        public int Id { get; set; }

        public string? TipoDeposito { get; set; }

        public int ObraId { get; set; }
    }
}