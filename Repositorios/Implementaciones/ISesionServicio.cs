using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DTO.DTOs_Usuarios;

namespace Backend.Repositorios.Implementaciones
{
    public interface ISesionServicio
    {
        public Task<AutenticacionDTO> IniciarSesion(InicioSesionDTO usuario);
        public Task<string> CerrarSesion(string UsuarioId, string RefreshToken);
    }
}
