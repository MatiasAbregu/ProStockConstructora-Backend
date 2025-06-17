using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class StockMaquinas
    {
        public int Id { get; set; } // Unique identifier for the stock entry
        public int MaquinaId { get; set; } // Foreign key to Maquinas
        public Maquinas Maquina { get; set; } // Navigation property to Maquinas
        public int DepositoId { get; set; } // Foreign key to Deposito
        public Deposito Deposito { get; set; } // Navigation property to Deposito
        public int UbicacionId { get; set; } // Foreign key to Ubicacion
        public Ubicacion Ubicacion { get; set; } // Navigation property to Ubicacion
        public int Cantidad { get; set; } // Quantity of the machine in stock
        public string Descripcion { get; set; } // Description of the stock entry
        public DateTime FechaIngreso { get; set; } // Date of stock entry
        public DateTime UltimoControl { get; set; } 
        public StockMaquinas() { }
        public StockMaquinas(int id, int maquinaId, int depositoId, int ubicacionId, int cantidad, string descripcion, DateTime fechaIngreso, DateTime ultimoControl)
        {
            Id = id;
            MaquinaId = maquinaId;
            DepositoId = depositoId;
            UbicacionId = ubicacionId;
            Cantidad = cantidad;
            Descripcion = descripcion;
            FechaIngreso = fechaIngreso;
            UltimoControl = ultimoControl;
        }
    }
}
