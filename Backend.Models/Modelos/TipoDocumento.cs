using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string NombreTipoDocumento { get; set; }
        public TipoDocumento() { }
        public TipoDocumento(int id, string nombreTipoDocumento)
        {
            Id = id;
            NombreTipoDocumento = nombreTipoDocumento;
        }
    }
}
