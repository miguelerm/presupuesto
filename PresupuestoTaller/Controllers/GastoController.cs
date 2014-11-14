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
    public class GastoController : ApiController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Gasto
        public IQueryable<GastoModelo> GetGastoModeloes()
        {
           return db.Gastos;
        }

        // GET: api/Gasto/5
        [ResponseType(typeof(GastoModelo))]
        public IHttpActionResult GetGastoModelo(long id)
        {
            GastoModelo gastoModelo = db.Gastos.Find(id);
            if (gastoModelo == null)
            {
                return NotFound();
            }

            return Ok(gastoModelo);
        }

        // PUT: api/Gasto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGastoModelo(long id, GastoModelo gastoModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            gastoModelo.Id = id;
            db.Entry(gastoModelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GastoModeloExists(id))
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

        // POST: api/Gasto
        [ResponseType(typeof(GastoModelo))]
        public IHttpActionResult PostGastoModelo(GastoModelo gastoModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gastos.Add(gastoModelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gastoModelo.Id }, gastoModelo);
        }

        // DELETE: api/Gasto/5
        [ResponseType(typeof(GastoModelo))]
        public IHttpActionResult DeleteGastoModelo(long id)
        {
            GastoModelo gastoModelo = db.Gastos.Find(id);
            if (gastoModelo == null)
            {
                return NotFound();
            }

            db.Gastos.Remove(gastoModelo);
            db.SaveChanges();

            return Ok(gastoModelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GastoModeloExists(long id)
        {
            return db.Gastos.Count(e => e.Id == id) > 0;
        }
    }
}