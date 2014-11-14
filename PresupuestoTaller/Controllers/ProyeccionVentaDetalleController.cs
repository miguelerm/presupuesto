using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PresupuestoTaller.Models;

namespace PresupuestoTaller.Controllers
{
    [RoutePrefix("api/proyeccionventa/{proyeccionId}/productos")]
    public class ProyeccionVentaDetalleController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: api/ProyeccionVentaDetalle
        [Route("")]
        public IQueryable<ProyeccionVentaDetalleModelo> GetProyeccionVentaDetalles(long proyeccionId)
        {
            return db.ProyeccionVentaDetalles.Include(x => x.Producto).Where(x => x.ProyeccionId == proyeccionId);
        }

        // GET: api/ProyeccionVentaDetalle/5
        [Route("{id}")]
        [ResponseType(typeof(ProyeccionVentaDetalleModelo))]
        public IHttpActionResult GetProyeccionVentaDetalleModelo(long proyeccionId, long id)
        {
            ProyeccionVentaDetalleModelo proyeccionVentaDetalleModelo = db.ProyeccionVentaDetalles.Include(x => x.Producto).FirstOrDefault(x => x.ProyeccionId == proyeccionId && x.ProyeccionId == id);
            if (proyeccionVentaDetalleModelo == null)
            {
                return NotFound();
            }

            return Ok(proyeccionVentaDetalleModelo);
        }

        // PUT: api/ProyeccionVentaDetalle/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProyeccionVentaDetalleModelo(long proyeccionId, long id, ProyeccionVentaDetalleModelo proyeccionVentaDetalleModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            proyeccionVentaDetalleModelo.ProyeccionId = proyeccionId;
            proyeccionVentaDetalleModelo.ProductoId = id;
            db.Entry(proyeccionVentaDetalleModelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyeccionVentaDetalleModeloExists(proyeccionId, id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProyeccionVentaDetalle
        [Route("")]
        [ResponseType(typeof(ProyeccionVentaDetalleModelo))]
        public IHttpActionResult PostProyeccionVentaDetalleModelo(long proyeccionId, ProyeccionVentaDetalleModelo proyeccionVentaDetalleModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            proyeccionVentaDetalleModelo.ProyeccionId = proyeccionId;
            db.ProyeccionVentaDetalles.Add(proyeccionVentaDetalleModelo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProyeccionVentaDetalleModeloExists(proyeccionId, proyeccionVentaDetalleModelo.ProductoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DetalleApi", new { parent = "proyecciongasto", child = "productos", parentId = proyeccionId, id = proyeccionVentaDetalleModelo.ProductoId }, proyeccionVentaDetalleModelo);
        }

        // DELETE: api/ProyeccionVentaDetalle/5
        [Route("{id}")]
        [ResponseType(typeof(ProyeccionVentaDetalleModelo))]
        public IHttpActionResult DeleteProyeccionVentaDetalleModelo(long proyeccionId, long id)
        {
            ProyeccionVentaDetalleModelo proyeccionVentaDetalleModelo = db.ProyeccionVentaDetalles.FirstOrDefault(x => x.ProyeccionId == proyeccionId && x.ProductoId == id);
            if (proyeccionVentaDetalleModelo == null)
            {
                return NotFound();
            }

            db.ProyeccionVentaDetalles.Remove(proyeccionVentaDetalleModelo);
            db.SaveChanges();

            return Ok(proyeccionVentaDetalleModelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProyeccionVentaDetalleModeloExists(long proyeccionId, long id)
        {
            return db.ProyeccionVentaDetalles.Count(e => e.ProyeccionId == proyeccionId && e.ProductoId == id) > 0;
        }
    }
}