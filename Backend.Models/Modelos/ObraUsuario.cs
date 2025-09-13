using Backend.BD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class ObraUsuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ObraId { get; set; }
        public Obra Obra { get; set; }

        [Required]
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    } 
}
