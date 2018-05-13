﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRouting2
{
    public class Korisnik
    {
        static int globalID;
        int id;
        string ime;
        string prezime;
        string email;
        string username;
        string password;
        int brojDojava;
        int brojAktivnihDojava;
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

        public Korisnik(int id, string ime, string prezime, string username, string password, string email, int brojDojava, int brojAktivnihDojava)
        {
            globalID++;
            id = globalID;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Username = username;
            Password = password;
            BrojDojava = brojDojava;
            BrojAktivnihDojava = brojAktivnihDojava;
            PremiumKorisnik = false;
        }

    }
}