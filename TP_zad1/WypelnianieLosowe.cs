using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
   public class WypelnianieLosowe : Interfejs
    {

        Random radom = new Random();
        public static string[] imiona = { "Jan", "Błażej", "Aleksander", "Hiacynt", "Wiktor", "Monika", "Wiktoria", "Genowefa", "Martyna" };
        public static string[] nazwiska = { "Nowak", "Pająk", "Stefanowicz", "Musiał" , "Wandochowicz"};
        public static string[] numeryTel = { "545980788", "985734957", "534789067","697421094", "784301043" };
        public static string[] emaile = { "jan@gmail.com", "rafal@onet.pl", "william.bitha@ericsson.com", "michal.rudnicki@ericsson.com" };

        public static string[] tytuly = { "Wojna i Pokój", "Ogniem i Mieczem", "Duma i Uprzedzenie", "Całki i Różniczki" };
        public static string[] rezyserzy = { "Jerzy Hoffman", "Jerzy Wajda", "Jim Jarmush", "Akira Kurosawa", "Ingmar Bergman" };
        public static string[] gatunki = { "komedia", "dramat", "film sensacyjny", "horror", "dreszczowiec", "komedia romantyczna" };

        public static string[] opisyStanow = { "opis1", "opis2", "opis3", "opis4", "opis5" };
        public static string[] stany = { "14", "27", "4", "12" };



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

        public string GetRandomDate(string leesOrMore)
        {
            if (leesOrMore == "less")
            {
                Random rand = new Random();
                DateTime date = new DateTime(1990, 11, 2);
                DateTime dataZw = date.AddDays(rand.Next(10, 50));
                return dataZw.ToString("dd/MM/yyyy");
            }
            else if (leesOrMore == "more")
            {
                Random rand = new Random();
                DateTime dateNow = DateTime.Now;
                DateTime dataZw = dateNow.AddDays(rand.Next(10, 50));
                return dataZw.ToString("dd/MM/yyyy");
            }
            else return "Unknown command";
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
                dataRepo.dodajWypozyczenie(new Wypozyczenie(dataRepo.dataContext.filmy[j+1], dataRepo.dataContext.klienci[j],  GetRandomDate("more")));
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
            List<Film> randomowaListaFilmow=new List<Film>();
            Random los=new Random();
            for (int i = 0; i < NumberOfPositions; i++)
            {
                randomowaListaFilmow.Add(new Film(GetRandomString(tytuly), GetRandomString(rezyserzy), GetRandomString(gatunki)));
            }

            for (int i = 0; i < NumberOfPositions; i++)
            {
                int l = los.Next(NumberOfPositions);
                dataRepo.dodajStan(new OpisStanu(randomowaListaFilmow[l], GetRandomString(opisyStanow), GetRandomDate("less"), int.Parse(GetRandomString(stany))));              
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
