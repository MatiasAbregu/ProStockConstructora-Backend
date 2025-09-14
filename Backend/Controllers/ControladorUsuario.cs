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

        // EN DEUSO
        /*[HttpGet("obtener-administradores")]
        //public async Task<ActionResult<List<VerAdministradorDTO>>> ObtenerTodosLosAdministradores()
        //{
        //    ValueTuple<bool, List<VerAdministradorDTO>> res = await usuarioServicio.ObtenerTodosLosAdministradores();

        //    if (res.Item1) return StatusCode(200, res.Item2);
        //    else return StatusCode(500, "Error al cargar los datos desde el servidor.");
        //}
        */    

        [HttpGet("{id:int}")]
        public async Task<ActionResult> ObtenerUsuariosDeEmpresa(int id)
        {
            ValueTuple<bool, List<VerUsuarioDTO>> res = await usuarioServicio.ObtenerUsuariosPorEmpresaId(id);

            if (res.Item1) return StatusCode(200, res.Item2);
            return StatusCode(204, "Todavía no hay usuarios añadidos a la empresa.");
        }

        [HttpPost]
        public async Task<ActionResult> CrearUsuario(CrearUsuarioDTO usuario)
        {
            IdentityResult resultado = await usuarioServicio.CrearUsuario(usuario);

            if (resultado.Succeeded) return StatusCode(200, "¡Usuario creado con éxito!");
            else
            {
                string errores = "";
                foreach (IdentityError error in resultado.Errors)
                {
                    errores += error.Description + ", ";
                }
                return StatusCode(400, $"¡No se pudo crear el usuario! Errores: ${errores}");
            }
        }

        [HttpPut("{id:string}")]
        public async Task<ActionResult> ActualizarUsuario(string id, ActualizarUsuarioDTO usuario)
        {
            if (id != usuario.Id) return StatusCode(409, "Hubo un error al querer actualizar el usuario.");

            ValueTuple<bool, string, Usuario> res = await usuarioServicio.ActualizarUsuario(id, usuario);

            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<ActionResult> DesactivarUsuario(string id)
        {
            return Ok("Vamooos");
        }
    }
}