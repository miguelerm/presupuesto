using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PresupuestoTaller.Models
{
    [Table("ProyeccionGasto")]
    public class ProyeccionGastoModelo
    {
        [Key]
        public long Id { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public ICollection<ProyeccionGastoDetalleModelo> Gastos { get; set; }
       
    }
}