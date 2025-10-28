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
        Task<bool> CrearNotaDePedido(CrearNotaDePedidoDTO nuevaNotaDePedidoDTO);
        Task<VerNotaDePedidoDTO?> ObtenerNotaDePedidoPorCodigo(string NumeroNotaPedido);
        Task<List<VerNotaDePedidoDTO>> ObtenerNotasDePedido(string NumeroNotaPedido);
    }
}
