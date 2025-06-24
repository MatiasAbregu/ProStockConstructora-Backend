using System.Diagnostics;
using Backend.BD.Models;
using Backend.DTO.DTOs_Usuarios;
using Backend.Repositorios.Implementaciones;
using Backend.Repositorios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class ControladorUsuario : ControllerBase
    {
        private readonly IUsuarioServicio usuarioServicio;

        public ControladorUsuario(IUsuarioServicio usuarioServicio) 
        {
            this.usuarioServicio = usuarioServicio;
        }

        [HttpGet("obtener-administradores")]
        public async Task<ActionResult<List<VerAdministradorDTO>>> ObtenerTodosLosAdministradores()
        {
            ValueTuple<bool, List<VerAdministradorDTO>> res = await usuarioServicio.ObtenerTodosLosAdministradores();

            if (res.Item1) return StatusCode(200, res.Item2);
            else return StatusCode(500, "Error al cargar los datos desde el servidor.");
        }

        [HttpPost("crear-administrador")]
        public async Task<ActionResult<string>> CrearUsuario([FromBody] CrearUsuarioDTO usuario)
        {
            IdentityResult resultado = await usuarioServicio.CrearUsuario(usuario);

            if (resultado.Succeeded) return Ok("¡Usuario creado con éxito!");
            else
            {
                string errores = "";
                foreach (IdentityError error in resultado.Errors)
                {
                    errores += error.Description + ", ";
                }
                return BadRequest("¡No se pudo crear el usuario!");
            }
            
        }

        //[HttpGet("iniciar-sesion")]
        //public string Hola()
        //{
        //    return "hola";
        //}
    }
}
