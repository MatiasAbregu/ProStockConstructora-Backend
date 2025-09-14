using Backend.BD;
using Backend.BD.Modelos;
using Backend.Repositorios.Implementaciones;
using Backend.Repositorios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("ObtenerObras/{EmpresaId}")]
        public async Task<IActionResult> ObtenerObras(int EmpresaId)
        {
            ValueTuple<bool, List<DTO.DTOs_Obras.VerObraDTO>> 
            resultado = await obraServicio.ObtenerObras(EmpresaId);
            if (!resultado.Item1)
            return StatusCode(500, "Error al obtener las obras.");
            else if (resultado.Item2 == null || resultado.Item2.Count == 0)
            return StatusCode(204, "No hay obras registradas.");
            return Ok(resultado.Item2);
        }

        [HttpGet("ObtenerObraPorId/{id}")]
        public async Task<IActionResult> ObtenerObraPorId(int id)
        {
            ValueTuple<bool, DTO.DTOs_Obras.VerObraDTO> 
            resultado = await obraServicio.ObtenerObraPorId(id);
            if (!resultado.Item1)
            return StatusCode(500, "Error al obtener la obra.");
            else if (resultado.Item2 == null)
            return StatusCode(204, "No existe la obra con el ID proporcionado.");
            return Ok(resultado.Item2);
        }

    }
}
