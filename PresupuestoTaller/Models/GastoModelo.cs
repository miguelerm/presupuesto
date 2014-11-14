﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PresupuestoTaller.Models
{
    [Table("Gastos")]
    public class GastoModelo
    {
         [Key]
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<ProyeccionGastoDetalleModelo> Proyecciones { get; set; }
    }
}