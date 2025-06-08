using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Models;

namespace Backend.BD.Modelos
{
    /// <summary>
    /// Entidad de token de refresco asociado a un usuario para mantener su sesión activa.
    /// </summary>
    public class RefreshToken
    {
        /// <summary> Identificador del token de refresco. </summary>
        [Key]
        public int Id { get; set; }

        /// <summary> Cadena del token que se usará para renovar el token JWT. </summary>
        [Required]
        public string Token { get; set; }

        /// <summary> Identificador del usuario al que pertenece este token. </summary>
        [Required]
        public string UsuarioId { get; set; }

        /// <summary> Referencia al usuario asociado a este token. </summary>
        public Usuario Usuario { get; set; }
    }
}
