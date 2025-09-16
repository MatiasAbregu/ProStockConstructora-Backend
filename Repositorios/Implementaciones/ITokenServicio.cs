using Backend.BD.Models;
using Backend.DTO.DTOs_Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface ITokenServicio
    {
        Task<TokenDTO> GenerarNuevosTokens(Usuario usuario, bool mantenerSesion);
        Task<TokenDTO> ValidarRefreshToken(TokenDTO token, string usuarioId);
        Task<string> InvalidarTokens(string UsuarioId, string RefreshToken);
    }
}
