using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class NotadePedido
    {
        [Key]

        public int IdNotaPedido { get; set; }

        public required string NumeroNotaPedido { get; set; }

        public int IdObra { get; set; }

        public int IdDeposito { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaEstimadaEntrega { get; set; }

        public string Estado { get; set; }

      
    }

}
