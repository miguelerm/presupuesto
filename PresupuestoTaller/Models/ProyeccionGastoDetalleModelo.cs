using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PresupuestoTaller.Models
{
    [Table("ProyeccionGastoDetalle")]
    public class ProyeccionGastoDetalleModelo
    {
        [Key, Column(Order=0)]
        public long ProyeccionId { get; set; }
        [Key, Column(Order = 1)]
        public long GastoId { get; set; }
        public ProyeccionGastoModelo Proyeccion { get; set; }
        public GastoModelo Gasto { get; set; }
        public double Monto { get; set; }
    }
}