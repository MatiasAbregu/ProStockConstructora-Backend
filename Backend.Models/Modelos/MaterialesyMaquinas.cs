using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public enum TipoMaterialoMaquina
    {
        Material = 1,
        Maquina = 2
    }
    public class MaterialesyMaquinas
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? CodigoISO { get; set; }
        public TipoMaterialoMaquina Tipo { get; set; } // 1: Material, 2: Maquina
        public int? UnidadMedidaId { get; set; }
        public UnidadMedida? unidadMedida { get; set; }
        public int? TipoMaterialId { get; set; }
        public TipoMaterial? tipoMaterial { get; set; }
    }
}
