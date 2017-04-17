using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    public class OpisStanu
    {
       
        
        public OpisStanu(Film film, string opisFilmu, string dataZakupu, int stan)
        {
            _film = film;
            _opisFilmu = opisFilmu;
            _dataZakupu = dataZakupu;
            _stan = stan;
        }


        public Film _film { get; }
        public string _opisFilmu { get; }
        public string _dataZakupu { get; }
        public int _stan { get; set; }


        public string wyswietlOpisStanu()
        {
            return ("Opis filmu: " + _opisFilmu + ",  data zakupu: " + _dataZakupu + ", stan: " + _stan + "\n");
        }
    }
}

