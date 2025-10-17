using Backend.DTO.DTOs_MaterialesYmaquinarias;

namespace Backend.Repositorios.Implementaciones
{
    public interface IRecursosServicio
    {
        Task<(bool, string)> RecursoCargar(RecursosCargarDTO recursoDTO);
        Task<(bool, string)> RecursosCargarAdeposito(RecursosCargarAdepositoDTO RecursosCargarAdepositoDTO);
        Task<(bool, string)> RecursosTransladarAdeposito(RecursosTransladarDepositoDTO RecursosTransladarDepositoDTO);
        Task<(bool, List<RecursosPagPrincipalDTO>)> RecursosVerDTO(int empresaId);
        Task<(bool, List<RecursosVerDepositoDTO>)> RecursosVerDepositoDTO(int depositoId);
    }
}