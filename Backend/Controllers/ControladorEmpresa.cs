using Backend.BD.Modelos;
using Backend.DTO.DTOs_Empresas;
using Backend.Repositorios.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/empresa")]
    [ApiController]
    public class ControladorEmpresa : ControllerBase
    {
        private readonly IEmpresaServicio empresaServicio;

        public ControladorEmpresa(IEmpresaServicio empresaServicio) 
        { 
            this.empresaServicio = empresaServicio;
        }

        [HttpGet("obtener-empresas")]
        public async Task<ActionResult<List<VerEmpresaDTO>>> ObtenerEmpresas()
        {
            ValueTuple<bool, List<VerEmpresaDTO>> res = await empresaServicio.ObtenerEmpresas();

            if(res.Item1) return StatusCode(200, res.Item2);
            else return StatusCode(500, "Error al cargar los datos desde el servidor.");
        }

        [HttpGet("obtener-empresa/{id}")]
        public async Task<ActionResult<VerEmpresaDTO>> ObtenerEmpresaPorId([FromRoute] int id)
        {
            ValueTuple<bool, VerEmpresaDTO> res = await empresaServicio.ObtenerEmpresaPorId(id);

            if (res.Item1 && res.Item2 != null) return StatusCode(200, res.Item2);
            else if (res.Item1 && res.Item2 == null) return StatusCode(404, res.Item2);
            else return StatusCode(500, res.Item2);
        }

        [HttpPost("crear")]
        public async Task<ActionResult<string>> CrearEmpresa(Empresa e)
        {
            ValueTuple<bool, string> res = await empresaServicio.CrearEmpresa(e);

            if (res.Item1) return StatusCode(201, res.Item2);
            else if (res.Item2.Contains("más tarde.")) return StatusCode(500, res.Item2);
            else if (res.Item2.Contains("CUIT")) return StatusCode(409, res.Item2);
            else return StatusCode(400, res.Item2);
        }

    }
}
