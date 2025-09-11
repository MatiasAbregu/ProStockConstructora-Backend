using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BD.Modelos;
using Backend.BD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.BD
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public DbSet<ObraUsuario> ObraUsuarios { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
<<<<<<< HEAD
        public DbSet<Tokens> RefreshTokens { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<StockMaquina> StockMaquinas { get; set; }
=======
        public DbSet<RefreshToken> RefreshTokens { get; set; }
>>>>>>> 30e0be2189ad7e6728202b4e259f174c30f60df0
        public DbSet<Ubicacion> Ubicaciones { get; set; } 
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public DbSet<TipoMaterial> TipoMateriales { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<MaterialesyMaquinas> MaterialesyMaquinas { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = [new IdentityRole() { Name = "Superadministrador", NormalizedName = "Superadministrador" }, 
                                        new IdentityRole() { Name = "Administrador", NormalizedName = "Administrador"},
                                        new IdentityRole() { Name = "JefeDeDeposito", NormalizedName = "JefeDeDeposito" }, 
                                        new IdentityRole() { Name = "JefeDeObra", NormalizedName = "JefeDeObra" }];
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}