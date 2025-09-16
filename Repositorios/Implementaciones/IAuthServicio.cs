using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DTO.DTOs_Usuarios;

namespace Backend.Repositorios.Implementaciones
{
    public interface IAuthServicio
    {
        public Task<ValueTuple<bool, string, TokenDTO>> IniciarSesion(InicioSesionDTO usuarioDTO);
        public Task<ValueTuple<bool, string, TokenDTO>> SolicitarNuevoToken();
        public Task<string> CerrarSesion(string UsuarioId, string RefreshToken);
    }
}