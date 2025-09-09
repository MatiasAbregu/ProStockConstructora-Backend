using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Materiales
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string CodigoISO { get; set; }
        public string Unidad { get; set; }

        [ForeignKey("TipoMaterialID")]
        public int TipoMaterialId { get; set; }
        public TipoMateriales tipoMateriales { get; set; }

    }
}
