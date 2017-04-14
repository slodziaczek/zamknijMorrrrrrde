using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    class Film
    {
       // private static int numerObiektu = 0 ;
        public Film(string tytul, string rezyser, string gatunek)
        {
          //  numerObiektu = ++numerObiektu;
            _tytul = tytul;
            _rezyser = rezyser;
            _gatunek = gatunek;
        }

        public string _tytul { get; set; }
        public string _rezyser { get; set; }
        public string _gatunek { get; set; }

        public string wyswietlFilmy()
        {
            

            return ("Tytul filmu: " + _tytul + ", rezyser: " + _rezyser + ", gatunek: " + _gatunek + "\n");

        }

    }



}
