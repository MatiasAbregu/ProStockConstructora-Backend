using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface IRolesServicio
    {
        public (bool, List<IdentityRole>) ObtenerRoles();
    }
}
