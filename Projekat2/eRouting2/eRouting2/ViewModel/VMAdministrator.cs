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
            VMKorisnik v;
            v = new VMKorisnik();
            List<Korisnik> temp = v.UčitavanjeKorisnika();
            Korisnik k = temp.FirstOrDefault(x => x.Username == username);
            if (k != null)
                DB.ObrisiKorisnika(k);
        }
        public void PrikaziStatistiku(String username)
        {

        }
      
        public List<Administrator> UcitavanjeAdministratora()
        {
            DBAdministrator DB = new DBAdministrator();
            DB.ucitajAdministratore();
            return DB.Administratori;
        }
    }
}
