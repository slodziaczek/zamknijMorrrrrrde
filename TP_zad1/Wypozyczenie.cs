using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_zad1
{
    [XmlRoot("Wypozyczenie")]
    public class Wypozyczenie
    {
        public Wypozyczenie()
        {
        }

        public Wypozyczenie(Film film, Klient klient, string terminZwrotu)
        {
            DateTime loser = DateTime.Now;
            _wypozyczonyFilm = film;
            _klient = klient;
            _dataWypozyczenia = loser.ToString("dd-MM-yyyy");
            _terminZwrotu = terminZwrotu;

        }

        public Wypozyczenie(Film film, Klient klient)
        {
            DateTime loser = DateTime.Now;
            DateTime dataZw = loser.AddDays(30);
            _wypozyczonyFilm = film;
            _klient = klient;
            _dataWypozyczenia= loser.ToString("dd-MM-yyyy");
            _terminZwrotu = dataZw.ToString("dd-MM-yyyy");

        }

        [XmlElement("Film")]
        public Film  _wypozyczonyFilm { get; set; }
        [XmlElement("Klient")]
        public Klient  _klient { get; set; }
        [XmlElement("Data_wyp")]
        public string _dataWypozyczenia { get; set; }
        [XmlElement("Data_zw")]
        public string _terminZwrotu { get; set; }

        public bool Equals(Wypozyczenie obj)
        {
            List<bool> isEqual=new List<bool>();
            int counter = 0;

            if(this._klient.Equals(obj._klient))
                isEqual.Add(true);
            else 
                isEqual.Add(false);

            if (this._wypozyczonyFilm.Equals(obj._wypozyczonyFilm))
                isEqual.Add(true);
            else
                isEqual.Add(false);

            if (this._terminZwrotu == obj._terminZwrotu)
                isEqual.Add(true);
            else
                isEqual.Add(false);

            if (this._dataWypozyczenia==obj._dataWypozyczenia)
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

        public string WypiszWypozyczenia()
        {
            
            if (_wypozyczonyFilm != null && _klient != null && _terminZwrotu != null)
                return ("Film: " + _wypozyczonyFilm._tytul + ", wypożyczony przez: " + _klient._nazwisko +", data wypożyczenia: " + _dataWypozyczenia + ", termin zwrotu: " + _terminZwrotu + "\n" );
            else return "";
        }



    }
}
