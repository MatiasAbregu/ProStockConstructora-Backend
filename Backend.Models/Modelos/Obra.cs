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
        public Empresa Empresa { get; set; } // Navigation property to Empresa
        public int UbicacionId { get; set; } // Foreign key to Ubicacion
        public Ubicacion Ubicacion { get; set; } // Navigation property to Ubicacion
        public string NombreObra { get; set; }
        public string Estado { get; set; }
        public Obra() { }
        public Obra(int id, int empresaId ,string nombreObra, string estado, int ubicacionId )
        { 
            Id = id;
            EmpresaId = empresaId;;
            NombreObra = nombreObra;
            Estado = estado;
            UbicacionId = ubicacionId;
        }
    }
}
