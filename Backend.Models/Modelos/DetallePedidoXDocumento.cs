using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class DetallePedidoXDocumento
    {
        public int Id { get; set; }
        public int PedidoId { get; set; } // Foreign key to Pedido
        public Pedidos Pedido { get; set; } // Navigation property to Pedido
        public int DocumentosId { get; set; } // Foreign key to Documento
        public Documentos Documento { get; set; } // Navigation property to Documento
        public DetallePedidoXDocumento() { }
        public DetallePedidoXDocumento(int id, int pedidoId, int documentosId)
        {
            Id = id;
            PedidoId = pedidoId;
            DocumentosId = documentosId;
        }
    }
}
