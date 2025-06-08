using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Models;
using Backend.Repositorios.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Repositorios.Servicios
{
    public class TokenServicio : ITokenServicio
    {
        private readonly IConfiguration _configuracion;
        private readonly SymmetricSecurityKey llave;
        private readonly UserManager<Usuario> gestorUsuario;

        public TokenServicio(IConfiguration configuracion, UserManager<Usuario> gestorUsuario)
        {
            _configuracion = configuracion;
            llave = 
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuracion["JWT:Clave"]));
            this.gestorUsuario = gestorUsuario;
        }

        public async Task<string> CrearJWTToken(Usuario usuario, bool mantenerSesion)
        {
            IList<string> roles = await gestorUsuario.GetRolesAsync(usuario);

            List<Claim> claims = [new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                                  new Claim(ClaimTypes.GivenName, usuario.UserName)];

            foreach(string rol in roles) claims.Add(new Claim(ClaimTypes.Role, rol));

            SigningCredentials credenciales = new SigningCredentials(llave, 
                                                SecurityAlgorithms.HmacSha512);

            JwtSecurityToken token = new JwtSecurityToken(
                                     expires: mantenerSesion ? 
                                     DateTime.UtcNow.AddMinutes(15) : DateTime.UtcNow.AddDays(7),
                                     claims: claims,
                                     signingCredentials: credenciales,
                                     issuer: _configuracion["JWT:FirmaDelBackend"]);

            return new JwtSecurityTokenHandler().WriteToken(token);         
        }

        public string CrearRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
