using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Modelos;
using Backend.DTO.DTOs_Empresas;

namespace Backend.Repositorios.Implementaciones
{
    public interface IEmpresaServicio
    {
        public Task<(bool res, List<VerEmpresaDTO>)> ObtenerEmpresas();
        public Task<(bool res, VerEmpresaDTO)> ObtenerEmpresaPorId(int id);
        public Task<(bool res, string msg)> CrearEmpresa(Empresa e);
        public Task<string> ActualizarEmpresa();
        public Task<string> EliminarEmpresa();
    }
}
