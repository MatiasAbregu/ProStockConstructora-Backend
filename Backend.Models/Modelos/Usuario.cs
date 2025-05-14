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
    [Index(nameof(NombreUsuario), IsUnique = true)]
    public class Usuario : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Nombre de usuario obligatorio.")]
        public string NombreUsuario { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(5, ErrorMessage = "La contraseña debe tener mínimo 6 caracteres.")]
        public string Contraseña { get; set; }
        
        [Required]
        public string Rol { get; set; } // Fijarse si no hay que implementar algo
        
        [Required]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        [Required]
        public int ContactoId { get; set; }
        public Contacto Contacto { get; set; }

        public string? Initials;
    }
}
