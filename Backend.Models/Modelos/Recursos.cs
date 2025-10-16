﻿using Backend.BD.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{

    [Index(nameof(CodigoISO), IsUnique = true)]
    public class Recursos
    {
        [Key]
        public int Id { get; set; }
        public required string CodigoISO { get; set; }

        public required string Nombre { get; set; }
        public EnumTipoMaterialOMaquina Tipo { get; set; }

        public int? UnidadMedidaId { get; set; }
        public UnidadMedida UnidadMedida { get; set; }

        public int? TipoMaterialId { get; set; }
        public TipoMaterial TipoMaterial { get; set; }

        public string? Descripcion { get; set; }
    }
}
