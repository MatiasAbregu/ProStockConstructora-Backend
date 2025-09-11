using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Obra
    {
        public int Id { get; set; }

        [MaxLength (100)]
        public required string NombreObra { get; set; }

        public string Estado { get; set; }

        public int EmpresaId { get; set; }
<<<<<<< HEAD
        public Empresa Empresa { get; set; }

        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; }
        
=======
        public Empresa? Empresa { get; set; }
>>>>>>> aa50e1b3667f625b9c08ee2ef34f360071c86723
    }
}
