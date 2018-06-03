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
   // [Authorize]
    public class DojavasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Dojavas
        public IQueryable<Dojava> GetDojavas()
        {
            return db.Dojavas;
        }

        // GET: api/Dojavas/5
        [ResponseType(typeof(Dojava))]
        public IHttpActionResult GetDojava(int id)
        {
            Dojava dojava = db.Dojavas.Find(id);
            if (dojava == null)
            {
                return NotFound();
            }

            return Ok(dojava);
        }

        // PUT: api/Dojavas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDojava(int id, Dojava dojava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dojava.ID)
            {
                return BadRequest();
            }

            db.Entry(dojava).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DojavaExists(id))
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

        // POST: api/Dojavas
        [ResponseType(typeof(Dojava))]
        public IHttpActionResult PostDojava(Dojava dojava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dojavas.Add(dojava);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DojavaExists(dojava.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dojava.ID }, dojava);
        }

        // DELETE: api/Dojavas/5
        [ResponseType(typeof(Dojava))]
        public IHttpActionResult DeleteDojava(int id)
        {
            Dojava dojava = db.Dojavas.Find(id);
            if (dojava == null)
            {
                return NotFound();
            }

            db.Dojavas.Remove(dojava);
            db.SaveChanges();

            return Ok(dojava);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DojavaExists(int id)
        {
            return db.Dojavas.Count(e => e.ID == id) > 0;
        }
    }
}