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
    public class ProyeccionGastoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProyeccionGasto
        public IQueryable<ProyeccionGastoModelo> GetProyeccionGastoModeloes()
        {
            return db.ProyeccionesGasto;
        }

        // GET: api/ProyeccionGasto/5
        [ResponseType(typeof(ProyeccionGastoModelo))]
        public IHttpActionResult GetProyeccionGastoModelo(long id)
        {
            ProyeccionGastoModelo proyeccionGastoModelo = db.ProyeccionesGasto.Find(id);
            if (proyeccionGastoModelo == null)
            {
                return NotFound();
            }

            return Ok(proyeccionGastoModelo);
        }

        // PUT: api/ProyeccionGasto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProyeccionGastoModelo(long id, ProyeccionGastoModelo proyeccionGastoModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            proyeccionGastoModelo.Id = id;
            db.Entry(proyeccionGastoModelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyeccionGastoModeloExists(id))
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

        // POST: api/ProyeccionGasto
        [ResponseType(typeof(ProyeccionGastoModelo))]
        public IHttpActionResult PostProyeccionGastoModelo(ProyeccionGastoModelo proyeccionGastoModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProyeccionesGasto.Add(proyeccionGastoModelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proyeccionGastoModelo.Id }, proyeccionGastoModelo);
        }

        // DELETE: api/ProyeccionGasto/5
        [ResponseType(typeof(ProyeccionGastoModelo))]
        public IHttpActionResult DeleteProyeccionGastoModelo(long id)
        {
            ProyeccionGastoModelo proyeccionGastoModelo = db.ProyeccionesGasto.Find(id);
            if (proyeccionGastoModelo == null)
            {
                return NotFound();
            }

            db.ProyeccionesGasto.Remove(proyeccionGastoModelo);
            db.SaveChanges();

            return Ok(proyeccionGastoModelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProyeccionGastoModeloExists(long id)
        {
            return db.ProyeccionesGasto.Count(e => e.Id == id) > 0;
        }
    }
}