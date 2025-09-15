using Backend.BD;
using Backend.BD.Modelos;
using Backend.Repositorios.Implementaciones;
using Backend.Repositorios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.BD.Enums;

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

        [HttpGet("ObtenerObrasConDeposito/{EmpresaId}")]
        public async Task<IActionResult> ObtenerObrasConDeposito(int EmpresaId)
        {
            ValueTuple<bool, List<DTO.DTOs_Obras.VerObraConDepositoDTO>> 
            resultado = await obraServicio.ObtenerObrasConDeposito(EmpresaId);
            if (!resultado.Item1)
            return StatusCode(500, "Error al obtener las obras con depósitos.");
            else if (resultado.Item2 == null || resultado.Item2.Count == 0)
            return StatusCode(204, "No hay obras con depósitos registrados.");
            return Ok(resultado.Item2);
        }

        [HttpPost("CrearObra")]
        public async Task<IActionResult> CrearObra([FromBody] DTO.DTOs_Obras.ObraAsociarDTO obraDTO)
        {
            try
            {
                bool empresaExiste = await baseDeDatos.Empresa.AnyAsync(e => e.Id == obraDTO.EmpresaId);
                if (!empresaExiste)
                    return BadRequest("La empresa asociada no existe.");

                if (await baseDeDatos.Obras.AnyAsync(o => o.NombreObra == obraDTO.NombreObra && o.EmpresaId == obraDTO.EmpresaId))
                    return Conflict("Ya existe una obra con el mismo nombre para esta empresa.");

                var nuevaObra = new Obra
                {
                    NombreObra = obraDTO.NombreObra,
                    EmpresaId = obraDTO.EmpresaId,
                    Estado = EnumEstadoObra.EnProceso
                };

                await baseDeDatos.Obras.AddAsync(nuevaObra);
                await baseDeDatos.SaveChangesAsync();

                return Ok(nuevaObra.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
                return StatusCode(500, "Error al crear la obra.");
            }
        }
    }
}
