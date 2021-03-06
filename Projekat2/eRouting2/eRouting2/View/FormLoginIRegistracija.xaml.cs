﻿using System;
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
            Administratori.Add(new Administrator(1, "bla", "bla", "envera", "envera"));
            Korisnici.Add(new Korisnik(2, "ime", "prezime", "mirza", "mirza", "mail", 0, 0));
        }

        private void ButtonPrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            textGreska.Text = String.Empty;
            textPostoji.Text = String.Empty;

            Administrator traziA= Administratori.FirstOrDefault(x => x.Username == textUsername.Text && x.Password==textPass.Password);
            Korisnik traziK = Korisnici.FirstOrDefault(x => x.Username == textUsername.Text && x.Password == textPass.Password);
            if (!(traziA is null))
            {
                FormAdministrator Fa = new FormAdministrator();
                Window.Current.Content = Fa;
            }
            else if (!(traziK is null))
            {
                FormaMojProfil Fm = new FormaMojProfil(traziK);
                Window.Current.Content = Fm;
            }
            else
            {
                textGreska.Text= "Pogrešni pristupni podaci. Pokušajte ponovo.";
                textPass.Password = String.Empty;
                textUsername.Text = String.Empty;
            }
        }
        bool prazan()
        {
            if (textIme.Text == string.Empty || textPrezime.Text == string.Empty || textEmail.Text == string.Empty || textUser.Text == string.Empty || textPass1.Password == string.Empty)
                return true;
            return false;
        }

        private void buttonRegistrujSe_Click(object sender, RoutedEventArgs e)
        {
            textGreska.Text = String.Empty;
            textPostoji.Text = String.Empty;
            string ime;
            string prezime;
            string email;
            string username;
            string pass;
            ime = textIme.Text;
            prezime = textPrezime.Text;
            email=textEmail.Text;
            username = textUser.Text;

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(textPass1.Password));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
                str.Append(result[i].ToString("x2"));
            pass = str.ToString();

            Korisnik postoji = Korisnici.FirstOrDefault(x => x.Username == username);

            if (prazan())
            {
                textPostoji.Text = "Molimo unesite sve tražene podatke.";
                return;
            }
            else if (postoji != null)
            {
                textPostoji.Text = "Username već postoji. Pokušajte ponovo";
                textUser.Text = String.Empty;
                return;
            }
            else
            {
                int zadnjiId = 0;
                if (Korisnici.Count > 0)
                {
                    foreach(Korisnik kor in Korisnici)
                    {
                        if (kor.ID > zadnjiId) zadnjiId = kor.ID;
                    }
                    zadnjiId++;
                }
                Korisnik k = new Korisnik(zadnjiId, ime, prezime, username, pass, email, 0, 0);
                ViewModel2.DodajKorisnika(k);
                Korisnici.Add(k);
                textIme.Text = String.Empty;
                textPrezime.Text = String.Empty;
                textEmail.Text = String.Empty;
                textUser.Text = String.Empty;
                textPass1.Password = String.Empty;
                MessageDialog msgbox = new MessageDialog("Uspješno ste se registrovali. Prijavite se ako želite nastaviti.");
                msgbox.ShowAsync();
            }


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
