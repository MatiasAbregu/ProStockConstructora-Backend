using Backend.BD;
using Backend.DTO.DTOs_MaterialesYmaquinarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Servicios
{
    public class MaterialesYmaquinariasServicio
    {
        private readonly AppDbContext baseDeDatos;


        public MaterialesYmaquinariasServicio(AppDbContext baseDeDatos)
        {
            this.baseDeDatos = baseDeDatos;
        }

        public Task<(bool, string)> MaterialYmaquinaCargarDTO(MaterialYmaquinaCargarDTO materialYmaquinaDTO)
        {
            throw new NotImplementedException();
        }
    }
}
