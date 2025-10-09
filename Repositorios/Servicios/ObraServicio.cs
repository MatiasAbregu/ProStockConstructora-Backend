using Backend.BD;
using Backend.BD.Enums;
using Backend.BD.Modelos;
using Backend.BD.Models;
using Backend.DTO.DTOs_Obras;
using Backend.DTOs;
using Backend.Repositorios.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Backend.Repositorios.Servicios
{
    public class ObraServicio : IObraServicio
    {

        private readonly AppDbContext baseDeDatos;
        private readonly IDepositoServicio depositoServicio;
        private readonly IObraServicio obraServicio;


        public ObraServicio(AppDbContext baseDeDatos)
        {
            this.baseDeDatos = baseDeDatos;
        }

        public async Task<(bool, List<VerObraDTO>)> ObtenerObras(int EmpresaId)
        {
            try
            {
                List<VerObraDTO> obrasVer = [];
                List<Obra> obras = await baseDeDatos.Obras.
                    Where(o => o.EmpresaId == EmpresaId).ToListAsync();

                foreach (Obra o in obras)
                {
                    obrasVer.Add(new VerObraDTO
                    {
                        EmpresaId = o.EmpresaId,
                        Nombre = o.NombreObra,
                        Estado = o.Estado.ToString()
                    });
                }

                return (true, obrasVer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, null);
            }
        }

        public async Task<(bool, List<VerObraConDepositoDTO>)> ObtenerObrasConDeposito(int EmpresaId)
        {
            try
            {
                List<VerObraConDepositoDTO> obrasVer = [];
                var obrasConDepositos = await (from o in baseDeDatos.Obras
                                               join d in baseDeDatos.Depositos on o.Id equals d.ObraId
                                               where o.EmpresaId == EmpresaId
                                               select new { Obra = o, Deposito = d }).ToListAsync();
                foreach (var item in obrasConDepositos)
                {
                    obrasVer.Add(new VerObraConDepositoDTO
                    {
                        Id = item.Obra.Id,
                        Nombre = item.Obra.NombreObra,
                        Estado = item.Obra.Estado.ToString(),
                        DepositoId = item.Deposito.Id,
                        TipoDeposito = item.Deposito.TipoDeposito.ToString()
                    });
                }
                return (true, obrasVer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, null);
            }
        }

        public async Task<(bool, VerObraDTO)> ObtenerObraPorId(int id)
        {
            try
            {
                Obra o = await baseDeDatos.Obras.FirstOrDefaultAsync(o => o.Id == id);
                if (o == null) return (true, null);
                VerObraDTO obraVer = new VerObraDTO
                {
                    EmpresaId = o.EmpresaId,
                    Nombre = o.NombreObra,
                    Estado = o.Estado.ToString()
                };
                return (true, obraVer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, null);
            }
        }

        public async Task<(bool, string)> CrearObra(ObraAsociarDTO obraDTO)
        {
            try
            {
                bool existeObra = await baseDeDatos.Obras
                    .AnyAsync(ob => obraDTO.NombreObra.ToLower() == ob.NombreObra.ToLower()
                    && ob.EmpresaId == obraDTO.EmpresaId);
                if (existeObra)
                    return (false, "Ya existe una obra con ese nombre en la empresa.");

                var nuevaObra = new Obra
                {
                    NombreObra = obraDTO.NombreObra,
                    EmpresaId = obraDTO.EmpresaId,
                    Estado = EnumEstadoObra.EnProceso
                };
                await baseDeDatos.Obras.AddAsync(nuevaObra);
                await baseDeDatos.SaveChangesAsync();
                return (true, "Obra creada con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, "Error al crear la obra.");
            }
        }

        public async Task<(bool, string)> ActualizarObra(int id, ObraActualizarDTO o)
        {
            try
            {
                Obra obraUpdate = await baseDeDatos.Obras.FirstOrDefaultAsync(ob => ob.Id == id);
                if (obraUpdate == null) return (false, "No existe una obra con ese ID.");
                obraUpdate.NombreObra = o.NombreObra;


                await baseDeDatos.SaveChangesAsync();
                return (true, "Obra actualizada con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, "Error al actualizar la obra.");
            }
        }

        public async Task<(bool, string)> ActualizarEstadoObra(int id, EnumEstadoObra nuevoEstado)
        {
            try
            {
                Obra obra = await baseDeDatos.Obras.FirstOrDefaultAsync(o => o.Id == id);
                if (obra == null) return (false, "No existe una obra con ese ID.");
                obra.Estado = nuevoEstado;
                await baseDeDatos.SaveChangesAsync();
                return (true, "Estado de la obra actualizado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, "Error al actualizar el estado de la obra.");
            }
        }
    }
}