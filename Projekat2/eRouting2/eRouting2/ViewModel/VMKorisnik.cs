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

        public void PrikazProfila ( string username)
        {

        }
        public void Prijava (string username, string password)
        {

        }
        public void Registracija (string ime, string prezime, string username, string password)
        {

        }
        public void ValidirajPodatke (string username, string password)
        {

        }
        public List<Dojava> UcitavanjeDojava(Korisnik k)
        {
            DBDojava DB = new DBDojava();
            DB.ucitajDojave();
            List<Dojava> dojave = DB.Dojave;
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
        public List<Korisnik> UčitavanjeKorisnika()
        {
            DBKorisnik DB = new DBKorisnik();
            DB.UcitajKorisnike();
            return DB.Korisnici;
        }
        public void DodajKorisnika(Korisnik k)
        {
            DBKorisnik DB = new DBKorisnik();
            DB.UnesiKorisnika(k);
        }
    }
}
