﻿using Backend.BD.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_NotaDePedido
{
    public class DetalleNotaDePedidoDTO
    {
        public required int MaterialesyMaquinasId { get; set; }
        public required int Cantidad { get; set; }
    }  
}
