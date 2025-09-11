using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Stock
    {
        [Key]   
        public int Id { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int Cantidad { get; set; }
        public int MaterialesyMaquinasId { get; set; }
        public MaterialesyMaquinas MaterialesyMaquinas { get; set; }
    }
}
