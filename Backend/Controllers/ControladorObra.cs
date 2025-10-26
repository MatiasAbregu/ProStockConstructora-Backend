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
using Backend.DTO.DTOs_Obras;

namespace Backend.Controllers
{
    [Route("api/obra")]
    [ApiController]

    public class ControladorObra : ControllerBase
    {
        private readonly AppDbContext baseDeDatos;
        private readonly IObraServicio obraServicio;

        public ControladorObra(AppDbContext baseDeDatos, IObraServicio obraServicio)
        {
            this.baseDeDatos = baseDeDatos;
            this.obraServicio = obraServicio;
        }
        [HttpGet("empresa/{EmpresaId:int}")]
        public async Task<IActionResult> ObtenerObras(int EmpresaId)
        {
            ValueTuple<bool, List<VerObraDTO>>
            resultado = await obraServicio.ObtenerObras(EmpresaId);
            if (!resultado.Item1)
                return StatusCode(500, "Error al obtener las obras.");
            else if (resultado.Item2 == null || resultado.Item2.Count == 0)
                return StatusCode(200, "No hay obras registradas.");
            return Ok(resultado.Item2);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerObraPorId(int id)
        {
            ValueTuple<bool, VerObraDTO>
            resultado = await obraServicio.ObtenerObraPorId(id);
            if (!resultado.Item1)
                return StatusCode(500, "Error al obtener la obra.");
            else if (resultado.Item2 == null)
                return StatusCode(200, "No existe la obra con el ID proporcionado.");
            return Ok(resultado.Item2);
        }

        //[HttpGet("ObtenerObrasConDeposito/{EmpresaId}")]
        //public async Task<IActionResult> ObtenerObrasConDeposito(int EmpresaId)
        //{
        //    ValueTuple<bool, List<DTO.DTOs_Obras.VerObraConDepositoDTO>>
        //    resultado = await obraServicio.ObtenerObrasConDeposito(EmpresaId);
        //    if (!resultado.Item1)
        //        return StatusCode(500, "Error al obtener las obras con depósitos.");
        //    else if (resultado.Item2 == null || resultado.Item2.Count == 0)
        //        return StatusCode(200, "No hay obras con depósitos registrados.");
        //    return Ok(resultado.Item2);
        //}

        [HttpPost]
        public async Task<IActionResult> CrearObra([FromBody] CrearObraDTO obraDTO)
        {
           ValueTuple<bool, string> resultado = await obraServicio.CrearObra(obraDTO);
            if (!resultado.Item1)
                return StatusCode(500, resultado.Item2);
            return Ok("Obra creada exitosamente.");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarObra(int id, [FromBody] ObraActualizarDTO obraDTO)
        {
            if (id != obraDTO.Id)
                return BadRequest("El ID de la obra no coincide.");
            ValueTuple<bool, string> resultado = await obraServicio.ActualizarObra(id, new ObraActualizarDTO
            {
                Id = obraDTO.Id,
                NombreObra = obraDTO.NombreObra,
                Estado = obraDTO.Estado,
            });
            if (!resultado.Item1)
                return StatusCode(500, resultado.Item2);
            return Ok("Obra actualizada exitosamente.");
        }

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> EliminarObra(int id)
        //{
        //    var obra = await baseDeDatos.Obras.FindAsync(id);
        //    if (obra == null)
        //        return NotFound("No se encontró la obra con el ID proporcionado.");
        //    baseDeDatos.Obras.Remove(obra);
        //    await baseDeDatos.SaveChangesAsync();
        //    return Ok("Obra eliminada exitosamente.");
        //}
    }
}
   


