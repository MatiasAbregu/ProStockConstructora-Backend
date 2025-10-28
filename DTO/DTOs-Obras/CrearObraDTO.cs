﻿using Backend.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTO.DTOs_Obras
{
    public class CrearObraDTO
    {
        public int EmpresaId { get; set; }
        public string CodigoObra { get; set; }
        public string NombreObra { get; set; }
        public EnumEstadoObra Estado { get; set; } = EnumEstadoObra.EnProceso;
    }
}
