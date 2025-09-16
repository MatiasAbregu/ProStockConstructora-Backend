using Backend.BD.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface IObraServicio
    {
        Task<IEnumerable<Obra>> GetAllAsync(); //Para obtener la lista de todas las obras guardadas.
        Task<Obra?> GetByIdAsync(int id); //Obtiene a la obra por Id...
        Task<Obra> AddAsync(Obra obra); //Se agrega una obra...
        Task UpdateAsync(Obra obra); //Se actualiza una obra...
        Task DeleteAsync(int id); //Se elimina la obra...

    }
}
//Task<(bool, string)> ActualizarEstadoObra(int id, EnumEstadoObra nuevoEstado);
//Task<(bool, string)> ActualizarObra(int id, Obra o);
//Task<(bool, string)> CrearObra(ObraAsociarDTO obraDTO);
//Task<(bool, VerObraDTO)> ObtenerObraPorId(int id);
//Task<(bool, List<VerObraDTO>)> ObtenerObras(int EmpresaId);
//Task<(bool, List<VerObraConDepositoDTO>)> ObtenerObrasConDeposito(int EmpresaId);

