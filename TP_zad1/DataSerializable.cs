using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_zad1
{
    [XmlRoot("Biblioteka")]
    public class DataSerializable
    {
        public DataSerializable()
        {
            klienci=new List<Klient>();
            filmy=new List<Film>();
            wypozyczenia=new List<Wypozyczenie>();
            opisyStanow=new List<OpisStanu>();
        }

        [XmlElement("Klienci")]
        public List<Klient> klienci;
        [XmlElement("Filmy")]
        public List<Film> filmy;
        [XmlElement("Wypozyczenia")]
        public List<Wypozyczenie> wypozyczenia;
        [XmlElement("Opisy_stanow")]
        public List<OpisStanu> opisyStanow;

        public void copyFromDataContext(DataContext dataCtxt)
        {
            foreach (Klient klient in dataCtxt.klienci)
            {
                this.klienci.Add(klient);
            }

            foreach (KeyValuePair<int, Film> film in dataCtxt.filmy)
            {
                this.filmy.Add(film.Value);
            }

            foreach (KeyValuePair<int, OpisStanu> opisStanu in dataCtxt.opisyStanow)
            {
                this.opisyStanow.Add(opisStanu.Value);
            }

            foreach (Wypozyczenie wypozyczenie in dataCtxt.wypozyczenia)
            {
                this.wypozyczenia.Add(wypozyczenie);
            }
        }

    }
}
