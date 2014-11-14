using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PresupuestoTaller.Models
{
    [Table("ProyeccionVenta")]
    public class ProyeccionVentaModelo
    {
        [Key]
        public long Id { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public ICollection<ProyeccionVentaDetalleModelo> Productos { get; set; }
    }
}