using Backend.BD;
using Backend.BD.Modelos;
using Backend.Repositorios.Implementaciones;
using Backend.Repositorios.Servicios;
using Backend.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Backend.DTOs;
using Backend.BD.Enums;
//using Backend.DTO.DTOs_Recursos;
using Backend.DTO.DTOs_MaterialesYmaquinarias;

namespace Backend.Controllers
{
    [Route("api/recursos")]
    [ApiController]

    public class ControladorRecursos : ControllerBase
    {
        private readonly AppDbContext baseDeDatos;
        private readonly IRecursosServicio recursosServicio;

        public ControladorRecursos(AppDbContext baseDeDatos, IRecursosServicio recursosServicio)
        {
            this.baseDeDatos = baseDeDatos;
            this.recursosServicio = recursosServicio;
        }

        //[HttpGet("Obtenerrecursos/{EmpresaId}")]
        //public async Task<IActionResult> ObtenerRecursos(int EmpresaId)
        //{
        //   ValueTuple<bool, List<RecursosVerDTO>>
        //   resultado = await recursosServicio.RecursosVerDTO();
        //    if (!resultado.Item1)
        //        return StatusCode(500, "Error al obtener los materiales y maquinarias.");
        //    else if (resultado.Item2 == null || resultado.Item2.Count == 0)
        //        return StatusCode(200, "No hay materiales y maquinarias registradas en la empresa.");
        //    return Ok(resultado.Item2);
        //}

 

        [HttpGet("deposito/{DepositoId}")]
        public async Task<IActionResult> ObtenerRecursos(int DepositoId)
        {
            ValueTuple<bool, List<RecursosVerDepositoDTO>>
            resultado = await recursosServicio.RecursosVerDepositoDTO(DepositoId);
            if (!resultado.Item1)
                return StatusCode(500, "Error al obtener los materiales y maquinarias.");
            else if (resultado.Item2 == null || resultado.Item2.Count == 0)
                return StatusCode(200, "No hay materiales y maquinarias registradas en la empresa.");
            return Ok(resultado.Item2);
        }

        [HttpPost]
        public async Task<IActionResult> RecursosCargarAdeposito([FromBody] RecursosCargarAdepositoDTO recursosCargarAdepositoDTO)
        {
            if (recursosCargarAdepositoDTO == null)
                return BadRequest("El recurso no puede ser nulo.");
            var exito = await recursosServicio.RecursosCargarAdeposito(recursosCargarAdepositoDTO);

            if (!exito.Item1)
                return StatusCode(500, exito.Item2);
            return Ok("Recurso cargado al deposito con exito.");
        }

        [HttpPut("deposito/movimiento")]
        public async Task<IActionResult> RecursosTransladarAdeposito([FromBody] RecursosTransladarDepositoDTO recursosTransladarAdepositoDTO)
        {
            if (recursosTransladarAdepositoDTO == null)
                return BadRequest("El recurso no puede ser nulo.");
            var exito = await recursosServicio.RecursosTransladarAdeposito(recursosTransladarAdepositoDTO);
            if (!exito.Item1)
                return StatusCode(500, "Error al trasladar el recurso al deposito.");
            return Ok( $"Recurso trasladado al deposito {recursosTransladarAdepositoDTO.DepositoDestinoId} con exito.");
        }
    }
}