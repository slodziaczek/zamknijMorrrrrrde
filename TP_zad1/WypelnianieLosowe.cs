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
        public static string[] imiona = { "Jan", "Błażej", "Aleksander", "Hiacynt", "Wiktor", "Monika", "Wiktoria", "Genowefa", "Martyna" };
        public static string[] nazwiska = { "Nowak", "Pająk", "Stefanowicz", "Musiał" , "Wandochowicz"};
        public static string[] numeryTel = { "545980788", "985734957", "534789067","697421094", "784301043" };
        public static string[] emaile = { "grubyjacek@gmail.com", "rafalto@onet.pl", "william.bitha@ericsson.com", "michal.rudnicki@ericsson.com" };

        public static string[] tytuly = { "Wojna i Pokój", "Ogniem i Mieczem", "Duma i Uprzedzenie", "Całki i Różniczki" };
        public static string[] rezyserzy = { "Jerzy Hoffman", "Jerzy Wajda", "Jim Jarmush", "Akira Kurosawa", "Ingmar Bergman" };
        public static string[] gatunki = { "zubr", "bobr", "kurwa los", "lis", "wilk", "kuna", "kon", "wydra", "ryjowka", "zajac" , "to sa zwierzeta, ktore zyja w Polsce" };

        public static string[] opisyStanow = { "opis1", "opis2", "opis3", "opis4", "opis5" };
        public static string[] daty = { "14-05-2014" , "27-12-2015" , "04-04-1990" , "02-05-2016" };


        

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
            int j = 0;
            for (int i = 0; i < NumberOfPositions; i++)
            {
                dataRepo.dodajWypozyczenie(new Wypozyczenie(dataRepo.dataContext.filmy[j+1], dataRepo.dataContext.klienci[j],  GetRandomString(daty)));
                j++;
            }
        }

        public void WypelnijListeKlientow(DataRepository dataRepo)
        {
            for (int i = 0; i < NumberOfPositions; i++)
            {
                dataRepo.stworzKlienta(new Klient(GetRandomString(imiona), GetRandomString(nazwiska),GetRandomString(numeryTel),GetRandomString(emaile)));
            }
        }

        public void WypelnijListeOpisowStanow(DataRepository dataRepo)
        {
            for (int i = 0; i < NumberOfPositions; i++)
            { 
                dataRepo.dodajStan(new OpisStanu(GetRandomString(opisyStanow), GetRandomString(daty)));              
            }
        }
    

        public void WypelnijSlownikFilmow(DataRepository dataRepo)
        {
            for (int i = 0; i < NumberOfPositions; i++)
            {               
                dataRepo.dodajFilm(new Film(GetRandomString(tytuly), GetRandomString(rezyserzy), GetRandomString(gatunki)));       
            }
        }
    }
}
