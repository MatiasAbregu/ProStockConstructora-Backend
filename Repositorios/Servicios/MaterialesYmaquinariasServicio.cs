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
    public class MaterialesYmaquinariasServicio : IMaterialesYmaquinariasServicio
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

        public async Task<(bool, string)> MaterialYmaquinaCargarAdeposito(MaterialYmaquinaCargarAdepositoDTO materialYmaquinaCargarAdepositoDTO)
        {
            try
            {
                bool depositoExiste = await baseDeDatos.Depositos.AnyAsync(d => d.Id == materialYmaquinaCargarAdepositoDTO.DepositoId);
                if (!depositoExiste)
                    return (false, "El deposito no existe");
                bool materialoMaquinaExiste = await baseDeDatos.MaterialesyMaquinas.AnyAsync(m => m.Id == materialYmaquinaCargarAdepositoDTO.MaterialYmaquinaId);
                if (!materialoMaquinaExiste)
                    return (false, "El material o maquina no existe");
                bool cantidadMaterialoMaquina = materialYmaquinaCargarAdepositoDTO.Cantidad > 0;
                if (!cantidadMaterialoMaquina)
                    return (false, "La cantidad debe ser mayor a 0");
                var depositoMaterialoMaquina = new Stock
                {
                    DepositoId = materialYmaquinaCargarAdepositoDTO.DepositoId,
                    MaterialesyMaquinasId = materialYmaquinaCargarAdepositoDTO.MaterialYmaquinaId,
                    Cantidad = materialYmaquinaCargarAdepositoDTO.Cantidad,
                    FechaIngreso = DateTime.Now
                };
                await baseDeDatos.Stocks.AddAsync(depositoMaterialoMaquina);
                await baseDeDatos.SaveChangesAsync();
                return (true, "Material o Maquina cargado al deposito con exito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, "Error al cargar el material o maquina al deposito");
            }
        }

        public async Task<(bool, string)> MaterialYmaquinaTransladarDeposito(MaterialYmaquinaTransladarDepositoDTO materialYmaquinaTransladarDeposito)
        {
            try
            {
                bool depositoOrigenExiste = await baseDeDatos.Depositos.AnyAsync(d => d.Id == materialYmaquinaTransladarDeposito.DepositoOrigenId);
                if (!depositoOrigenExiste)
                    return (false, "El deposito origen no existe");
                bool depositoDestinoExiste = await baseDeDatos.Depositos.AnyAsync(d => d.Id == materialYmaquinaTransladarDeposito.DepositoDestinoId);
                if (!depositoDestinoExiste)
                    return (false, "El deposito destino no existe");
                bool materialoMaquinaExiste = await baseDeDatos.MaterialesyMaquinas.AnyAsync(m => m.Id == materialYmaquinaTransladarDeposito.MaterialYmaquinaId);
                if (!materialoMaquinaExiste)
                    return (false, "El material o maquina no existe");
                bool cantidadMaterialoMaquina = materialYmaquinaTransladarDeposito.Cantidad > 0;
                if (!cantidadMaterialoMaquina)
                    return (false, "La cantidad debe ser mayor a 0");
                var stockOrigen = await baseDeDatos.Stocks
                    .FirstOrDefaultAsync(s => s.DepositoId == materialYmaquinaTransladarDeposito.DepositoOrigenId &&
                                              s.MaterialesyMaquinasId == materialYmaquinaTransladarDeposito.MaterialYmaquinaId);
                if (stockOrigen == null || stockOrigen.Cantidad < materialYmaquinaTransladarDeposito.Cantidad)
                    return (false, "No hay suficiente stock en el deposito origen");
                
                stockOrigen.Cantidad -= materialYmaquinaTransladarDeposito.Cantidad;
                
                var stockDestino = await baseDeDatos.Stocks
                    .FirstOrDefaultAsync(s => s.DepositoId == materialYmaquinaTransladarDeposito.DepositoDestinoId &&
                                              s.MaterialesyMaquinasId == materialYmaquinaTransladarDeposito.MaterialYmaquinaId);
                if (stockDestino != null)
                {
                    stockDestino.Cantidad += materialYmaquinaTransladarDeposito.Cantidad;
                    await baseDeDatos.SaveChangesAsync();
                    return (true, "Material o Maquina trasladado entre depositos con exito");
                }
                else
                {
                    stockDestino = new Stock
                    {
                        DepositoId = materialYmaquinaTransladarDeposito.DepositoDestinoId,
                        MaterialesyMaquinasId = materialYmaquinaTransladarDeposito.MaterialYmaquinaId,
                        Cantidad = materialYmaquinaTransladarDeposito.Cantidad,
                        FechaIngreso = DateTime.Now
                    };
                    await baseDeDatos.Stocks.AddAsync(stockDestino);
                    await baseDeDatos.SaveChangesAsync();
                    return (true, "Material o Maquina trasladado entre depositos con exito");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, "Error al trasladar el material o maquina entre depositos");
            }
        }
    }
}
