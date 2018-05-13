using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace eRouting2
{
    public class Korisnik
    {
        int id;
        string ime;
        string prezime;
        string email;
        string username;
        string password;
        int brojDojava;
        int brojAktivnihDojava;
        ImageSource slika;
        Boolean premiumKorisnik;

        public int ID { get => id; set => id = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int BrojDojava { get => brojDojava; set => brojDojava = value; }
        public int BrojAktivnihDojava { get => brojAktivnihDojava; set => brojAktivnihDojava = value; }
        public bool PremiumKorisnik { get => premiumKorisnik; set => premiumKorisnik = value; }
        public string Email { get => email; set => email = value; }
        public ImageSource Slika { get => slika; set => slika = value; }

        public Korisnik(int id, string ime, string prezime, string username, string password, string email, int brojDojava, int brojAktivnihDojava)
        {
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Username = username;
            Password = password;
            BrojDojava = brojDojava;
            BrojAktivnihDojava = brojAktivnihDojava;
            PremiumKorisnik = false;
            Slika = new BitmapImage(new Uri("ms-appx:///Assets/profil.jpg"));
        }
        public void UrediInformacije(string ime, string prezime, string email, string username)
        {
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Username = username;
        }
        public void DodajSliku(ImageSource s)
        {
            Slika = s;
        }
    }
}
