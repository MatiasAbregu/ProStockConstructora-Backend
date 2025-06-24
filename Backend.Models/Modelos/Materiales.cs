using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Materiales
    {
        public int Id { get; set; }
        public string Nombre { get; set; } // Name of the material
        public string Marca { get; set; } // Description of the material
        public string Descripcion { get; set; } // Description of the material
        public decimal PrecioUnitario { get; set; } // Unit price of the material
        public TipoMaterial TipoMaterial { get; set; } // Navigation property to TipoMaterial
        public int TipoMaterialId { get; set; } // Foreign key to TipoMaterial
        public int Stock { get; set; } // Current stock level of the material
        public DateTime FechaVencimiento { get; set; } // Expiration date of the material
        public Materiales() { }
        public Materiales(int id, string nombre, string marca, string descripcion , decimal precioUnitario, int tipoMaterialId ,int stock, DateTime fechaVencimiento)
        {
            Id = id;
            Nombre = nombre;
            Marca = marca;
            Descripcion = descripcion;
            PrecioUnitario = precioUnitario;
            TipoMaterialId = tipoMaterialId;
            Stock = stock;
            FechaVencimiento = fechaVencimiento;
        }
    }
}
