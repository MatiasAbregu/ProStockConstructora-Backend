using Backend.BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class ObraXUsuario
    {
        public int Id { get; set; } 
        public int ObraId { get; set; }
        public Obra Obra { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } // Navigation property to Usuario
        public ObraXUsuario() { }
        public ObraXUsuario(int obraId, int usuarioId) 
        { 
            ObraId = obraId;
            UsuarioId = usuarioId;
        }
    }
}
