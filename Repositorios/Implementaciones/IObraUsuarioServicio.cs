﻿using Backend.DTO.DTOs_Obras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface IObraUsuarioServicio
    {
        Task<(bool, string)> AsignarUsuarioAObra(ObraAsociarUsuarioDTO ObraUsuarioDTO);
        Task<(bool, string)> RemoverUsuarioDeObra(int obraId, string usuarioId);
        Task<(bool, List<string>)> ObtenerUsuariosDeObra(int obraId);
        Task<(bool, List<int>)> ObtenerObrasConUsuario(string usuarioId);
    }
}
