using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Ubicacion
    {
        public int Id { get; set; }
        public string NombreUbicacion { get; set; }
        public string Descripcion { get; set; }
        public int ObraId { get; set; } // Foreign key to Obra
        public Obra Obra { get; set; } // Navigation property to Obra
        public Ubicacion() { }
        public Ubicacion(int id, string nombreUbicacion, string descripcion, int obraId)
        {
            Id = id;
            NombreUbicacion = nombreUbicacion;
            Descripcion = descripcion;
            ObraId = obraId;
        }
    }
}
