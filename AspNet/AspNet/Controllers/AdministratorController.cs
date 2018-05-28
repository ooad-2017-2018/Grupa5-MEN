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
using AspNet.Models;

namespace AspNet.Controllers
{
    public class AdministratorController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Administrator
        public IQueryable<Administrator> GetAdministrators()
        {
            return db.Administrators;
        }

        // GET: api/Administrator/5
        [ResponseType(typeof(Administrator))]
        public async Task<IHttpActionResult> GetAdministrator(int id)
        {
            Administrator administrator = await db.Administrators.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }

            return Ok(administrator);
        }

        // PUT: api/Administrator/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdministrator(int id, Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrator.ID)
            {
                return BadRequest();
            }

            db.Entry(administrator).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(id))
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

        // POST: api/Administrator
        [ResponseType(typeof(Administrator))]
        public async Task<IHttpActionResult> PostAdministrator(Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administrators.Add(administrator);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdministratorExists(administrator.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = administrator.ID }, administrator);
        }

        // DELETE: api/Administrator/5
        [ResponseType(typeof(Administrator))]
        public async Task<IHttpActionResult> DeleteAdministrator(int id)
        {
            Administrator administrator = await db.Administrators.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }

            db.Administrators.Remove(administrator);
            await db.SaveChangesAsync();

            return Ok(administrator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministratorExists(int id)
        {
            return db.Administrators.Count(e => e.ID == id) > 0;
        }
    }
}