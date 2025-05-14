using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Models;

namespace Backend.BD.Modelos
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(80)")]
        [Required(ErrorMessage = "El celular es obligatorio.")]
        public string Celular { get; set; }

        [EmailAddress(ErrorMessage = "El email no es válido.")]
        [Column(TypeName = "varchar(120)")]
        [Required(ErrorMessage = "El email es obligatorio.")]
        public string Email { get; set; }

        public Empresa Empresa { get; set; }
        public Usuario Usuario { get; set; }
    }
}
