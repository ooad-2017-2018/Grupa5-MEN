using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AspNet.Models;
using Newtonsoft.Json;

namespace AspNet.Controllers
{
    //[Authorize]
    public class Korisniks1Controller : Controller
    {
        private Model1 db = new Model1();

        string apiUrl = "http://eroutingapi2018.azurewebsites.net";

        public async Task<ActionResult> Index()
        {
            List<Korisnik> korisnici = new List<Korisnik>();
            using (var client = new HttpClient())
            {

                //Postavljanje adrese URL od web api servisa 
                client.BaseAddress = new Uri(apiUrl);

                client.DefaultRequestHeaders.Clear();

                //definisanje formata koji želimo prihvatiti 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Asinhrono slanje zahtjeva za podacima o studentima 

                HttpResponseMessage Res = await client.GetAsync("api/korisnik/");

                //Provjera da li je rezultat uspješan  
                if (Res.IsSuccessStatusCode)
                {
                    //spremanje podataka dobijenih iz responsa 
                    var response = Res.Content.ReadAsStringAsync().Result;
                    korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(response);

                }

                return View(korisnici);
            }
        }
        // GET: Korisniks1

        /* public ActionResult Index()
         {
             return View(db.Korisniks.ToList());
         }
         */
        // GET: Korisniks1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Korisniks1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisniks1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,Username,Pass,Email")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                korisnik.BrojDojava = 0;
                korisnik.BrojAktivnihDojava = 0;
                
                db.Korisniks.Add(korisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisnik);
        }

        // GET: Korisniks1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,Username,Pass,Email,BrojDojava,BrojAktivnihDojava,SlikaProfila")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnik);
        }

        // GET: Korisniks1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korisnik korisnik = db.Korisniks.Find(id);
            db.Korisniks.Remove(korisnik);
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
        public ActionResult mojProfil (int id)
        {
            string username = (string)Session["username"];
            Model1 m = new Model1();
            Korisnik k = m.Korisniks.FirstOrDefault(x => x.Username == username);
            ViewData["Ime"] = k.Ime;
            ViewData["Prezime"] = k.Prezime;
            ViewData["Username"] = k.Username;
            ViewData["Email"] = k.Email;
            ViewData["Broj dojava"] = k.BrojDojava;
            ViewData["Broj aktivnih dojava"] = k.BrojAktivnihDojava;
            return View(k);        }

    }
}
