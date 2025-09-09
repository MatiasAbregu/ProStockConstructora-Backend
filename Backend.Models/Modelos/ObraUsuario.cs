using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class ObraUsuario
    {
        public int Id { get; set; }

        public int ObraId { get; set; }

        public required string Usuario { get; set; }
    } 
}
