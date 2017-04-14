using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    class WypelnianieLosowe : Interfejs
    {

        Random radom = new Random();
        public static string[] imiona = { "Jan", "Błażej", "Aleksander", "Hiacynt", "Wiktor", "Monika", "Wiktoria", "Genowefa", "Anna", "Martyna" };
        public static string[] nazwiska = { "Nowak", "Pająk", "Stefanowicz", "Musiał" };
        public static string[] tytuly = { "Wojna i Pokój", "Ogniem i Mieczem", "Duma i Uprzedzenie", "Całki i Różniczki" };

        private int numberOfPos = 10;
        public int NumberOfPositions
        {
            get { return numberOfPos; }
            set { if (value >= 0) numberOfPos = value; }
        }

        public string GetRandomString(string[] tab)
        {
            int num = radom.Next(tab.Length);
            return tab[num];
        }

        public WypelnianieLosowe() { }
        public WypelnianieLosowe(int ile)
        {
            NumberOfPositions = ile;
        }

        public void WypelnijKolekcjeWypozyczen(DataRepository dataRepo)
        {
            throw new NotImplementedException();
        }

        public void WypelnijListeKlientow(DataRepository dataRepo)
        {
            throw new NotImplementedException();
        }

        public void WypelnijListeOpisowStanow(DataRepository dataRepo)
        {
            throw new NotImplementedException();
        }

        public void WypelnijSlownikFilmow(DataRepository dataRepo)
        {
            throw new NotImplementedException();
        }
    }
}
