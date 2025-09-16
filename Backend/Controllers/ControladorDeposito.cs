using Backend.BD;
using Backend.BD.Modelos;
using Backend.DTO.DTOs_Depositos;
using Backend.Repositorios.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/deposito")]

    public class ControladorDeposito : ControllerBase
    {
        private readonly IDepositoServicio depositoServicio;

        public ControladorDeposito(IDepositoServicio depositoServicio)
        {
            this.depositoServicio = depositoServicio;
        }
        [HttpGet("obtener-depositos")]
        public async Task<ActionResult<List<VerDepositoDTO>>> ObtenerDepositos()
        {
            var depositos= await depositoServicio.ObtenerDepositos();
            if (depositos.Item1) return StatusCode(200, depositos.Item2);
            else return StatusCode(500, "Error al cargar los datos desde el servidor.");

        }
        [HttpGet("obtener-depositos/{id}")]
        public async Task<ActionResult<VerDepositoDTO>> ObtenerDepositoPorId([FromRoute] int id)
        {
            ValueTuple<bool, VerDepositoDTO> res = await depositoServicio.ObtenerDepositoPorId(id);
            if (res.Item1 && res.Item2 != null) return StatusCode(200, res.Item2);
            else if (res.Item1 && res.Item2 == null) return StatusCode(404, "No existe un depósito con ese ID.");
            else return StatusCode(500, res.Item2);
        }
        [HttpPost("crear")]
        public async Task<ActionResult<string>> CrearDeposito([FromBody] DepositoAsociarDTO e)
        {
            ValueTuple<bool, string> res = await depositoServicio.CrearDeposito(e);
            if (res.Item1) return StatusCode(201, res.Item2);
            else if (res.Item2.Contains("ya existe")) return StatusCode(409, res.Item2);
            else return StatusCode(500, res.Item2);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<string>> ActualizarDeposito([FromRoute] int id, [FromBody] DepositoAsociarDTO e)
        {
            if (id != e.Id) return StatusCode(400, "No se pudo realizar la operación");
            ValueTuple<bool, string> res = await depositoServicio.ActualizarDeposito(e);
            if (res.Item1) return StatusCode(200, res.Item2);
            else if (res.Item2.Contains("ya existe")) return StatusCode(409, res.Item2);
            else return StatusCode(500, res.Item2);
        }
        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<string>> EliminarDeposito([FromRoute] int id)
        {
            ValueTuple<bool, string> res = await depositoServicio.EliminarDeposito(id);
            if (res.Item1) return StatusCode(200, res.Item2);
            else if (res.Item2.Contains("No existe")) return StatusCode(404, res.Item2);
            else return StatusCode(500, res.Item2);
        }

    }
}
