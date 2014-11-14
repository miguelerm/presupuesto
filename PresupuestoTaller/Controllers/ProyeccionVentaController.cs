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
    public class ProyeccionVentaController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProyeccionVenta
        public IQueryable<ProyeccionVentaModelo> GetProyeccionVentaModeloes()
        {
            return db.ProyeccionesVenta;
        }

        // GET: api/ProyeccionVenta/5
        [ResponseType(typeof(ProyeccionVentaModelo))]
        public IHttpActionResult GetProyeccionVentaModelo(long id)
        {
            ProyeccionVentaModelo proyeccionVentaModelo = db.ProyeccionesVenta.Find(id);
            if (proyeccionVentaModelo == null)
            {
                return NotFound();
            }

            return Ok(proyeccionVentaModelo);
        }

        // PUT: api/ProyeccionVenta/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProyeccionVentaModelo(long id, ProyeccionVentaModelo proyeccionVentaModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            proyeccionVentaModelo.Id = id;
            db.Entry(proyeccionVentaModelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyeccionVentaModeloExists(id))
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

        // POST: api/ProyeccionVenta
        [ResponseType(typeof(ProyeccionVentaModelo))]
        public IHttpActionResult PostProyeccionVentaModelo(ProyeccionVentaModelo proyeccionVentaModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProyeccionesVenta.Add(proyeccionVentaModelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proyeccionVentaModelo.Id }, proyeccionVentaModelo);
        }

        // DELETE: api/ProyeccionVenta/5
        [ResponseType(typeof(ProyeccionVentaModelo))]
        public IHttpActionResult DeleteProyeccionVentaModelo(long id)
        {
            ProyeccionVentaModelo proyeccionVentaModelo = db.ProyeccionesVenta.Find(id);
            if (proyeccionVentaModelo == null)
            {
                return NotFound();
            }

            db.ProyeccionesVenta.Remove(proyeccionVentaModelo);
            db.SaveChanges();

            return Ok(proyeccionVentaModelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProyeccionVentaModeloExists(long id)
        {
            return db.ProyeccionesVenta.Count(e => e.Id == id) > 0;
        }
    }
}