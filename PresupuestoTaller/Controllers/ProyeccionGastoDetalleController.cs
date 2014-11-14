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
    [RoutePrefix("api/proyecciongasto/{proyeccionId}/gastos")]
    public class ProyeccionGastoDetalleController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProyeccionGastoDetalle
        [Route("")]
        public IQueryable<ProyeccionGastoDetalleModelo> GetProyeccionGastoDetalles(long proyeccionId)
        {
            return db.ProyeccionGastoDetalles.Include(x => x.Gasto).Where(x => x.ProyeccionId == proyeccionId);
        }

        [Route("{id}")]
        // GET: api/ProyeccionGastoDetalle/5
        [ResponseType(typeof(ProyeccionGastoDetalleModelo))]
        public IHttpActionResult GetProyeccionGastoDetalleModelo(long proyeccionId, long id)
        {
            ProyeccionGastoDetalleModelo proyeccionGastoDetalleModelo = db.ProyeccionGastoDetalles.Include(x => x.Gasto).FirstOrDefault(x => x.ProyeccionId == proyeccionId && x.GastoId == id);
            if (proyeccionGastoDetalleModelo == null)
            {
                return NotFound();
            }

            return Ok(proyeccionGastoDetalleModelo);
        }

        [Route("{id}")]
        // PUT: api/ProyeccionGastoDetalle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProyeccionGastoDetalleModelo(long proyeccionId, long id, ProyeccionGastoDetalleModelo proyeccionGastoDetalleModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            proyeccionGastoDetalleModelo.ProyeccionId = proyeccionId;
            proyeccionGastoDetalleModelo.GastoId = id;
            db.Entry(proyeccionGastoDetalleModelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyeccionGastoDetalleModeloExists(proyeccionId, id))
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

        [Route("")]
        // POST: api/ProyeccionGastoDetalle
        [ResponseType(typeof(ProyeccionGastoDetalleModelo))]
        public IHttpActionResult PostProyeccionGastoDetalleModelo(long proyeccionId, ProyeccionGastoDetalleModelo proyeccionGastoDetalleModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            proyeccionGastoDetalleModelo.ProyeccionId = proyeccionId;
            db.ProyeccionGastoDetalles.Add(proyeccionGastoDetalleModelo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProyeccionGastoDetalleModeloExists(proyeccionId, proyeccionGastoDetalleModelo.GastoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DetalleApi", new { parent = "proyecciongasto", child = "gastos", parentId = proyeccionId, id = proyeccionGastoDetalleModelo.GastoId }, proyeccionGastoDetalleModelo);
        }

        [Route("{id}")]
        // DELETE: api/ProyeccionGastoDetalle/5
        [ResponseType(typeof(ProyeccionGastoDetalleModelo))]
        public IHttpActionResult DeleteProyeccionGastoDetalleModelo(long proyeccionId, long id)
        {
            ProyeccionGastoDetalleModelo proyeccionGastoDetalleModelo = db.ProyeccionGastoDetalles.FirstOrDefault(x => x.ProyeccionId == proyeccionId && x.GastoId == id);
            if (proyeccionGastoDetalleModelo == null)
            {
                return NotFound();
            }

            db.ProyeccionGastoDetalles.Remove(proyeccionGastoDetalleModelo);
            db.SaveChanges();

            return Ok(proyeccionGastoDetalleModelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProyeccionGastoDetalleModeloExists(long proyeccionId, long id)
        {
            return db.ProyeccionGastoDetalles.Count(e => e.ProyeccionId == proyeccionId && e.GastoId == id) > 0;
        }
    }
}