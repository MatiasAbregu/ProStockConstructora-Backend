using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Backend.BD.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.BD.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        public bool Estado { get; set; }

        [Required]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        public RefreshToken RefreshToken { get; set; }

        public Usuario() { }

        public Usuario(string nombreUsuario, int empresaId, string email, string telefono, bool estado = true)
        {
            UserName = nombreUsuario;
            EmpresaId = empresaId;
            Email = email;
            PhoneNumber = telefono;
            Estado = estado;

            EmailConfirmed = false;
            PhoneNumberConfirmed = false;
            TwoFactorEnabled = false;
            LockoutEnabled = false;
            AccessFailedCount = 0;
        }
    }
}