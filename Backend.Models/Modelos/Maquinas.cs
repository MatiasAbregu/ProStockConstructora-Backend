using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Maquinas
    {
        public int Id { get; set; } // Unique identifier for the machine
        public string NombreMaquina { get; set; } // Name of the machine
        public string Marca { get; set; } // Brand of the machine
        public string Modelo { get; set; } // Model of the machine
        public TipoMaquina TipoMaquina { get; set; } // Navigation property to TipoMaquina
        public int TipoMaquinaId { get; set; } // Foreign key to TipoMaquina

        public Maquinas() { }
        public Maquinas(int id, string nombreMaquina, string marca, string modelo, int tipoMaquinaId)
        {
            Id = id;
            NombreMaquina = nombreMaquina;
            Marca = marca;
            Modelo = modelo;
            TipoMaquinaId = tipoMaquinaId;
        }
    }
}
