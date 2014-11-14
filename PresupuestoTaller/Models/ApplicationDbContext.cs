using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PresupuestoTaller.Models
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PresupuestoTaller.Models.GastoModelo> Gastos { get; set; }

        public System.Data.Entity.DbSet<PresupuestoTaller.Models.ProductosModelo> Productos { get; set; }

        public System.Data.Entity.DbSet<PresupuestoTaller.Models.ProyeccionGastoModelo> ProyeccionesGasto { get; set; }

        public System.Data.Entity.DbSet<PresupuestoTaller.Models.ProyeccionVentaModelo> ProyeccionesVenta { get; set; }

        public System.Data.Entity.DbSet<PresupuestoTaller.Models.ProyeccionGastoDetalleModelo> ProyeccionGastoDetalles { get; set; }

        public System.Data.Entity.DbSet<PresupuestoTaller.Models.ProyeccionVentaDetalleModelo> ProyeccionVentaDetalles { get; set; }
    }
}