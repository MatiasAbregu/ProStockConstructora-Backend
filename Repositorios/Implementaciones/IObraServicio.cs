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
        Task<IEnumerable<Obra>> GetAllAsync();
        Task<Obra?> GetByIdAsync(int id);
        Task<Obra> AddAsync(Obra obra);
        Task UpdateAsync(Obra obra);
        Task DeleteAsync(int id);

    }
}
