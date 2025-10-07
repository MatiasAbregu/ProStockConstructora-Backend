using Backend.BD;
using Backend.BD.Enums;
using Backend.BD.Modelos;
using Backend.BD.Models;
using Backend.DTO.DTOs_MaterialesYmaquinarias;
using Backend.DTOs;
using Backend.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
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
        private readonly IDepositoServicio depositoServicio;

        public MaterialesYmaquinariasServicio(AppDbContext baseDeDatos)
        {
            this.baseDeDatos = baseDeDatos;
        }

        public async Task<(bool, string)> MaterialYmaquinaCargar(MaterialYmaquinaCargarDTO materialYmaquinaDTO)
        {
            try
            {
                bool ExisteMaterialoMaquina = await baseDeDatos.MaterialesyMaquinas.AnyAsync(x => x.CodigoISO.Equals(materialYmaquinaDTO.CodigoISO, StringComparison.OrdinalIgnoreCase));
                if (ExisteMaterialoMaquina)
                    return (false, "El codigo ISO ya existe");

                var materialoMaquina = new MaterialesyMaquinas
                {
                    CodigoISO = materialYmaquinaDTO.CodigoISO,
                    Nombre = materialYmaquinaDTO.Nombre,
                    Tipo = (EnumTipoMaterialOMaquina)materialYmaquinaDTO.Tipo,
                    TipoMaterialId = materialYmaquinaDTO.TipoMaterial,
                    UnidadMedidaId = materialYmaquinaDTO.UnidadMedidaId,
                    Descripcion = materialYmaquinaDTO.Descripcion
                };
                await baseDeDatos.MaterialesyMaquinas.AddAsync(materialoMaquina);
                await baseDeDatos.SaveChangesAsync();
                return (true, "Material o Maquina cargado con exito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, "Error al cargar el material o maquina");
            }
        }
    }
}
