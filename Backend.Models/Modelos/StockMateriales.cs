using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class StockMateriales
    {
        public int Id { get; set; }
        public int MaterialId { get; set; } // Foreign key to Materiales
        public Materiales Material { get; set; } // Navigation property to Materiales
        public int DepositoId { get; set; } // Foreign key to Deposito
        public Deposito Deposito { get; set; } // Navigation property to Deposito
        public int UbicacionId { get; set; } // Foreign key to Ubicacion
        public Ubicacion Ubicacion { get; set; } // Navigation property to Ubicacion
        public int Cantidad { get; set; } // Quantity of the material in stock
        public string Descripcion { get; set; } // Description of the stock entry
        public DateTime FechaIngreso { get; set; } // Date of stock entry
        public DateTime FechaVencimiento { get; set; } // Expiration date of the material
        public StockMateriales() { }
        public StockMateriales(int id, int materialId, int depositoId, int ubicacionId, int cantidad, string descripcion, DateTime fechaIngreso, DateTime fechaVencimiento)
        {
           Id = id;
           MaterialId = materialId;
           DepositoId = depositoId;
           UbicacionId = ubicacionId;
           Cantidad = cantidad;
           Descripcion = descripcion;
           FechaIngreso = fechaIngreso;
           FechaVencimiento = fechaVencimiento;
        }
    }
}
