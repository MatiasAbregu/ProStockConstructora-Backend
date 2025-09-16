<<<<<<< HEAD

using Backend.BD.Enums;
using Backend.BD.Modelos;
using Backend.BD.Models;
using Backend.DTO.DTOs_Obras;
using Backend.Repositorios.Implementaciones;
using Backend.Repositorios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/obra")]
    [ApiController]

    public class ControladorObra : ControllerBase // Herencia
    {


        private readonly IObraServicio _obraRepository;


        // Inyección de dependencias
        public ControladorObra(IObraServicio obraRepository) //Nombre del constructor
        {
            _obraRepository = obraRepository;
        }

        // Metodo GET

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrearObraDTO>>> GetAll()
        {
            var obras = await _obraRepository.GetAllAsync();


            var obrasDto = obras.Select(o => new CrearObraDTO
            {

                NombreObra = o.NombreObra,
                EmpresaId = o.EmpresaId
            });

            return Ok(obrasDto);
        }

        // Metodo GET por ID....

        [HttpGet("{id}")]
        public async Task<ActionResult<CrearObraDTO>> GetById(int id)
        {
            var obra = await _obraRepository.GetByIdAsync(id);
            if (obra == null)
                return NotFound();

            var obraDto = new CrearObraDTO
            {

                NombreObra = obra.NombreObra,
                EmpresaId = obra.EmpresaId
            };

            return Ok(obraDto);
        }

        // Metodo POST

        [HttpPost]
        public async Task<ActionResult<CrearObraDTO>> Create(CrearObraDTO dto)
        {

            var obra = new Obra
            {
                NombreObra = dto.NombreObra,
                EmpresaId = dto.EmpresaId
            };

            var nuevaObra = await _obraRepository.AddAsync(obra);


            var obraDto = new CrearObraDTO
            {
                NombreObra = nuevaObra.NombreObra,
                EmpresaId = nuevaObra.EmpresaId
            };

            return CreatedAtAction(nameof(GetById), new { id = obraDto.EmpresaId }, obraDto);
        }


        // Metodo PUT para actualizar

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateObraDTO dto)
        {
            var obraExistente = await _obraRepository.GetByIdAsync(id);
            if (obraExistente == null)
                return NotFound();



            obraExistente.NombreObra = dto.NombreObra;
            obraExistente.Estado = Enum.Parse<EnumEstadoObra>(dto.Estado);

            await _obraRepository.UpdateAsync(obraExistente);

            return NoContent();
        }


        // Metodo DELETE para Borrar

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obra = await _obraRepository.GetByIdAsync(id);
            if (obra == null)
                return NotFound();

            await _obraRepository.DeleteAsync(id);

            return NoContent();
        }
=======
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
>>>>>>> 61a143f6eb6acf07acc6b77b23501739ec2f77d5
>>>>>>> 663eef808fed5a37aef38a6a91997ba93347bb1b
    }
}

//    public class ControladorObra : ControllerBase
//    {
//        private readonly AppDbContext baseDeDatos;
//        private readonly IObraServicio obraServicio;

//        public ControladorObra(AppDbContext baseDeDatos, IObraServicio obraServicio)
//        {
//            this.baseDeDatos = baseDeDatos;
//            this.obraServicio = obraServicio;
//        }
//        [HttpGet("ObtenerObras/{EmpresaId}")]
//        public async Task<IActionResult> ObtenerObras(int EmpresaId)
//        {
//            ValueTuple<bool, List<DTO.DTOs_Obras.VerObraDTO>> 
//            resultado = await obraServicio.ObtenerObras(EmpresaId);
//            if (!resultado.Item1)
//            return StatusCode(500, "Error al obtener las obras.");
//            else if (resultado.Item2 == null || resultado.Item2.Count == 0)
//            return StatusCode(204, "No hay obras registradas.");
//            return Ok(resultado.Item2);
//        }

//        [HttpGet("ObtenerObraPorId/{id}")]
//        public async Task<IActionResult> ObtenerObraPorId(int id)
//        {
//            ValueTuple<bool, DTO.DTOs_Obras.VerObraDTO> 
//            resultado = await obraServicio.ObtenerObraPorId(id);
//            if (!resultado.Item1)
//            return StatusCode(500, "Error al obtener la obra.");
//            else if (resultado.Item2 == null)
//            return StatusCode(204, "No existe la obra con el ID proporcionado.");
//            return Ok(resultado.Item2);
//        }

//        [HttpGet("ObtenerObrasConDeposito/{EmpresaId}")]
//        public async Task<IActionResult> ObtenerObrasConDeposito(int EmpresaId)
//        {
//            ValueTuple<bool, List<DTO.DTOs_Obras.VerObraConDepositoDTO>> 
//            resultado = await obraServicio.ObtenerObrasConDeposito(EmpresaId);
//            if (!resultado.Item1)
//            return StatusCode(500, "Error al obtener las obras con depósitos.");
//            else if (resultado.Item2 == null || resultado.Item2.Count == 0)
//            return StatusCode(204, "No hay obras con depósitos registrados.");
//            return Ok(resultado.Item2);
//        }

//        [HttpPost("CrearObra")]
//        public async Task<IActionResult> CrearObra([FromBody] DTO.DTOs_Obras.ObraAsociarDTO obraDTO)
//        {
//            try
//            {
//                bool empresaExiste = await baseDeDatos.Empresa.AnyAsync(e => e.Id == obraDTO.EmpresaId);
//                if (!empresaExiste)
//                    return BadRequest("La empresa asociada no existe.");

//                if (await baseDeDatos.Obras.AnyAsync(o => o.NombreObra == obraDTO.NombreObra && o.EmpresaId == obraDTO.EmpresaId))
//                    return Conflict("Ya existe una obra con el mismo nombre para esta empresa.");

//                var nuevaObra = new Obra
//                {
//                    NombreObra = obraDTO.NombreObra,
//                    EmpresaId = obraDTO.EmpresaId,
//                    Estado = EnumEstadoObra.EnProceso
//                };

//                await baseDeDatos.Obras.AddAsync(nuevaObra);
//                await baseDeDatos.SaveChangesAsync();

//                return Ok(nuevaObra.Id);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
//                return StatusCode(500, "Error al crear la obra.");
//            }
//        }
//    }
//}