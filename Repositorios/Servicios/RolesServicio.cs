using Backend.BD;
using Backend.Repositorios.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Servicios
{
    public class RolesServicio : IRolesServicio
    {
        private readonly AppDbContext baseDeDatos;
        private readonly RoleManager<IdentityRole> gestorRoles;

        public RolesServicio(AppDbContext baseDeDatos, RoleManager<IdentityRole> gestorRoles)
        {
            this.baseDeDatos = baseDeDatos;
            this.gestorRoles = gestorRoles;
        }

        public (bool, List<IdentityRole>) ObtenerRoles()
        {
            var rolesListado = gestorRoles.Roles.Where(r => r.NormalizedName != "SUPERADMINISTRADOR").ToList();
            if (rolesListado == null || rolesListado.Count == 0)
            {
                return (false, null);
            } else return (true, rolesListado);
        }
    }
}
