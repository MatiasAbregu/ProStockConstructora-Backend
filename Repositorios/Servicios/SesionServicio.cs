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
    public class SesionServicio : ISesionServicio
    {
        private readonly AppDbContext baseDeDatos;
        private readonly ITokenServicio tokenServicio;
        private readonly UserManager<Usuario> gestorUsuarios;

        public SesionServicio(AppDbContext baseDeDatos, ITokenServicio tokenServicio, 
            UserManager<Usuario> gestorUsuarios)
        {
            this.baseDeDatos = baseDeDatos;
            this.tokenServicio = tokenServicio;
            this.gestorUsuarios = gestorUsuarios;
        }

        public async Task<AutenticacionDTO> IniciarSesion(InicioSesionDTO usuarioDTO)
        {
            Usuario usuarioBBDD = await
                baseDeDatos.Usuarios.Include(u => u.RefreshToken).
                FirstOrDefaultAsync(u => u.UserName == usuarioDTO.NombreUsuario);

            if (usuarioBBDD == null) return new AutenticacionDTO("El usuario no está registrado.");
            else
            {
                bool contrasenaIgual = await gestorUsuarios.CheckPasswordAsync(usuarioBBDD, usuarioDTO.Contrasena);

                if (!contrasenaIgual) return new AutenticacionDTO("¡Usuario o contraseña incorrecto!");
                else
                {
                    RefreshToken refreshToken = null;
                    if (usuarioDTO.MantenerSesion)
                    {
                        refreshToken = new RefreshToken() 
                        { 
                            UsuarioId = usuarioBBDD.Id,
                            Token = tokenServicio.CrearRefreshToken(),
                        };
                        baseDeDatos.RefreshTokens.Add(refreshToken);
                        await baseDeDatos.SaveChangesAsync();
                    }

                    return new AutenticacionDTO(
                    "¡Inicio de sesión éxitoso!", 
                    await tokenServicio.CrearJWTToken(usuarioBBDD, usuarioDTO.MantenerSesion),
                    refreshToken?.Token);
                }
            }
        }

        public async Task<string> CerrarSesion(string UsuarioId, string RefreshToken)
        {
            Usuario usuarioBBDD = await
                baseDeDatos.Usuarios.Include(u => u.RefreshToken).
                FirstOrDefaultAsync(u => u.Id == UsuarioId);

            if (usuarioBBDD == null) return "El usuario con ese ID no existe";
            
            if (usuarioBBDD.RefreshToken != null)
            {
                if (usuarioBBDD.RefreshToken.Token != RefreshToken) 
                    return "Es muy feo de su parte intentar cerrar la sesión de otros.";

                baseDeDatos.RefreshTokens.Remove(usuarioBBDD.RefreshToken);
                await baseDeDatos.SaveChangesAsync();
            }

            return "¡Sesión cerrada con éxito!";
        }
    }
}