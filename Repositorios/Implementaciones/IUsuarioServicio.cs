using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Models;
using Backend.DTO.DTOs_Usuarios;
using Microsoft.AspNetCore.Identity;

namespace Backend.Repositorios.Implementaciones
{
    public interface IUsuarioServicio
    {
        // GETs
        public Task<(bool, List<VerAdministradorDTO>)> ObtenerTodosLosAdministradores();
        public Task<List<Usuario>> ObtenerTodosLosAdministradoresDeEmpresa(string nombreEmpresa);
        public Task<(bool, List<VerUsuarioDTO>)> ObtenerUsuariosPorEmpresaId(int id);
        public Task<List<Usuario>> ObtenerUsuariosPorCategoria(); // Obra o Rol
        public Task<Usuario> ObtenerUsuarioPorNombreUsuario();

        // POSTs
        public Task<IdentityResult> CrearUsuario(CrearUsuarioDTO usuario);

        // PUTs
        public Task<string> ActualizarUsuario(int id, Usuario usuario);

        // DELETEs
        public Task<string> DesactivarUsuario();
    }
}
