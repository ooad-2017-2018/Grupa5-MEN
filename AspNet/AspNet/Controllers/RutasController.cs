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
using AspNet.Models;

namespace AspNet.Controllers
{
    //[Authorize]
    public class RutasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Rutas
        public IQueryable<Ruta> GetRutas()
        {
            return db.Rutas;
        }

        // GET: api/Rutas/5
        [ResponseType(typeof(Ruta))]
        public IHttpActionResult GetRuta(int id)
        {
            Ruta ruta = db.Rutas.Find(id);
            if (ruta == null)
            {
                return NotFound();
            }

            return Ok(ruta);
        }

        // PUT: api/Rutas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRuta(int id, Ruta ruta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ruta.Id)
            {
                return BadRequest();
            }

            db.Entry(ruta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutaExists(id))
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

        // POST: api/Rutas
        [ResponseType(typeof(Ruta))]
        public IHttpActionResult PostRuta(Ruta ruta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rutas.Add(ruta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ruta.Id }, ruta);
        }

        // DELETE: api/Rutas/5
        [ResponseType(typeof(Ruta))]
        public IHttpActionResult DeleteRuta(int id)
        {
            Ruta ruta = db.Rutas.Find(id);
            if (ruta == null)
            {
                return NotFound();
            }

            db.Rutas.Remove(ruta);
            db.SaveChanges();

            return Ok(ruta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RutaExists(int id)
        {
            return db.Rutas.Count(e => e.Id == id) > 0;
        }
    }
}