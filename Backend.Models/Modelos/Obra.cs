﻿using Backend.BD.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BD.Modelos
{
    public class Obra
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public required string NombreObra { get; set; }

        public EnumEstadoObra Estado { get; set; } = EnumEstadoObra.EnProceso;

        public required int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }
}
