using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD;
using Backend.BD.Modelos;
using Backend.DTO.DTOs_Empresas;
using Backend.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositorios.Servicios
{
    public class EmpresaServicio : IEmpresaServicio
    {
        private readonly AppDbContext baseDeDatos;

        public EmpresaServicio(AppDbContext baseDeDatos)
        {
            this.baseDeDatos = baseDeDatos;
        }

        public async Task<(bool res, List<VerEmpresaDTO>)> ObtenerEmpresas()
        {
            try
            {
                List<VerEmpresaDTO> empresasVer = [];
                List<Empresa> empresas = await baseDeDatos.Empresa.ToListAsync();

                foreach (Empresa e in empresas)
                {
                    empresasVer.Add(new VerEmpresaDTO
                    {
                        Id = e.Id,
                        Nombre = e.NombreEmpresa,
                        CUIT = e.CUIT,
                        RazonSocial = e.RazonSocial,
                        Estado = e.Estado ? "Activo" : "Inactivo",
                        Telefono = e.Celular,
                        Email = e.Email
                    });
                }

                return (true, empresasVer);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<(bool res, VerEmpresaDTO)> ObtenerEmpresaPorId(int id)
        {
            try
            {
                Empresa e = await baseDeDatos.Empresa.FirstOrDefaultAsync(e => e.Id == id);
                if (e == null) return (true, null);
                else return (true, new VerEmpresaDTO()
                {
                    Id = e.Id,
                    CUIT = e.CUIT,
                    Nombre = e.NombreEmpresa,
                    RazonSocial = e.RazonSocial,
                    Estado = e.Estado ? "Activo" : "Inactivo",
                    Telefono = e.Celular,
                    Email = e.Email
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en ObtenerEmpresaPorId: {ex.Message}");
                return (false, null);
            }
        }

        public async Task<(bool res, string msg)> CrearEmpresa(Empresa e)
        {
            try
            {
                baseDeDatos.Empresa.Add(e);
                int res = await baseDeDatos.SaveChangesAsync();

                if (res > 0) return (true, "Creado con éxito");
                else return (false, "No se pudo crear la empresa, intentelo más tarde.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                string errorMSG = ex.InnerException?.Message ?? ex.Message;

                if (errorMSG != null && errorMSG.Contains("Duplicate entry") && errorMSG.Contains("IX_Empresa_CUIT"))
                    return (false, "Ese CUIT ya existe, debe ingresar otro.");
                return (false, "Fallo al intentar crear la empresa, consulte con el administrador");
            }
        }

        public Task<string> ActualizarEmpresa()
        {
            throw new NotImplementedException();
        }

        public Task<string> EliminarEmpresa()
        {
            throw new NotImplementedException();
        }
    }
}
