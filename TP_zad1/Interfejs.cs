using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
   public interface Interfejs
    {
        void WypelnijListeKlientow(DataRepository dataRepo);
        void WypelnijSlownikFilmow(DataRepository dataRepo);
        void WypelnijKolekcjeWypozyczen(DataRepository dataRepo);
        void WypelnijListeOpisowStanow(DataRepository dataRepo);
    }
}
