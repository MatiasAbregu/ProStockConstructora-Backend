﻿using Backend.DTO.DTOs_MaterialesYmaquinarias;
using Backend.DTO.DTOs_Recursos;

namespace Backend.Repositorios.Implementaciones
{
    public interface IRecursosServicio
    {
        Task<(bool, string)> RecursoCargar(RecursosCargarDTO recursoDTO, int DepositoId);
        Task<(bool, string)> RecursosTransladarAdeposito(RecursosTransladarDepositoDTO RecursosTransladarDepositoDTO);
        Task<(bool, List<RecursosPagPrincipalDTO>)> RecursosVerDTO(int empresaId);
        Task<(bool, List<RecursosVerDepositoDTO>)> RecursosVerDepositoDTO(int depositoId);
        Task<(bool, string)> RecursosActualizarStock(RecursosActualizarDTO recursoActualizarDTO, int depositoId);
        Task<(bool, RecursoStockVerDTO)> ObtenerRecursoPorStockId(int stockId);
        Task<(bool, string)> RecursoEliminarStock(int stockId);
    }
}