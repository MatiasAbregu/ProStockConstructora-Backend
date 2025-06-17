using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class DetallePedido
    {
        public int Id { get; set; } // Unique identifier for the order detail
        public int PedidoId { get; set; } // Foreign key to Pedido
        public Pedidos Pedido { get; set; } // Navigation property to Pedido
        public int MaterialesId { get; set; } // Foreign key to 
        public Materiales Materiales { get; set; } // Navigation property to Materiales
        public int MaquinasId { get; set; } // Foreign key to Maquinas
        public Maquinas Maquinarias { get; set; } // Navigation property to Maquinas
        public int Cantidad { get; set; } // Quantity of the product in the order
        public decimal PrecioUnitario { get; set; } // Unit price of the product
        public DetallePedido() { }
        public DetallePedido(int id, int pedidoId, int materialesId, int cantidad, decimal precioUnitario)
        {
            Id = id;
            PedidoId = pedidoId;
            MaterialesId = materialesId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
