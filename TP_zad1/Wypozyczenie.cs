using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    class Wypozyczenie
    {

        public Wypozyczenie(Film film, Klient klient, string terminZwrotu)
        {
            _wypozyczonyFilm = film;
            _klient = klient;
            _terminZwrotu = terminZwrotu;

        }

        

        public Film  _wypozyczonyFilm { get; set; }
        public Klient  _klient { get; set; }
        public string _terminZwrotu { get; set; }

        public string WypiszWypozyczenia()
        {
            
            if (_wypozyczonyFilm != null && _klient != null && _terminZwrotu != null)
                return ("Film: " + _wypozyczonyFilm._tytul + ", wypożyczony przez: " + _klient._nazwisko + ", termin zwrotu: " + _terminZwrotu + "\n" );
            else return "";
        }



    }
}
