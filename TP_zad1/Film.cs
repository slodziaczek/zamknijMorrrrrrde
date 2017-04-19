using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_zad1
{
    [XmlRoot("Chuj")]
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

        public bool Equals(Film obj)
        {
            List<bool> isEqual = new List<bool>();
            int counter = 0;

            if(this._gatunek==obj._gatunek)
                isEqual.Add(true);
            else
                isEqual.Add(false);

            if (this._rezyser == obj._rezyser)
                isEqual.Add(true);
            else
                isEqual.Add(false);

            if (this._tytul == obj._tytul)
                isEqual.Add(true);
            else
                isEqual.Add(false);

            foreach (var ise in isEqual)
            {
                if (ise == true)
                    counter++;
            }

            if (counter == isEqual.Count)
                return true;
            else
                return false;
        }

        public string wyswietlFilmy()
        {
            

            return ("Tytul filmu: " + _tytul + ", rezyser: " + _rezyser + ", gatunek: " + _gatunek + "\n");

        }

    }



}
