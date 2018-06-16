using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRouting2
{
    class VMKorisnik
    {
        public Korisnik korisnik { get; set; }

        public List<Dojava> UcitavanjeDojava(Korisnik k)
        {
            DBDojava DB = new DBDojava();
            DB.ucitajDojave();
            //List<Dojava> dojave = DB.Dojave;
            //Ovdje se dojave trebaju učitati iz baze ali zbog nekompatibilnosti sa ASP.NET-om dojave su hardkodirane
            List<Dojava> dojave = new List<Dojava>();
            Dojava d1 = new Dojava(0, "Sudar", DateTime.Now.AddMinutes(10), "Zmaja od Bosne, Sarajevo, Bosnia and Herzegovina", 2);
            Dojava d2 = new Dojava(1, "Guzva", DateTime.Now.AddMinutes(20), "Mis Irbina, Sarajevo, Bosnia and Herzegovina", 2);
            Dojava d3 = new Dojava(2, "Sudar", DateTime.Now.AddMinutes(10), "Zmaja od Bosne, Sarajevo, Bosnia and Herzegovina", 3);
            Dojava d4 = new Dojava(3, "Sudar", DateTime.Now.AddMinutes(10), "Zmaja od Bosne, Sarajevo, Bosnia and Herzegovina", 3);
            dojave.Add(d1);
            dojave.Add(d2);
            dojave.Add(d3);
            dojave.Add(d4);
            List<Dojava> dk = new List<Dojava>();
            for (int i = 0; i < dojave.Count; i++)
            {
                if(dojave[i].KorisnikID== k.ID)
                {
                    dk.Add(dojave[i]);
                }
            }
            return dk;
        }
        public void UredjivanjeKorisnika(Korisnik k)
        {
            DBKorisnik DB = new DBKorisnik();
            DB.UrediKorisnika(k);


        }
        public bool DaLiJeDostupanUsername (string username)
        {
            //List<Korisnik> korisnici = UčitavanjeKorisnika();
            if(UčitavanjeKorisnika().FirstOrDefault(x => x.Username == username) != null)
            {
                return false;
            }
            return true;
        }
        public List<Korisnik> UčitavanjeKorisnika()
        {
            DBKorisnik DB = new DBKorisnik();
            DB.UcitajKorisnike();
            return DB.Korisnici;
            //List<Korisnik> korisnici = DB.Korisnici;
            //return korisnici;
        }
        public void DodajKorisnika(Korisnik k)
        {
            DBKorisnik DB = new DBKorisnik();
            DB.UnesiKorisnika(k);
        }
    }
}
