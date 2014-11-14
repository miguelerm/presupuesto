using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PresupuestoTaller.Models
{
    [Table("ProyeccionVentaDetalle")]
    public class ProyeccionVentaDetalleModelo
    {
        [Key, Column(Order= 0)]
        public long ProyeccionId { get; set; }
        [Key, Column(Order=1)]
        public long ProductoId { get; set; }
        public ProyeccionVentaModelo Proyeccion { get; set; }
        public ProductosModelo Producto { get; set; }
        public int Cantidad { get; set; }
    }
}