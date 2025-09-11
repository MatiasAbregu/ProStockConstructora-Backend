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

        public required string NombreObra { get; set; }

        public string? Estado { get; set; }

        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
    }
}
