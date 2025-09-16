using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTOs
{
    
    public class VerObraDTO
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public string NombreObra { get; set; }
        public string Estado { get; set; }
        public int EmpresaId { get; set; }
=======
        public int EmpresaId { get; set; }
        public required string Nombre { get; set; }
        public required string Estado { get; set; }
>>>>>>> 61a143f6eb6acf07acc6b77b23501739ec2f77d5
    }


}
