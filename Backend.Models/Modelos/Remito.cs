using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Remito
    {
        [Key]
        public int IdRemito { get; set; }

        public required string NumeroRemito { get; set; }

        public int IdObraEmisor { get; set; }

        public int IdDepositoReceptor { get; set; }

        public int IdTransportista { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaEntrega { get; set; }

        public string Estado { get; set; }

    }
}

