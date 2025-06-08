using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Usuarios
{
    /// <summary>
    /// DTO que encapsula el resultado del proceso de autenticación.
    /// Contiene un mensaje del estado de la autenticación, el token JWT y el refresh token, en caso de mantener la sesión.
    /// </summary>
    public class AutenticacionDTO
    {
        /// <summary> Contiene un mensaje del estado de la autenticación. </summary>
        public string Mensaje { get; set; }

        /// <summary> Contiene un JWT Token que puede ser null en caso de que la autenticación falle. </summary>
        public string? JWTToken { get; set; }

        /// <summary> 
        /// Contiene un RefreshToekn que puede ser null en caso de que la autenticación falle o el usuario
        /// no haya solicitado mantener la sesión iniciada. 
        /// </summary>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="AutenticacionDTO"/>.
        /// </summary>
        /// <param name="mensaje">Mensaje de estado de la autenticación.</param>
        /// <param name="jwtToken"> Token JWT.</param>
        /// <param name="refreshToken"> Token de refresco. </param>
        public AutenticacionDTO(string mensaje, string jwtToken = null, string refreshToken = null)
        {
            Mensaje = mensaje;
            JWTToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
