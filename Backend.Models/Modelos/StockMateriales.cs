using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class StockMateriales
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("MaterialesId")]
        public int MaterialesId { get; set; }
        public Materiales Material { get; set; }

    }
}
