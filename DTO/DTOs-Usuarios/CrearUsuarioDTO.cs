using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Usuarios
{
    public class CrearUsuarioDTO
    {
        public string NombreUsuario { get; set; }
        public string Contrasena {  get; set; }
        public List<string> Roles { get; set; }
        public int EmpresaId { get; set; }
        public string? Email { get; set; } = null;
        public string? Celular { get; set; } = null;
 
    }
}
