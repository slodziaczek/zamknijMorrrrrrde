using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    interface Interfejs
    {
        void WypelnijListeKlientow(DataRepository dataRepo);
        void WypelnijSlownikFilmow(DataRepository dataRepo);
        void WypelnijKolekcjeWypozyczen(DataRepository dataRepo);
        void WypelnijListeOpisowStanow(DataRepository dataRepo);
    }
}
