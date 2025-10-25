using Backend.BD.Modelos;
using Backend.DTO.DTOs_Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface IPedidosServicio
    {
        Task<(bool, string)> ActualizarEstadoPedido();
        Task<(bool, string)> CrearRemito(CrearRemitoDTO crearRemitoDTO);
        Task<(bool, string)> CrearNotaDePedido(CrearNotaDePedidoDTO crearNotaDePedidoDTO);
        Task<(bool, List<DetalleNotaDePedidoDTO>)> ObtenerDetallesNotaDePedido(int DetalleNotaDePedidoId);
        Task<(bool, List<DetalleRemitosDTO>)> ObtenerDetallesDeRemitos(int RemitoId);
    }
}
