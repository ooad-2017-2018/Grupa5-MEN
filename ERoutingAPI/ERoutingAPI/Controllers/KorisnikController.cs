using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ERoutingAPI.Models;

namespace ERoutingAPI.Controllers
{
    public class KorisnikController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Korisnik
        public IQueryable<Korisnik> GetKorisnik()
        {
            return db.Korisnik;
        }

        // GET: api/Korisnik/5
        [ResponseType(typeof(Korisnik))]
        public async Task<IHttpActionResult> GetKorisnik(int id)
        {
            Korisnik korisnik = await db.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(korisnik);
        }

        // PUT: api/Korisnik/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKorisnik(int id, Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisnik.ID)
            {
                return BadRequest();
            }

            db.Entry(korisnik).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(id))
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

        // POST: api/Korisnik
        [ResponseType(typeof(Korisnik))]
        public async Task<IHttpActionResult> PostKorisnik(Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Korisnik.Add(korisnik);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KorisnikExists(korisnik.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = korisnik.ID }, korisnik);
        }

        // DELETE: api/Korisnik/5
        [ResponseType(typeof(Korisnik))]
        public async Task<IHttpActionResult> DeleteKorisnik(int id)
        {
            Korisnik korisnik = await db.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            db.Korisnik.Remove(korisnik);
            await db.SaveChangesAsync();

            return Ok(korisnik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisnikExists(int id)
        {
            return db.Korisnik.Count(e => e.ID == id) > 0;
        }
    }
}