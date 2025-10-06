using Backend.BD;
using Backend.DTO.DTOs_Depositos;
using Backend.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Servicios
{
    public class DepositoServicio : IDepositoServicio
    {
        private readonly AppDbContext baseDeDatos;

        public DepositoServicio(AppDbContext BaseDeDatos)
        {
            this.baseDeDatos = BaseDeDatos;

        }
        public async Task<(bool, List<VerDepositoDTO>)> ObtenerDepositos()
        {
            var depositos = await baseDeDatos.Depositos.ToListAsync();
            return (true, depositos.Select(deposito => new VerDepositoDTO
            {
                Id = deposito.Id,
                TipoDeposito = deposito.TipoDeposito.ToString(),
                ObraId = deposito.ObraId,
                NombreObra = (baseDeDatos.Obras.FirstOrDefault(o => o.Id == deposito.ObraId))?.NombreObra ?? "Obra no encontrada",
                UbicacionId = deposito.UbicacionId,
                Ubicacion = (baseDeDatos.Ubicaciones.FirstOrDefault(u => u.Id == deposito.UbicacionId))?.Domicilio ?? "Ubicación no encontrada"
            }).ToList());
        }

        public async Task<(bool, VerDepositoDTO)> ObtenerDepositoPorId(int id)
        {
            try
            {
                BD.Modelos.Deposito deposito = await baseDeDatos.Depositos.FirstOrDefaultAsync(d => d.Id == id);
                if (deposito == null) return (true, null);
                VerDepositoDTO depositoVer = new VerDepositoDTO
                {
                    Id = deposito.Id,
                    TipoDeposito = deposito.TipoDeposito.ToString(),
                    ObraId = deposito.ObraId,
                    NombreObra = (await baseDeDatos.Obras.FirstOrDefaultAsync(o => o.Id == deposito.ObraId))?.NombreObra ?? "Obra no encontrada",
                    UbicacionId = deposito.UbicacionId,
                    Ubicacion = (await baseDeDatos.Ubicaciones.FirstOrDefaultAsync(u => u.Id == deposito.UbicacionId))?.Domicilio ?? "Ubicación no encontrada"
                };
                return (true, depositoVer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return (false, null);
            }
        }
        public async Task<(bool, string)> CrearDeposito(DepositoAsociarDTO e)
        {
            try
            {
                bool existeDeposito = await baseDeDatos.Depositos.AnyAsync(d => d.ObraId == e.ObraId && d.UbicacionId == e.UbicacionId);
                if (existeDeposito) return (false, "Ya existe un depósito asociado a esa obra y ubicación.");
                BD.Modelos.Deposito nuevoDeposito = new BD.Modelos.Deposito
                {
                    ObraId = e.ObraId,
                    UbicacionId = e.UbicacionId
                };
                await baseDeDatos.Depositos.AddAsync(nuevoDeposito);
                await baseDeDatos.SaveChangesAsync();
                return (true, "Depósito creado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return (false, "Error al crear el depósito.");
            }
        }


        public async Task<(bool, string)> ActualizarDeposito(DepositoAsociarDTO e)
        {
            try
            {
                BD.Modelos.Deposito deposito = await baseDeDatos.Depositos.FirstOrDefaultAsync(d => d.Id == e.Id);
                if (deposito == null) return (false, "No existe un depósito con ese ID.");
                deposito.ObraId = e.ObraId;
                deposito.UbicacionId = e.UbicacionId;
                baseDeDatos.Depositos.Update(deposito);
                await baseDeDatos.SaveChangesAsync();
                return (true, "Depósito actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return (false, "Error al actualizar el depósito.");
            }
        }
        public async Task<(bool, string)> EliminarDeposito(int id)
        {
            try
            {
                BD.Modelos.Deposito deposito = await baseDeDatos.Depositos.FirstOrDefaultAsync(d => d.Id == id);
                if (deposito == null) return (false, "No existe un depósito con ese ID.");
                baseDeDatos.Depositos.Remove(deposito);
                await baseDeDatos.SaveChangesAsync();
                return (true, "Depósito eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return (false, "Error al eliminar el depósito.");
            }
        }
    }
}