using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace eRouting2
{
    public class PremiumKorisnik : IKorisnik
    {
        const double oc = 5.0;
        const int  b = 1;
        IKorisnik k;
        double ocjena;
        int brOcjena;

        public double Ocjena { get => ocjena; set => ocjena = value; }
        public int BrOcjena { get => brOcjena; set => brOcjena = value; }

        public PremiumKorisnik(int id, string ime, string prezime, string username, string password, string email, int brojDojava, int brojAktivnihDojava)
        {
            k = new Korisnik(id, ime, prezime, username, password, email, brojDojava, brojAktivnihDojava);
            Ocjena = oc;
            BrOcjena = b;

        }
        public void UrediInformacije(string ime, string prezime, string email, string username)
        {
            k.UrediInformacije(ime, prezime, email, username);
        }
        public void DodajSliku(ImageSource s)
        {
            k.DodajSliku(s);
        }
        public void Ocijeni (double o)
        {

            Ocjena = (Ocjena * brOcjena + o) / (BrOcjena+1);
            BrOcjena++;
        }
        
    }
    

}
