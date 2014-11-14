using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PresupuestoTaller.Models
{
    [Table("Productos")]
    public class ProductosModelo
    {
         [Key]
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Caracteristicas { get; set; }
        public double PrecioVenta { get; set; }
        //public ICollection<ProyeccionVentaDetalleModelo> Proyecciones { get; set; }
    }
}