using Backend.BD;
using Backend.BD.Modelos;
using Backend.BD.Models;
using Backend.DTO.DTOs_Obras;
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
        private readonly AppDbContext _context;

        public ObraServicio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Obra>> GetAllAsync()
        {
            return await _context.Obras
                .Include(o => o.Empresa) // Para traer también la Empresa
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Obra?> GetByIdAsync(int id)
        {
            return await _context.Obras
                .Include(o => o.Empresa)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Obra> AddAsync(Obra obra)
        {
            _context.Obras.Add(obra);
            await _context.SaveChangesAsync();
            return obra;
        }

        public async Task UpdateAsync(Obra obra)
        {
            _context.Obras.Update(obra);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            if (obra != null)
            {
                _context.Obras.Remove(obra);
                await _context.SaveChangesAsync();
            }
        }

    }
}
