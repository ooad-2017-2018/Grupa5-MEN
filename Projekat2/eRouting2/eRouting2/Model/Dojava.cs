using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum vrstaDojave
{
    saobracajnaNesreca, radoviNaPutu, odron, guzva
}
namespace eRouting2
{
    public class Dojava
    {
        //private korisnik 
        private int id;
        private vrstaDojave vrsta;
        private List<int> ocjene;
        private DateTime procjenaCekanja;
        private string lokacija;

        public List<int> Ocjene { get => ocjene; set => ocjene = value; }
        public DateTime ProcjenaCekanja { get => procjenaCekanja; set => procjenaCekanja = value; }
        internal vrstaDojave Vrsta { get => vrsta; set => vrsta = value; }
        public int Id { get => id; set => id = value; }
        public string Lokacija { get => lokacija; set => lokacija = value; }

        public Dojava(int id, vrstaDojave vrsta, List<int> ocjene, DateTime procjenaCekanja, string lokacija)
        {
            Id = id;
            Vrsta = vrsta;
            Ocjene = new List<int>();
            ProcjenaCekanja = procjenaCekanja;
            Lokacija = lokacija;
        }
    }
}
