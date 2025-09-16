using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Backend.BD;
using Backend.BD.Modelos;
using Backend.BD.Models;
using Backend.DTO.DTOs_Usuarios;
using Backend.Repositorios.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Repositorios.Servicios
{
    public class TokenServicio : ITokenServicio
    {
        private readonly IConfiguration _configuracion;
        private readonly SymmetricSecurityKey llave;
        private readonly UserManager<Usuario> gestorUsuario;
        private readonly AppDbContext baseDeDatos;

        public TokenServicio(IConfiguration configuracion, UserManager<Usuario> gestorUsuario, AppDbContext baseDeDatos)
        {
            _configuracion = configuracion;
            llave =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuracion["JWT:Clave"]));
            this.gestorUsuario = gestorUsuario;
            this.baseDeDatos = baseDeDatos;
        }

        public async Task<TokenDTO> GenerarNuevosTokens(Usuario usuario, bool mantenerSesion)
        {
            IList<string> roles = await gestorUsuario.GetRolesAsync(usuario);

            List<Claim> claims = [new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                                  new Claim(ClaimTypes.GivenName, usuario.UserName)];

            foreach (string rol in roles) claims.Add(new Claim(ClaimTypes.Role, rol));

            SigningCredentials credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken token = new JwtSecurityToken(
                                     expires: mantenerSesion ?
                                     DateTime.UtcNow.AddMinutes(30) : DateTime.UtcNow.AddDays(7),
                                     claims: claims,
                                     signingCredentials: credenciales,
                                     issuer: _configuracion["JWT:FirmaDelBackend"]);

            string refreshToken = "";
            if (mantenerSesion)
            {
                refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

                var TokenViejo = await baseDeDatos.RefreshTokens.FirstOrDefaultAsync(t => t.UsuarioId == usuario.Id);
                if (TokenViejo != null) baseDeDatos.RefreshTokens.Remove(TokenViejo);

                baseDeDatos.RefreshTokens.Add(new BD.Modelos.Tokens()
                {
                    Token = BCrypt.Net.BCrypt.HashPassword(refreshToken),
                    UsuarioId = usuario.Id,
                    CreadoEn = DateTime.UtcNow,
                    VenceEn = DateTime.UtcNow.AddDays(3)
                });

                await baseDeDatos.SaveChangesAsync();
            }

            return new TokenDTO()
            {
                Mensaje = "¡Tokens generados con éxito!",
                JWTToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
            };
        }

        public async Task<TokenDTO> ValidarRefreshToken(TokenDTO token, string usuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> InvalidarTokens(string UsuarioId, string RefreshToken)
        {
            Usuario? usuarioBBDD = await
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
