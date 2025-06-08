using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Models;

namespace Backend.Repositorios.Implementaciones
{
    public interface ITokenServicio
    {
        Task<string> CrearJWTToken(Usuario usuario, bool mantenerSesion);
        string CrearRefreshToken();
    }
}
