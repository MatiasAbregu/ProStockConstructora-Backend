using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Deposito
    {
        public int Id { get; set; }
        public string TipoDeposito { get; set; }
        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; } // Navigation property to Ubicacion
        public int ObraId { get; set; }
        public Obra Obra { get; set; } // Navigation property to Obra
        // Navigation property to Material
        public Deposito() { }
        public Deposito(int id, string tipoDeposito, int ubicacionId, int obraId) 
        {
            Id = id;
            TipoDeposito = tipoDeposito;
            UbicacionId = ubicacionId;
            ObraId = obraId;    
        }
    }
}
