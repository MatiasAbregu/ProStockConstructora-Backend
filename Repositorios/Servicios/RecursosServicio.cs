using Backend.BD;
using Backend.BD.Enums;
using Backend.BD.Modelos;
using Backend.BD.Models;
using Backend.DTO.DTOs_MaterialesYmaquinarias;
using Backend.DTO.Enum;
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
    public class RecursosServicio : IRecursosServicio
    {
        private readonly AppDbContext baseDeDatos;
        private readonly IDepositoServicio depositoServicio;

        public RecursosServicio(AppDbContext baseDeDatos)
        {
            this.baseDeDatos = baseDeDatos;
        }

        public async Task<(bool, string)> RecursoCargar(RecursosCargarDTO materialYmaquinaDTO)
        {
            try
            {
                bool ExisteMaterialoMaquina = await baseDeDatos.MaterialesyMaquinas.AnyAsync(x => x.CodigoISO == x.CodigoISO.ToUpper());
                if (ExisteMaterialoMaquina) return (false, "El codigo ISO ya existe");

                TipoMaterial? tipoMaterial = null;
                UnidadMedida? unidadMedida = null;
                if (materialYmaquinaDTO.TipoMaterial.Id == 0 && materialYmaquinaDTO.Tipo == EnumTipoMaterialoMaquina.Material)
                {
                    tipoMaterial = await baseDeDatos.TipoMateriales.FirstOrDefaultAsync(tm => tm.Nombre == materialYmaquinaDTO.TipoMaterial.Nombre.ToUpper());
                    if (tipoMaterial == null)
                    {
                        tipoMaterial = new TipoMaterial
                        {
                            Nombre = materialYmaquinaDTO.TipoMaterial.Nombre
                        };
                        baseDeDatos.TipoMateriales.Add(tipoMaterial);
                        await baseDeDatos.SaveChangesAsync();
                    }
                }

                if (materialYmaquinaDTO.UnidadDeMedida.Id == 0 && materialYmaquinaDTO.Tipo == EnumTipoMaterialoMaquina.Material)
                {
                    unidadMedida = await baseDeDatos.UnidadMedidas.FirstOrDefaultAsync(um => um.Nombre == materialYmaquinaDTO.UnidadDeMedida.Nombre.ToUpper());
                    if (unidadMedida == null)
                    {
                        unidadMedida = new UnidadMedida
                        {
                            Nombre = materialYmaquinaDTO.UnidadDeMedida.Nombre,
                            Simbolo = materialYmaquinaDTO.UnidadDeMedida.Abreviacion
                        };
                        baseDeDatos.UnidadMedidas.Add(unidadMedida);
                        await baseDeDatos.SaveChangesAsync();
                    }
                }

                var materialoMaquina = new Recursos
                {
                    CodigoISO = materialYmaquinaDTO.CodigoISO.ToUpper(),
                    Nombre = materialYmaquinaDTO.Nombre,
                    Tipo = (EnumTipoMaterialOMaquina)materialYmaquinaDTO.Tipo,
                    TipoMaterialId = materialYmaquinaDTO.TipoMaterial.Id != 0 ? materialYmaquinaDTO.TipoMaterial.Id : tipoMaterial!.Id,
                    UnidadMedidaId = materialYmaquinaDTO.UnidadDeMedida.Id != 0 ? materialYmaquinaDTO.UnidadDeMedida.Id : unidadMedida!.Id,
                    Descripcion = materialYmaquinaDTO.Descripcion
                };
                await baseDeDatos.MaterialesyMaquinas.AddAsync(materialoMaquina);
                await baseDeDatos.SaveChangesAsync();
                return (true, "Material o Maquina cargado con exito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return (false, "Error al cargar el material o maquina");
            }
        }

        public async Task<(bool, string)> RecursosCargarAdeposito(RecursosCargarAdepositoDTO materialYmaquinaCargarAdepositoDTO)
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

        public async Task<(bool, string)> RecursosTransladarAdeposito(RecursosTransladarDepositoDTO materialYmaquinaTransladarDeposito)
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

        public async Task<(bool, List<RecursosVerDepositoDTO>)> RecursosVerDepositoDTO(int depositoId)
        {
            try
            {
                var resultado = await baseDeDatos.Stocks.Where(s => s.DepositoId == depositoId)
                   .Include(s => s.Deposito)
                   .Include(s => s.MaterialesyMaquinas)
                         .ThenInclude(m => m.TipoMaterial)
                   .Include(s => s.MaterialesyMaquinas)
                          .ThenInclude(t => t.UnidadMedida)
                   .Select(s => new RecursosVerDepositoDTO
                   {
                       Id = s.Id,
                       CodigoISO = s.MaterialesyMaquinas.CodigoISO,
                       Nombre = s.MaterialesyMaquinas.Nombre,
                       TipoMaquinariaOmaquina = s.MaterialesyMaquinas.Tipo.ToString(),
                       TipoMaterial = s.MaterialesyMaquinas.TipoMaterial != null ? s.MaterialesyMaquinas.TipoMaterial.Nombre : null,
                       UnidadMedida = s.MaterialesyMaquinas.UnidadMedida.Nombre,
                       Cantidad = s.Cantidad
                   })
                   .ToListAsync();
                return (true, resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, null);
            }
        }

        public async Task<(bool, List<RecursosPagPrincipalDTO>)> RecursosVerDTO(int EmpresaId)
        {
            try
            {
                var existe = await baseDeDatos.Obras.Where(s => s.EmpresaId == EmpresaId).ToListAsync();
                if (existe == null || existe.Count == 0)
                    return (false, null);
                var resultado = await baseDeDatos.Stocks.Where(s => s.Deposito.Obra.EmpresaId == EmpresaId)
                 .Include(s => s.Deposito)
                        .ThenInclude(s => s.Obra)
                 .Include(s => s.MaterialesyMaquinas)
                       .ThenInclude(m => m.TipoMaterial)
                 .Include(s => s.MaterialesyMaquinas)
                        .ThenInclude(t => t.UnidadMedida).Select(s => new RecursosPagPrincipalDTO()
                        {
                            CodigoISO = s.MaterialesyMaquinas.CodigoISO,
                            Nombre = s.MaterialesyMaquinas.Nombre,
                            UnidadMedida = s.MaterialesyMaquinas.UnidadMedida.Simbolo
                        }
                ).ToListAsync();
                return (true, resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException.Message}");
                return (false, null);
            }
        }
    }
}
