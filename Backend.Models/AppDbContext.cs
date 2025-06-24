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
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<DetallePedidoXDocumento> DetallePedidoXDocumentos { get; set; }
        public DbSet<Documentos> Documentos { get; set; }
        public DbSet<Maquinas> Maquinas { get; set; }
        public DbSet<Materiales> Materiales { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<ObraXUsuario> ObraXUsuarios { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<StockMaquinas> StockMaquinas { get; set; }
        public DbSet<StockMateriales> StockMateriales { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<TipoMaquina> TipoMaquinas { get; set; }
        public DbSet<TipoMaterial> TipoMateriales { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }


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