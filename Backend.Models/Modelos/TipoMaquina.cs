using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class TipoMaquina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoMaquina() { }
        public TipoMaquina(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
