using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Provincia
    {
        public int Id { get; set; } // Unique identifier for the province
        public string Nombre { get; set; } // Name of the province
        public Provincia() { }
        public Provincia(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
