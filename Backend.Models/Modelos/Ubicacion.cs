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
        public string CodigoUbicacion { get; set; } 
        public string NombreUbicacion { get; set; }
        public string Descripcion { get; set; }
        public int ProvinciaId { get; set; } // Foreign key to Provincia
        public Provincia Provincia { get; set; } // Navigation property to Provincia
        public Ubicacion() { }
        public Ubicacion(int id, string codigoUbicacion, string nombreUbicacion, string descripcion, int provinciaId)
        {
            Id = id;
            CodigoUbicacion = codigoUbicacion;
            NombreUbicacion = nombreUbicacion;
            Descripcion = descripcion;
            ProvinciaId = provinciaId;
        }
    }
}
