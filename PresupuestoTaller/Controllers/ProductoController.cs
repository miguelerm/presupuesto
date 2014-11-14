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
    public class ProductoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Producto
        public IQueryable<ProductosModelo> GetProductosModeloes()
        {
            return db.Productos;
        }

        // GET: api/Producto/5
        [ResponseType(typeof(ProductosModelo))]
        public IHttpActionResult GetProductosModelo(long id)
        {
            ProductosModelo productosModelo = db.Productos.Find(id);
            if (productosModelo == null)
            {
                return NotFound();
            }

            return Ok(productosModelo);
        }

        // PUT: api/Producto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductosModelo(long id, ProductosModelo productosModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productosModelo.Id = id;
            db.Entry(productosModelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosModeloExists(id))
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

        // POST: api/Producto
        [ResponseType(typeof(ProductosModelo))]
        public IHttpActionResult PostProductosModelo(ProductosModelo productosModelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Productos.Add(productosModelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productosModelo.Id }, productosModelo);
        }

        // DELETE: api/Producto/5
        [ResponseType(typeof(ProductosModelo))]
        public IHttpActionResult DeleteProductosModelo(long id)
        {
            ProductosModelo productosModelo = db.Productos.Find(id);
            if (productosModelo == null)
            {
                return NotFound();
            }

            db.Productos.Remove(productosModelo);
            db.SaveChanges();

            return Ok(productosModelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductosModeloExists(long id)
        {
            return db.Productos.Count(e => e.Id == id) > 0;
        }
    }
}