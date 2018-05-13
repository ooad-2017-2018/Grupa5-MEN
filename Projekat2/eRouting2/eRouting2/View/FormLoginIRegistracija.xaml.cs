using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Security.Cryptography;
using System.Text;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace eRouting2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class FormLoginIRegistracija : Page
    {

        List<Korisnik> Korisnici;
        List<Administrator> Administratori;
        VMAdministrator ViewModel;
        VMKorisnik ViewModel2;
        public FormLoginIRegistracija()
        {
            this.InitializeComponent();
            ViewModel = new VMAdministrator();
            ViewModel2 = new VMKorisnik();
            Korisnici = ViewModel2.UčitavanjeKorisnika();
            Administratori = ViewModel.UcitavanjeAdministratora();
            Administratori.Add(new Administrator(1, "bla", "ha", "envera", "envera"));
        }

        private void ButtonPrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            Administrator traziA= Administratori.FirstOrDefault(x => x.Username == textUsername.Text && x.Password==textPass.Password);
            Korisnik traziK = Korisnici.FirstOrDefault(x => x.Username == textUsername.Text && x.Password == textPass.Password);
            if (!(traziA is null))
            {
                FormAdministrator Fa = new FormAdministrator();
                Window.Current.Content = Fa;
            }
            else if (!(traziK is null))
            {
                FormaMojProfil Fm = new FormaMojProfil();
                Window.Current.Content = Fm;
            }
            else
            {
                textGreska.Text= "Pogrešni pristupni podaci. Pokušajte ponovo.";
                textPass.Password = String.Empty;
                textUsername.Text = String.Empty;
            }
        }

        private void buttonRegistrujSe_Click(object sender, RoutedEventArgs e)
        {
            string ime;
            string prezime;
            string email;
            string username;
            string pass;
            ime = textIme.Text;
            prezime = textPrezime.Text;
            email=textEmail.Text;
            username = textUser.Text;
            pass = textPass1.Password;
            Korisnik k = new Korisnik(0, ime, prezime, username, pass, email, 0, 0);
            ViewModel2.DodajKorisnika(k);
            Korisnici.Add(k);
            MessageDialog msgbox = new MessageDialog("Uspješno ste se registrovali. Prijavite se ako želite nastaviti.");
            msgbox.ShowAsync();



        }
        public string getMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
                str.Append(result[i].ToString("x2"));
            return str.ToString();
        }
    }
}
