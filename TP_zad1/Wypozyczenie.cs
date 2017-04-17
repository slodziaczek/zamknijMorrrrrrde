using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    public class Wypozyczenie
    {

        public Wypozyczenie(Film film, Klient klient, string terminZwrotu)
        {
            DateTime loser = DateTime.Now;
            _wypozyczonyFilm = film;
            _klient = klient;
            _dataWypozyczenia = loser.ToString("dd/MM/yyyy");
            _terminZwrotu = terminZwrotu;

        }

        public Wypozyczenie(Film film, Klient klient)
        {
            DateTime loser = DateTime.Now;
            DateTime dataZw = loser.AddDays(30);
            _wypozyczonyFilm = film;
            _klient = klient;
            _dataWypozyczenia= loser.ToString("dd/MM/yyyy");
            _terminZwrotu = dataZw.ToString("dd/MM/yyyy");

        }

        public Film  _wypozyczonyFilm { get; set; }
        public Klient  _klient { get; set; }
        public string _dataWypozyczenia { get; set; }
        public string _terminZwrotu { get; set; }

        public string WypiszWypozyczenia()
        {
            
            if (_wypozyczonyFilm != null && _klient != null && _terminZwrotu != null)
                return ("Film: " + _wypozyczonyFilm._tytul + ", wypożyczony przez: " + _klient._nazwisko +", data wypożyczenia: " + _dataWypozyczenia + ", termin zwrotu: " + _terminZwrotu + "\n" );
            else return "";
        }



    }
}
