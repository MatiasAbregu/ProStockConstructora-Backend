using Backend.BD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/nota-de-pedido")]

    public class ControladorNotaDePedido : ControllerBase
    {
        private readonly AppDbContext baseDeDatos;

        public ControladorNotaDePedido(AppDbContext BaseDeDatos )
        {
            baseDeDatos = BaseDeDatos;
        }
        [HttpGet("obtener-notaspedidos")]
        public async Task<ActionResult> ObtenerNotasDePedido()
        {
           var notaPedidos = await baseDeDatos.NotaDePedidos.ToListAsync();
            if (notaPedidos == null || notaPedidos.Count == 0)
            {
                return StatusCode(200, "No hay notas de pedido registradas.");
            }
            return Ok(notaPedidos);
        }
        [HttpGet("obtener-notaspedidos/{id}")]
        public async Task<ActionResult> ObtenerNotaDePedidoPorId([FromRoute] int id)
        {
            var notaPedido = await baseDeDatos.NotaDePedidos.FirstOrDefaultAsync(np => np.Id == id);
            if (notaPedido == null)
            {
                return StatusCode(404, "No existe una nota de pedido con ese ID.");
            }
            return Ok(notaPedido);
        }
        [HttpPost("crear-notapedido")]
        public async Task<ActionResult> CrearNotaDePedido([FromBody] BD.Modelos.NotaDePedido nuevaNotaDePedido)
        {
            try
            {
                bool existeNumero = await baseDeDatos.NotaDePedidos.AnyAsync(np => np.NumeroNotaPedido == nuevaNotaDePedido.NumeroNotaPedido);
                if (existeNumero)
                {
                    return StatusCode(400, "Ya existe una nota de pedido con ese número.");
                }
                await baseDeDatos.NotaDePedidos.AddAsync(nuevaNotaDePedido);
                await baseDeDatos.SaveChangesAsync();
                return Ok(nuevaNotaDePedido);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al crear la nota de pedido.");
            }
        }
        [HttpPut("actualizar-notapedido/{id}")]
        public async Task<ActionResult> ActualizarNotaDePedido([FromRoute] int id, [FromBody] BD.Modelos.NotaDePedido notaDePedidoActualizada)
        {
            try
            {
                var notaDePedidoExistente = await baseDeDatos.NotaDePedidos.FirstOrDefaultAsync(np => np.Id == id);
                if (notaDePedidoExistente == null)
                {
                    return StatusCode(404, "No existe una nota de pedido con ese ID.");
                }
                // Actualizar los campos necesarios
                notaDePedidoExistente.NumeroNotaPedido = notaDePedidoActualizada.NumeroNotaPedido;
                notaDePedidoExistente.Material = notaDePedidoActualizada.Material;
                notaDePedidoExistente.Cantidad = notaDePedidoActualizada.Cantidad;
                notaDePedidoExistente.DepositoDestinoId = notaDePedidoActualizada.DepositoDestinoId;
                notaDePedidoExistente.FechaEmision = notaDePedidoActualizada.FechaEmision;
                notaDePedidoExistente.Estado = notaDePedidoActualizada.Estado;
                await baseDeDatos.SaveChangesAsync();
                return Ok(notaDePedidoExistente);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al actualizar la nota de pedido.");
            }
            

        }
        [HttpDelete("eliminar-notapedido/{id}")]
        public async Task<ActionResult> EliminarNotaDePedido([FromRoute] int id)
        {
            try
            {
                var notaDePedidoExistente = await baseDeDatos.NotaDePedidos.FirstOrDefaultAsync(np => np.Id == id);
                if (notaDePedidoExistente == null)
                {
                    return StatusCode(404, "No existe una nota de pedido con ese ID.");
                }
                baseDeDatos.NotaDePedidos.Remove(notaDePedidoExistente);
                await baseDeDatos.SaveChangesAsync();
                return Ok("Nota de pedido eliminada exitosamente.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al eliminar la nota de pedido.");
            }

    
    }   }
}
