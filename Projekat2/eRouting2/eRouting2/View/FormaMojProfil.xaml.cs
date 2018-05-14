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
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace eRouting2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaMojProfil : Page
    {
        Korisnik korisnik;
        List<Dojava> dojave;
        VMKorisnik ViewModel;
        public FormaMojProfil(Korisnik k)
        {
            korisnik = k;
            this.InitializeComponent();
            TextBoxIme.Text = korisnik.Ime;
            TextBoxPrezime.Text = korisnik.Prezime;
            TextBoxEmail.Text = korisnik.Email;
            TextBoxUsername.Text = korisnik.Username;
            slikaProfila.Source = korisnik.Slika;
            ViewModel = new VMKorisnik();
            dojave = ViewModel.UcitavanjeDojava(korisnik);
            for( int i=0; i<dojave.Count; i++)
            {
                ListBoxDojave.Items.Add(dojave[i].Vrsta + " " + dojave[i].Lokacija);
            }


        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FileOpenPicker izbornikFajlaSlike = new FileOpenPicker();
            izbornikFajlaSlike.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            izbornikFajlaSlike.FileTypeFilter.Add(".bmp");
            izbornikFajlaSlike.FileTypeFilter.Add(".jpeg");
            izbornikFajlaSlike.FileTypeFilter.Add(".jpg");
            izbornikFajlaSlike.FileTypeFilter.Add(".png");
            StorageFile fajlSlike = await izbornikFajlaSlike.PickSingleFileAsync();
            if (fajlSlike != null)
            {
                using (IRandomAccessStream tokFajla = await fajlSlike.OpenAsync(FileAccessMode.Read))
                {
                    BitmapImage slika = new BitmapImage();
                    slika.SetSource(tokFajla);
                    slikaProfila.Source = slika;
                    korisnik.DodajSliku(slika);
                }
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (TextBoxIme.Text == string.Empty || TextBoxPrezime.Text == string.Empty || TextBoxEmail.Text == string.Empty || TextBoxUsername.Text == string.Empty)
            {
                TextError.Text = "Polja ne smiju biti prazna";
                return;
            }
            else if (ViewModel.DaLiJeDostupanUsername(TextBoxUsername.Text) == false && korisnik.Username!=TextBoxUsername.Text)
            {
                TextError.Text = "Ovaj username vec postoji, izaberite neki drugi username";
                return;
            }
            else {
                korisnik.UrediInformacije(TextBoxIme.Text, TextBoxPrezime.Text, TextBoxEmail.Text, TextBoxUsername.Text);
                ViewModel.UredjivanjeKorisnika(korisnik);
                TextError.Text = "";
                MessageDialog msgbox = new MessageDialog("Uspješno ste uredili podatke");
                msgbox.ShowAsync();
            }

        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FormLoginIRegistracija Fr = new FormLoginIRegistracija();
            Window.Current.Content = Fr;
        }
    }
}
