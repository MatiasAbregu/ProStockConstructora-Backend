using Backend.DTO.DTOs_MaterialesYmaquinarias;

namespace Backend.Repositorios.Implementaciones
{
    public interface IMaterialesYmaquinariasServicio
    {
        Task<(bool, string)> MaterialYmaquinaCargar(MaterialYmaquinaCargarDTO materialYmaquinaDTO);
        Task<(bool, string)> MaterialYmaquinaCargarAdeposito(MaterialYmaquinaCargarAdepositoDTO materialYmaquinaCargarAdepositoDTO);
        Task<(bool, string)> MaterialYmaquinaTransladarDeposito(MaterialYmaquinaTransladarDepositoDTO materialYmaquinaTransladarDepositoDTO);
        Task<(bool, List<MaterialYmaquinaVerDTO>)> MaterialYmaquinaVerDTO(int empresaId);
    }
}