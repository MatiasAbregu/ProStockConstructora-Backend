using Backend.DTO.DTOs_Usuarios;
using Backend.Repositorios.Implementaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorAuth : ControllerBase
    {

        private readonly IAuthServicio authServicio;

        public ControladorAuth(IAuthServicio authServicio) 
        {
            this.authServicio = authServicio;
        }

        [HttpPost("iniciar-sesion")]
        public async Task<ActionResult> IniciarSesion(InicioSesionDTO inicioSesionDTO)
        {
            ValueTuple<bool, string, TokenDTO> res = await authServicio.IniciarSesion(inicioSesionDTO);

            if (res.Item1 == false) return StatusCode(409, res.Item2);
            else if (res.Item1 == true && res.Item3 == null) return StatusCode(409, res.Item2);
            else return StatusCode(200, res.Item3);
        }

        [HttpPost("nuevo-token")]
        public async Task<ActionResult> SolicitarNuevoToken()
        {
            throw new NotImplementedException();
        }

        [HttpPost("cerrar-sesion")]
        public async Task<ActionResult> CerrarSesion()
        {
            throw new NotImplementedException();
        }
    }
}
