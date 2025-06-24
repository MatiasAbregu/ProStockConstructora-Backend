using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Models;

namespace Backend.BD.Modelos
{
    public class Obra
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string NombreObra { get; set; }
        public string Estado { get; set; }
        public Obra() { }
        public Obra(int id, int empresaId, string nombreObra, string estado)
        { 
            Id = id;
            EmpresaId = empresaId;
            NombreObra = nombreObra;
            Estado = estado;
        }
    }
}
