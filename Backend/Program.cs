using System.Security.Claims;
using System.Text;
using Backend.BD;
using Backend.BD.Models;
using Backend.Repositorios.Implementaciones;
using Backend.Repositorios.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Estableciendo conexión 
builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseMySql(builder.Configuration.GetConnectionString("ConexionDB"),
       new MariaDbServerVersion(new Version(10, 4, 32))));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando Identity para que los usuarios tengan roles
builder.Services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

// Y configurandolo para que no ponga restricciones en las contraseñas
builder.Services.Configure<IdentityOptions>(options => 
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 0;
});

// Añadiendo autenticación (Token bearer por el HEAD del JSON) y configurando JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Asignar emisor
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:FirmaDelBackend"],
        
        // Asignar clave
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(builder.Configuration["JWT:Clave"])),

        // Validar si el token no expiró
        ValidateLifetime = true,
    };
});

// Configurando CORS para aceptar petición del frontend jajaja
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddScoped<ITokenServicio, TokenServicio>();
builder.Services.AddScoped<IAuthServicio, AuthServicio>();
builder.Services.AddScoped<IEmpresaServicio, EmpresaServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IObraServicio, ObraServicio>();
builder.Services.AddScoped<IDepositoServicio, DepositoServicio>();
builder.Services.AddScoped<IRolesServicio, RolesServicio>();
builder.Services.AddScoped<IRecursosServicio, RecursosServicio>();
builder.Services.AddScoped<INotaDePedidoServicio, NotaDePedidoServicio>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CORS");

app.Run();