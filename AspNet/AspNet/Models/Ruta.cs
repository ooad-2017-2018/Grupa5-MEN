using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet.Models
{
    public class Ruta
    {
        int id;
        string start;
        string kraj;
        DateTime vrijemePutovanja;

        public Ruta(int id,string start, string kraj, DateTime vrijemePutovanja)
        {
            Id = id;
            Start = start;
            Kraj = kraj;
            VrijemePutovanja = vrijemePutovanja;
        }

        public string Start { get => start; set => start = value; }
        public string Kraj { get => kraj; set => kraj = value; }
        public DateTime VrijemePutovanja { get => vrijemePutovanja; set => vrijemePutovanja = value; }
        public int Id { get => id; set => id = value; }
    }
}