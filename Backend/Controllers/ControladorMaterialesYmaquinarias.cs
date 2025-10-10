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
using Backend.DTO.DTOs_MaterialesYmaquinarias;



namespace Backend.Controllers
{
    [Route("api/materialesYmaquinarias")]
    [ApiController]

    public class ControladorMaterialesYmaquinarias : ControllerBase
    {
        private readonly AppDbContext baseDeDatos;
        private readonly IMaterialesYmaquinariasServicio materialYMaquinariaServicio;

        public ControladorMaterialesYmaquinarias(AppDbContext baseDeDatos, IMaterialesYmaquinariasServicio materialYMaquinariaServicio)
        {
            this.baseDeDatos = baseDeDatos;
            this.materialYMaquinariaServicio = materialYMaquinariaServicio;
        }

        [HttpGet("ObtenerMaterialesYmaquinarias/{EmpresaId}")]
        public async Task<IActionResult> ObtenerMaterialesYmaquinarias(int EmpresaId)
        {
            ValueTuple<bool, List<MaterialYmaquinaVerDTO>>
            resultado = await materialYMaquinariaServicio.MaterialYmaquinaVerDTO(EmpresaId);
            if (!resultado.Item1)
                return StatusCode(500, "Error al obtener los materiales y maquinarias.");
            else if (resultado.Item2 == null || resultado.Item2.Count == 0)
                return StatusCode(200, "No hay materiales y maquinarias registradas.");
            return Ok(resultado.Item2);
        }

        [HttpGet("ObtenerMaterialesYmaquinariasDeposito/{DepositoId}")]
        public async Task<IActionResult> ObtenerMaterialesYmaquinariasDeposito(int DepositoId)
        {
            var materialesYmaquinarias = await baseDeDatos.MaterialesyMaquinas
                .Where(m => m.DepositoId == DepositoId)
                .Select(m => new MaterialYmaquinaVerDTO
                {
                    DepositoId = m.DepositoId,
                    CodigoISO = m.CodigoISO,
                    Tipo = m.Tipo,
                    TipoMaterial = m.TipoMaterial,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion,
                    Cantidad = m.Cantidad,
                    UnidadMedidaId = m.UnidadMedidaId
                })
                .ToListAsync();
            if (materialesYmaquinarias == null || materialesYmaquinarias.Count == 0)
                return StatusCode(200, "No hay materiales y maquinarias registradas en este depósito.");
            return Ok(materialesYmaquinarias);
        }
    }
}
