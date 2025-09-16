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
            }
            catch (Exception ex)
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

        public async Task<(bool, List<VerUsuarioDTO>)> ObtenerUsuariosPorEmpresaId(int id)
        {
            List<Usuario> usuariosBBDD = await baseDeDatos.Usuarios.Where(u => u.EmpresaId == id)
                                            .ToListAsync();

            if (usuariosBBDD.Count == 0) return (false, null);

            List<VerUsuarioDTO> usuarios = new List<VerUsuarioDTO>();

            foreach (var usuario in usuariosBBDD)
            {
                var roles = await gestorUsuarios.GetRolesAsync(usuario);

                usuarios.Add(new VerUsuarioDTO()
                {
                    Id = usuario.Id,
                    NombreUsuario = usuario.UserName,
                    Estado = usuario.Estado ? "Activo" : "Desactivado",
                    Email = usuario.Email,
                    Telefono = usuario.PhoneNumber,
                    Roles = roles.ToList()
                });
            }

            return (true, usuarios);
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
            using var transaction = await baseDeDatos.Database.BeginTransactionAsync();

            Usuario UsuarioBD = new(usuario.NombreUsuario, usuario.EmpresaId, usuario.Email, usuario.Celular);
            IdentityResult resultado = await gestorUsuarios.CreateAsync(UsuarioBD, usuario.Contrasena);

            if (resultado.Succeeded)
            {
                resultado = await gestorUsuarios.AddToRolesAsync(UsuarioBD, usuario.Roles);
                if (!resultado.Succeeded)
                {
                    await transaction.RollbackAsync();
                }
            }
            else
            {
                foreach (IdentityError error in resultado.Errors)
                {
                    Debug.WriteLine(error.Description);
                }
                await transaction.RollbackAsync();
            }
            await transaction.CommitAsync();
            return resultado;
        }

        public async Task<(bool, string, Usuario)> ActualizarUsuario(string id, ActualizarUsuarioDTO usuario)
        {
            Usuario? usuarioBBDD = await gestorUsuarios.FindByIdAsync(id);

            using var transaction = await baseDeDatos.Database.BeginTransactionAsync();

            if (usuarioBBDD == null) return (false, "El usuario que se desea actualizar no existe", null);

            if (!string.IsNullOrEmpty(usuario.NombreUsuario))
                usuarioBBDD.UserName = usuario.NombreUsuario;

            if (!string.IsNullOrEmpty(usuario.Celular))
                usuarioBBDD.PhoneNumber = usuario.Celular;

            if (!string.IsNullOrEmpty(usuario.Email))
                usuarioBBDD.Email = usuario.Email;

            IdentityResult res;

            if (usuario.Roles.Count > 0)
            {
                var rolesActuales = await gestorUsuarios.GetRolesAsync(usuarioBBDD);
                var rolesAEliminar = rolesActuales.Except(usuario.Roles).ToList();
                var rolesAAnadir = usuario.Roles.Except(rolesActuales).ToList();

                if (rolesAEliminar.Count > 0)
                {
                    res = await gestorUsuarios.RemoveFromRolesAsync(usuarioBBDD, rolesAEliminar);
                    if (!res.Succeeded)
                    {
                        await transaction.RollbackAsync();
                        return (false, "Error al eliminar roles", null);
                    }
                }

                if (rolesAAnadir.Count > 0)
                {
                    res = await gestorUsuarios.AddToRolesAsync(usuarioBBDD, rolesAAnadir);
                    if (!res.Succeeded)
                    {
                        await transaction.RollbackAsync();
                        return (false, "Error al añadir roles", null);
                    }
                }
            }

            res = await gestorUsuarios.UpdateAsync(usuarioBBDD);
            if (!res.Succeeded) await transaction.RollbackAsync();

            await transaction.CommitAsync();
            return (true, "Usuario actualizado con éxito", usuarioBBDD);
        }

        public async Task<(bool, string)> DesactivarUsuario(string id)
        {
            Usuario? usuarioBBDD = await gestorUsuarios.FindByIdAsync(id);

            if (usuarioBBDD == null) return (false, "El usuario que se desea desactivar no existe");

            usuarioBBDD.Estado = false;

            var res = await gestorUsuarios.UpdateAsync(usuarioBBDD);

            if (!res.Succeeded) return (false, "Ocurrio un error al desactivar el usuario");
            return (true, "Usuario desactivado con éxito");
        }
    }
}
