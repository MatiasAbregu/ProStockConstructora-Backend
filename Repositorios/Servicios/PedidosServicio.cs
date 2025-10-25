using Backend.BD;
using Backend.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositorios.Servicios
{
    public class PedidosServicio : IPedidosServicio
    {
        private readonly AppDbContext baseDeDatos;
        private readonly IPedidosServicio pedidosServicio;

        public PedidosServicio(AppDbContext baseDeDatos)
        {
            this.baseDeDatos = baseDeDatos;
        }

        public async Task
        {
            
        }
    }
}
