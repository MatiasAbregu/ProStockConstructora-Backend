using Backend.BD.Enums;
using Backend.BD.Modelos;
using Backend.DTO.DTOs_Obras;

namespace Backend.Repositorios.Implementaciones
{
    public interface IObraServicio
    {
        Task<(bool, string)> ActualizarEstadoObra(int id, EnumEstadoObra nuevoEstado);
        Task<(bool, string)> ActualizarObra(int id, Obra o);
        Task<(bool, string)> CrearObra(ObraAsociarDTO obraDTO);
        Task<(bool, VerObraDTO)> ObtenerObraPorId(int id);
        Task<(bool, List<VerObraDTO>)> ObtenerObras(int EmpresaId);
        Task<(bool, List<VerObraConDepositoDTO>)> ObtenerObrasConDeposito(int EmpresaId);
    }
}