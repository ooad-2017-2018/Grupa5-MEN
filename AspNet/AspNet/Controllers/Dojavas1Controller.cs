using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNet.Models;

namespace AspNet.Controllers
{
    public class Dojavas1Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: Dojavas1
        public ActionResult Index()
        {
            var dojavas = db.Dojavas.Include(d => d.Korisnik).Include(d => d.Korisnik1);
            return View(dojavas.ToList());
        }

        // GET: Dojavas1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dojava dojava = db.Dojavas.Find(id);
            if (dojava == null)
            {
                return HttpNotFound();
            }
            return View(dojava);
        }

        // GET: Dojavas1/Create
        public ActionResult Create()
        {
            ViewBag.Posiljalac = new SelectList(db.Korisniks, "ID", "Ime");
            ViewBag.ZadnjiIzmjenio = new SelectList(db.Korisniks, "ID", "Ime");
            return View();
        }

        // POST: Dojavas1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mjesto,VrijemeDojave,TrajanjeDojave,Posiljalac,ZadnjiIzmjenio")] Dojava dojava)
        {
            if (ModelState.IsValid)
            {
                db.Dojavas.Add(dojava);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Posiljalac = new SelectList(db.Korisniks, "ID", "Ime", dojava.Posiljalac);
            ViewBag.ZadnjiIzmjenio = new SelectList(db.Korisniks, "ID", "Ime", dojava.ZadnjiIzmjenio);
            return View(dojava);
        }

        // GET: Dojavas1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dojava dojava = db.Dojavas.Find(id);
            if (dojava == null)
            {
                return HttpNotFound();
            }
            ViewBag.Posiljalac = new SelectList(db.Korisniks, "ID", "Ime", dojava.Posiljalac);
            ViewBag.ZadnjiIzmjenio = new SelectList(db.Korisniks, "ID", "Ime", dojava.ZadnjiIzmjenio);
            return View(dojava);
        }

        // POST: Dojavas1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Mjesto,VrijemeDojave,TrajanjeDojave,Posiljalac,ZadnjiIzmjenio")] Dojava dojava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dojava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Posiljalac = new SelectList(db.Korisniks, "ID", "Ime", dojava.Posiljalac);
            ViewBag.ZadnjiIzmjenio = new SelectList(db.Korisniks, "ID", "Ime", dojava.ZadnjiIzmjenio);
            return View(dojava);
        }

        // GET: Dojavas1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dojava dojava = db.Dojavas.Find(id);
            if (dojava == null)
            {
                return HttpNotFound();
            }
            return View(dojava);
        }

        // POST: Dojavas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dojava dojava = db.Dojavas.Find(id);
            db.Dojavas.Remove(dojava);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
