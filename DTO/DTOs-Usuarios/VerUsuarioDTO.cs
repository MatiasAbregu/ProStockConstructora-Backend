﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Usuarios
{
    public class VerUsuarioDTO
    {
        public string Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }

        public List<string> Roles { get; set; }
    }
}
