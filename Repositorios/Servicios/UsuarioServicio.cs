using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD;
using Backend.BD.Models;
using Backend.DTO.DTOs_Usuarios;
using Backend.Repositorios.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositorios.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly AppDbContext baseDeDatos;
        private readonly UserManager<Usuario> gestorUsuarios;

        public UsuarioServicio(AppDbContext baseDeDatos, UserManager<Usuario> gestorUsuarios)
        {
            this.baseDeDatos = baseDeDatos;
            this.gestorUsuarios = gestorUsuarios;
        }

        public async Task<(bool, List<VerAdministradorDTO>)> ObtenerTodosLosAdministradores()
        {
            try
            {
                List<string> AdminIDs = (await gestorUsuarios.GetUsersInRoleAsync("Administrador")).Select(u => u.Id).ToList();
                List<string> SuperAdminIDs =
                    (await gestorUsuarios.GetUsersInRoleAsync("Superadministrador")).Select(u => u.Id).ToList();
                List<string> TodosLosIds = AdminIDs.Union(SuperAdminIDs).ToList();

                List<VerAdministradorDTO> usuarios = [];

                foreach (Usuario u in
                    baseDeDatos.Usuarios.Where(u => TodosLosIds.Contains(u.Id)).Include(u => u.Empresa).ToList())
                {
                    usuarios.Add(new VerAdministradorDTO()
                    {
                        Id = u.Id,
                        NombreUsuario = u.UserName,
                        Email = u.Email,
                        Telefono = u.PhoneNumber,
                        Estado = u.Estado ? "Activo" : "Inactivo",
                        EmpresaId = u.EmpresaId,
                        NombreEmpresa = u.Empresa.NombreEmpresa
                    }
                    );
                }

                return (true, usuarios);
            } catch(Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return (false, null);
            }
        }

        public async Task<List<Usuario>> ObtenerTodosLosAdministradoresDeEmpresa(string nombreEmpresa)
        {
            return await baseDeDatos.Usuarios.Include(u => u.Empresa)
                .Where(u => u.Empresa.NombreEmpresa == nombreEmpresa).ToListAsync();
        }

        public Task<List<Usuario>> ObtenerUsuariosPorEmpresa()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObtenerUsuarioPorNombreUsuario()
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> ObtenerUsuariosPorCategoria()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CrearUsuario(CrearUsuarioDTO usuario)
        {
            Usuario UsuarioBD = new(usuario.NombreUsuario, usuario.EmpresaId, usuario.Email, usuario.Celular);
            IdentityResult resultado = await gestorUsuarios.CreateAsync(UsuarioBD, usuario.Contrasena);

            if (resultado.Succeeded) resultado = await gestorUsuarios.AddToRoleAsync(UsuarioBD, usuario.Rol);
            else
            {
                foreach (IdentityError error in resultado.Errors)
                {
                    Debug.WriteLine(error.Description);
                }
            }
            return resultado;
        }

        public Task<string> ActualizarUsuario(int id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<string> DesactivarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
