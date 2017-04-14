using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    class DataContext
    {
        public DataContext()
        {
            klienci = new List<Klient>();
            filmy = new Dictionary<int, Film>();
            opisyStanow = new Dictionary<int,OpisStanu>();
            wypozyczenia = new ObservableCollection<Wypozyczenie>();
            
        }

        public List<Klient> klienci;
        public Dictionary<int, Film> filmy;
        public ObservableCollection<Wypozyczenie> wypozyczenia;
        public Dictionary<int, OpisStanu> opisyStanow;

    }
}
