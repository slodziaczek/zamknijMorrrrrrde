using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_zad1
{
    [XmlRoot("Film")]
    public class Film
    {
        public Film()
        {
        }

        // private static int numerObiektu = 0 ;
        public Film(string tytul, string rezyser, string gatunek)
        {
          //  numerObiektu = ++numerObiektu;
            _tytul = tytul;
            _rezyser = rezyser;
            _gatunek = gatunek;
        }

        [XmlElement("Tytul")]
        public string _tytul { get; set; }
        [XmlElement("Rezyser")]
        public string _rezyser { get; set; }
        [XmlElement("Gatunek")]
        public string _gatunek { get; set; }

        public string wyswietlFilmy()
        {
            

            return ("Tytul filmu: " + _tytul + ", rezyser: " + _rezyser + ", gatunek: " + _gatunek + "\n");

        }

    }



}
