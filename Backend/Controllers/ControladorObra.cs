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

    }
}
