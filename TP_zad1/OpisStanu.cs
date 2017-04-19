using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_zad1
{
    [XmlRoot("Opis_stanu")]
    public class OpisStanu
    {
        public OpisStanu()
        {
        }

        public OpisStanu(Film film, string opisFilmu, string dataZakupu, int stan)
        {
            _film = film;
            _opisFilmu = opisFilmu;
            _dataZakupu = dataZakupu;
            _stan = stan;
        }

        [XmlElement("Film")]
        public Film _film { get; set; }
        [XmlElement("Opis")]
        public string _opisFilmu { get; set; }
        [XmlElement("Data_zak")]
        public string _dataZakupu { get; set;  }
        [XmlElement("Stan")]
        public int _stan { get; set; }


        public string wyswietlOpisStanu()
        {
            return ("Opis filmu: " + _opisFilmu + ",  data zakupu: " + _dataZakupu + ", stan: " + _stan + "\n");
        }
    }
}

