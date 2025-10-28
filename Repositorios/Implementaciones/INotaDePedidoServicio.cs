using Backend.DTO.DTOs_NotaDePedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface INotaDePedidoServicio
    {
        Task<bool> ActualizarNotaDePedido(int id, CrearNotaDePedidoDTO notaDePedidoActualizadaDTO);
        Task<bool> CrearNotaDePedido(CrearNotaDePedidoDTO nuevaNotaDePedidoDTO);
        Task<bool> EliminarNotaDePedido(int id);
        Task<VerNotaDePedidoDTO?> ObtenerNotaDePedidoPorCodigo(string NumeroNotaPedido);
        Task<List<VerNotaDePedidoDTO>> ObtenerNotasDePedido(string NumeroNotaPedido);
    }
}
