using Backend.BD.Enums;
using Backend.BD.Modelos;
using Backend.DTO.DTOs_Obras;
using Backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface IObraServicio
    {
        Task<(bool, string)> CrearObra(CrearObraDTO obraDTO);
        Task<(bool, string)> ActualizarEstadoObra(int id, EnumEstadoObra nuevoEstado);
        Task<(bool, string)> ActualizarObra(int id, ObraActualizarDTO o);
        Task<(bool, VerObraDTO)> ObtenerObraPorId(int id);
        Task<(bool, List<VerObraDTO>)> ObtenerObras(int EmpresaId);
        Task<(bool, List<VerObraConDepositoDTO>)> ObtenerObrasConDeposito(int EmpresaId);
    }
}


