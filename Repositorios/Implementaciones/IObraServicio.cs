using Backend.BD.Enums;
using Backend.BD.Modelos;
using Backend.DTO.DTOs_Obras;
using Backend.DTOs;
<<<<<<< HEAD
using Backend.BD.Enums;
=======
>>>>>>> cb2031fac0d027db9c0ad9023fca543014d2d4ef
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Implementaciones
{
    public interface IObraServicio
    {
        Task<(bool, string)> ActualizarEstadoObra(int id, EnumEstadoObra nuevoEstado);
<<<<<<< HEAD
        Task<(bool, string)> ActualizarObra(int id, Obra o);
=======
        Task<(bool, string)> ActualizarObra(int id, ObraActualizarDTO o);
>>>>>>> cb2031fac0d027db9c0ad9023fca543014d2d4ef
        Task<(bool, string)> CrearObra(ObraAsociarDTO obraDTO);
        Task<(bool, VerObraDTO)> ObtenerObraPorId(int id);
        Task<(bool, List<VerObraDTO>)> ObtenerObras(int EmpresaId);
        Task<(bool, List<VerObraConDepositoDTO>)> ObtenerObrasConDeposito(int EmpresaId);
<<<<<<< HEAD



=======
>>>>>>> cb2031fac0d027db9c0ad9023fca543014d2d4ef
    }
}


