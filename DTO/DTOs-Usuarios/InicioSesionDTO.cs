using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Usuarios
{
    /// <summary> 
    /// DTO que cuenta con los datos necesarios para iniciar sesión y generar un token de acuerdo
    /// a si desea mantener la sesión activa o no. 
    /// </summary>
    public class InicioSesionDTO
    {
        /// <summary> Nombre de usuario del que desea iniciar sesión. </summary>
        [Required]
        public string NombreUsuario { get; set; }

        /// <summary> Contraseña correspondiente al usuario. </summary>
        [Required]
        public string Contrasena { get; set; }

        /// <summary> Indica si el usuario desea mantener la sesión iniciada. </summary>
        public bool MantenerSesion { get; set; }
    }
}
