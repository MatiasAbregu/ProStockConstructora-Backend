using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class DetalleRemito
    {
        public int Id { get; set; }

        public int IdRemito { get; set; }

        public int IdMaterial { get; set; }

        public int IdMaquina { get; set; }

        public int Cantidad { get; set; }

        public int CantidadEntregada { get; set; }

        public string Unidad { get; set; }


    }
}

