using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Documentos
    {
        public int Id { get; set; } // Unique identifier for the document
        public string NumeroDocumento { get; set; } // Name of the document
        public string Emisor { get; set; } // Issuer of the document
        public string Descripcion { get; set; } // Description of the document
        public int TipoDocumentoId { get; set; } // Foreign key to TipoDocumento
        public TipoDocumento TipoDocumento { get; set; } // Navigation property to TipoDocumento
        public DateTime FechaEmitido { get; set; } // Creation date of the document
        public int ObraId { get; set; } // Foreign key to Obra
        public Obra Obra { get; set; } // Navigation property to Obra
        public Documentos() { }
        public Documentos(int id, string numeroDocumento, string emisor, string descripcion, DateTime fechaEmitido, int obraId, int tipoDocumentoId)
        {
            Id = id;
            NumeroDocumento = numeroDocumento;
            Emisor = emisor;
            Descripcion = descripcion;
            FechaEmitido = fechaEmitido;
            ObraId = obraId;
            TipoDocumentoId = tipoDocumentoId;
        }
    }
}
