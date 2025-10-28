using Backend.BD;
using Backend.BD.Modelos;
using Backend.DTO.DTOs_NotaDePedido;
using Backend.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Servicios
{
    public class NotaDePedidoServicio : INotaDePedidoServicio
    {
        private readonly AppDbContext context;
        private readonly INotaDePedidoServicio notaDePedidoServicio;

        public NotaDePedidoServicio(AppDbContext context, INotaDePedidoServicio notaDePedidoServicio)
        {
            this.context = context;
            this.notaDePedidoServicio = notaDePedidoServicio;
        }

        public async Task<List<VerNotaDePedidoDTO>> ObtenerNotasDePedido(string NumeroNotaPedido)
        {
            var notasDePedido = await context.NotaDePedidos.ToListAsync();
            var notasDePedidoDTOs = notasDePedido.Select(np => new VerNotaDePedidoDTO
            {
                NumeroNotaPedido = np.NumeroNotaPedido,
                Material = np.Material,
                Cantidad = np.Cantidad,
                DepositoDestinoId = np.DepositoDestinoId,
                FechaEmision = np.FechaEmision,
                Estado = np.Estado
            }).ToList();
            return notasDePedidoDTOs;


        }
        public async Task<VerNotaDePedidoDTO?> ObtenerNotaDePedidoPorCodigo(string NumeroNotaPedido)
        {
            var notaDePedido = await context.NotaDePedidos
                .FirstOrDefaultAsync(np => np.NumeroNotaPedido == NumeroNotaPedido);
            if (notaDePedido == null)
            {
                return null;
            }
            return new VerNotaDePedidoDTO
            {
                NumeroNotaPedido = notaDePedido.NumeroNotaPedido,
                Material = notaDePedido.Material,
                Cantidad = notaDePedido.Cantidad,
                DepositoDestinoId = notaDePedido.DepositoDestinoId,
                FechaEmision = notaDePedido.FechaEmision,
                Estado = notaDePedido.Estado
            };

            
        }

        public async Task<bool> CrearNotaDePedido(CrearNotaDePedidoDTO nuevaNotaDePedidoDTO)
        {
            var existeNumero = await context.NotaDePedidos
                .AnyAsync(np => np.NumeroNotaPedido == nuevaNotaDePedidoDTO.NumeroNotaPedido);
            if (existeNumero)
            {
                return false;
            }
            var nuevaNotaDePedido = new NotaDePedido
            {
                NumeroNotaPedido = nuevaNotaDePedidoDTO.NumeroNotaPedido,
                Material = nuevaNotaDePedidoDTO.Material,
                Cantidad = nuevaNotaDePedidoDTO.Cantidad,
                DepositoDestinoId = nuevaNotaDePedidoDTO.DepositoDestinoId,
                FechaEmision = nuevaNotaDePedidoDTO.FechaEmision,
                Estado = nuevaNotaDePedidoDTO.Estado, 
                UsuarioId = nuevaNotaDePedidoDTO.UsuarioId
            };
            await context.NotaDePedidos.AddAsync(nuevaNotaDePedido);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ActualizarNotaDePedido(int id, CrearNotaDePedidoDTO notaDePedidoActualizadaDTO)
        {
            var notaDePedidoExistente = await context.NotaDePedidos
                .FirstOrDefaultAsync(np => np.Id == id);
            if (notaDePedidoExistente == null)
            {
                return false;
            }
            notaDePedidoExistente.NumeroNotaPedido = notaDePedidoActualizadaDTO.NumeroNotaPedido;
            notaDePedidoExistente.Material = notaDePedidoActualizadaDTO.Material;
            notaDePedidoExistente.Cantidad = notaDePedidoActualizadaDTO.Cantidad;
            notaDePedidoExistente.DepositoDestinoId = notaDePedidoActualizadaDTO.DepositoDestinoId;
            notaDePedidoExistente.FechaEmision = notaDePedidoActualizadaDTO.FechaEmision;
            notaDePedidoExistente.Estado = notaDePedidoActualizadaDTO.Estado;
            notaDePedidoExistente.UsuarioId = notaDePedidoActualizadaDTO.UsuarioId;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EliminarNotaDePedido(int id)
        {
            var notaDePedidoExistente = await context.NotaDePedidos
                .FirstOrDefaultAsync(np => np.Id == id);
            if (notaDePedidoExistente == null)
            {
                return false;
            }
            context.NotaDePedidos.Remove(notaDePedidoExistente);
            await context.SaveChangesAsync();
            return true;
        }


    }

}
