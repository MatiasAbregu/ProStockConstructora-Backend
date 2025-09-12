﻿using Backend.BD.Enums;
using Backend.BD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    [Index(nameof(NumeroRemito), IsUnique = true)]
    public class Remito
    {
        [Key]
        public int Id { get; set; }
        public required string NumeroRemito { get; set; }

        public required int NotaDePedidoId { get; set; }
        public NotaDePedido NotaDePedido { get; set; }

        public required int DepositoOrigenId { get; set; }
        public Deposito Deposito { get; set; }

        public EstadoRemito EstadoRemito { get; set; } = EstadoRemito.Pendiente;

        public string? NombreTransportista { get; set; }

        public required DateTime FechaEmision { get; set; }
        public required DateTime FechaLimite { get; set; }

        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaRecepcion { get; set; }

        public Guid? RecibidoPor { get; set; }
        public Usuario Usuario { get; set; }

        public List<DetalleRemito>? ListaDelRemito { get; }

    }
}