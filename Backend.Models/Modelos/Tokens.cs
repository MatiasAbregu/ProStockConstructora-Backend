using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Models;

namespace Backend.BD.Modelos
{
    public class Tokens
    {
        [Key]
        public int Id { get; set; }

        public required string Token { get; set; }

        public required string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        public required DateTime CreadoEn { get; set; }

        [Required]
        public required DateTime VenceEn { get; set; }

    }
}
