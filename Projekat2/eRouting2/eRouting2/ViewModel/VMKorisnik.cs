﻿using System;
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