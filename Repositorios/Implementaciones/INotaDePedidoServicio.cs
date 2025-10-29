using Backend.DTO.DTOs_NotaDePedido;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface INotaDePedidoServicio
    {
        Task<(bool,string)> ActualizarNotaDePedido(ActualizarNotaDePedidoDTO actualizarNotaDePedidoDTO,int notaPedidoId);
        Task<(bool, string)> CrearNotaDePedido(CrearNotaDePedidoDTO nuevaNotaDePedidoDTO);
        Task<(bool,string)> EliminarNotaDePedido(int id);
        Task<VerNotaDePedidoDTO?> ObtenerNotaDePedidoPorId(string NumeroNotaPedido);
        Task<List<VerNotaDePedidoDTO>> ObtenerNotasDePedido(int DepositoId);
    }
}
