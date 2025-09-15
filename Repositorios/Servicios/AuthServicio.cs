using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD;
using Backend.BD.Modelos;
using Backend.BD.Models;
using Backend.DTO.DTOs_Usuarios;
using Backend.Repositorios.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositorios.Servicios
{
    public class AuthServicio : IAuthServicio
    {
        private readonly AppDbContext baseDeDatos;
        private readonly ITokenServicio tokenServicio;
        private readonly UserManager<Usuario> gestorUsuarios;

        public AuthServicio(AppDbContext baseDeDatos, ITokenServicio tokenServicio,
            UserManager<Usuario> gestorUsuarios)
        {
            this.baseDeDatos = baseDeDatos;
            this.tokenServicio = tokenServicio;
            this.gestorUsuarios = gestorUsuarios;
        }

        public async Task<ValueTuple<bool, string, TokenDTO>> IniciarSesion(InicioSesionDTO usuarioDTO)
        {
            Usuario? usuarioBBDD = await
                baseDeDatos.Usuarios.Include(u => u.RefreshToken).
                FirstOrDefaultAsync(u => u.UserName == usuarioDTO.NombreUsuario);

            if (usuarioBBDD == null) return (false, "El usuario no existe en el sistema", null);

            bool contrasenaIgual = await gestorUsuarios.CheckPasswordAsync(usuarioBBDD, usuarioDTO.Contrasena);
            if (!contrasenaIgual) return (true, "¡Usuario o contraseña incorrecto!", null);

            return (true, "¡Inicio de sesión exitoso!", 
                await tokenServicio.GenerarNuevosTokens(usuarioBBDD, usuarioDTO.MantenerSesion));
        }

        public async Task<string> CerrarSesion(string UsuarioId, string RefreshToken)
        {
            throw new NotImplementedException();
        }
    }
}