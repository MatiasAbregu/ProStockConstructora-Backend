using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "El nombre de empresa es obligatorio.")]
        public string NombreEmpresa { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "El CUIT es obligatorio.")]
        public string CUIT { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "La razón social es obligatoria.")]
        public string RazonSocial { get; set; }

        [Column(TypeName = "tinyint(1)")]
        [Required(ErrorMessage = "El estado es obligatorio: 0 es inactivo / 1 es activo.")]
        public bool Estado { get; set; }


        [Required(ErrorMessage = "Es necesario asociar un contacto a esta empresa.")]
        public int ContactoId { get; set; }
        public Contacto Contacto { get; set; }
    }
}
