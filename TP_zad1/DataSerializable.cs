using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_zad1
{
    [XmlRoot("pedał")]
    public class DataSerializable
    {
        public DataSerializable()
        {
            klienci=new List<Klient>();
            filmy=new List<Film>();
            wypozyczenia=new List<Wypozyczenie>();
            opisyStanow=new List<OpisStanu>();
        }

        [XmlElement("Chuj1")]
        public List<Klient> klienci;
        [XmlElement("Chuj2")]
        public List<Film> filmy;
        [XmlElement("Chuj3")]
        public List<Wypozyczenie> wypozyczenia;
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
