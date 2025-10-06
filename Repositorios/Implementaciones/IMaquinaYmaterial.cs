using Backend.DTO.DTOs_MaterialesYmaquinarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface IMaquinaYmaterial
    {
        public Task<(bool, List<MaterialYmaquinaVerDTO>)> ObtenerMaterialyMaquina();
        public Task<(bool, MaterialYmaquinaVerDTO)> ObtenerDepositoPorId(int id);
        public Task<(bool, string)> CrearDeposito(MaterialYmaquinaCargarDTO e);
        public Task<(bool, string)> ActualizarDeposito(MaterialYmaquinaActualizarDTO e);
        public Task<(bool, string)> EliminarDeposito(int id);

    }
}
