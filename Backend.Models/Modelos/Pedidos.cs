using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Pedidos
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaEntrega { get; set; } // Nullable to allow for pending orders
        public int ObraId { get; set; } // Foreign key to Obra
        public Obra Obra { get; set; } // Navigation property to Obra
        public string NombreObra { get; set; } // Name of the obra for easy reference
        public string Estado { get; set; } // e.g., "Pendiente", "Entregado", "Cancelado"
        public int Cantidad { get; set; }
        public int DepositoId { get; set; } // Foreign key to Deposito
        public Deposito Deposito { get; set; } // Navigation property to Deposito
        public int UbicacionId { get; set; } // Foreign key to Ubicacion
        public Ubicacion Ubicacion { get; set; } // Navigation property to Ubicacion
        public Pedidos() { }
        public Pedidos(int id, DateTime fechaPedido, DateTime? fechaEntrega, string estado, int obraId, int cantidad, int depositoId, int ubicacionId)
        {
            Id = id;
            FechaPedido = fechaPedido;
            FechaEntrega = fechaEntrega;
            ObraId = obraId;
            Cantidad = cantidad;
            DepositoId = depositoId;
            Estado = estado;
            UbicacionId = ubicacionId;
        }
    }
}
