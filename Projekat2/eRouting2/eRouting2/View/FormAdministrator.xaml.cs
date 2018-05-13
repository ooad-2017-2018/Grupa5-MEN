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
using Windows.UI.Notifications;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace eRouting2
{
    public sealed partial class FormAdministrator : Page
    {
        List<Korisnik> Korisnici;
        VMAdministrator ViewModel;
        public FormAdministrator()
        {
            this.InitializeComponent();
            ViewModel = new VMAdministrator();
            VMKorisnik vMKorisnik = new VMKorisnik();
            Korisnici = vMKorisnik.UčitavanjeKorisnika();
            for(int i=0;i<Korisnici.Count();i++)
            ListBoxKorisnici.Items.Add(Korisnici[i].Username);
            if(ListBoxKorisnici.Items.Count>0) ListBoxKorisnici.SelectedIndex = 0;
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxKorisnici.Items.Count == 0 || ListBoxKorisnici.SelectedItem==null)
            {
                TextBlockGreska.Text = "Nije odabran korisnik!";
                return;
            }
            TextBlockGreska.Text = "";
            String username = Convert.ToString(ListBoxKorisnici.SelectedItem);
            ViewModel.ObrisiKorisnika(username);
            ListBoxKorisnici.Items.Remove(username);
            TextBlockGreska.Text = "Korisnik obrisan!";
        }

        private void ButtonStatistika_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxKorisnici.Items.Count == 0 || ListBoxKorisnici.SelectedItem == null)
            {
                TextBlockGreska.Text = "Nije odabran korisnik!";
                return;
            }
            TextBlockGreska.Text = "";
            String username = Convert.ToString(ListBoxKorisnici.SelectedItem);
            Korisnik k = Korisnici.FirstOrDefault(x => x.Username == username);
            TextBoxStatistika.Visibility=Visibility.Visible;
            TextBoxStatistika.Text = "Ime i prezime: " + k.Ime + " " + k.Prezime + "\nUkupan broj dojava: " + k.BrojDojava + "\nBroj aktivnih dojava: " + k.BrojAktivnihDojava;
        }

        private void ButtonAzuriraj_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxKorisnici.Items.Count == 0 || ListBoxKorisnici.SelectedItem == null)
            {
                TextBlockGreska.Text = "Nije odabran korisnik!";
                return;
            }
            TextBlockGreska.Text = "";
            String username = Convert.ToString(ListBoxKorisnici.SelectedItem);
            Korisnik k = Korisnici.FirstOrDefault(x => x.Username == username);
            FormaMojProfil fm = new FormaMojProfil(/*k*/); //NAIDA ovdje obrisi komentar kad promijenis konstruktor forme :D
            Window.Current.Content = fm;
        }
    }
}
