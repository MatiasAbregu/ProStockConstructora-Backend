using Backend.BD.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_NotaDePedido
{
    public class CrearNotaDePedidoDTO
    {
        public string NumeroNotaPedido { get; set; } 
        public int DepositoDestinoId { get; set; }
        public DateTime FechaEmision { get; set; }
        public EstadoNotaPedido Estado { get; set; } = EstadoNotaPedido.Pendiente;
        public string UsuarioId { get; set; }

        public List<DetalleNotaDePedidoDTO> ListaDePedido { get; set; }
    }
}
