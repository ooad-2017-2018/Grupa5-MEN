using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRouting2
{
    public class VMAdministrator
    {
        public Administrator Admin { get; set; }
        public void ObrisiKorisnika(String username)
        {
            DBKorisnik DB = new DBKorisnik();
            List<Korisnik> temp = this.UčitavanjeKorisnika();
            Korisnik k = temp.FirstOrDefault(x => x.Username == username);
            if (k != null) DB.ObrisiKorisnika(k);
        }
        public void PrikaziStatistiku(String username)
        {

        }
        public List<Korisnik> UčitavanjeKorisnika()
        {
            DBKorisnik DB = new DBKorisnik();
            DB.UcitajKorisnike();
            return DB.Korisnici;
        }
    }
}
