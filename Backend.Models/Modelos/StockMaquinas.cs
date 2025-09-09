using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class StockMaquinas
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        // Foreign Key Maquinas
        [ForeignKey("MaquinaId")]
        public int MaquinaId { get; set; }
        public Maquinas Maquina { get; set; }
    }
}
