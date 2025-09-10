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
        public string Nombre { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int Cantidad { get; set; }
        public string? CodigoISO { get; set; }
        public int? TipoMaterialId { get; set; }
        public TipoMaterial? tipoMateriales { get; set; }
        public int UnidadMedidaId { get; set; }
        public UnidadMedida? unidadMedida { get; set; }
        public int MaterialesId { get; set; }
        public int MaquinaId { get; set; }
    }
}
