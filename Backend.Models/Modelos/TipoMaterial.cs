using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class TipoMaterial
    {
        public int Id { get; set; }
        public string Nombre { get; set; } // Name of the material type
        public TipoMaterial() { }
        public TipoMaterial(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
