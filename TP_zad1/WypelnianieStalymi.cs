using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
   public class WypelnianieStalymi : Interfejs
    {
        public void WypelnijKolekcjeWypozyczen(DataRepository dataRepo)
        {
            DateTime dataWypozyczenia = DateTime.Now;
            DateTime terminZwrotuData = dataWypozyczenia.AddDays(30);
            string terminZwrotuString;
            terminZwrotuString = terminZwrotuData.ToString("dd/MM/yyyy");

            {
                for (int i = 0; i < dataRepo.dataContext.filmy.Count; i++)
                {
                    dataRepo.dodajWypozyczenie(new Wypozyczenie(dataRepo.dataContext.filmy[i + 1], dataRepo.dataContext.klienci[i], terminZwrotuString));
                 //   Console.WriteLine("Wypozyczenie: " + dataRepo.dataContext.wypozyczenia[i].WypiszWypozyczenia());
                }
            }
        }

        public void WypelnijListeKlientow(DataRepository dataRepo)
        {
            Klient klient1 = new Klient("Emil", "Szczepaniak", "577960967", "emial");
            dataRepo.stworzKlienta(klient1);
            Klient klient2 = new Klient("cos", "tam", "cos", "cos tam");
            dataRepo.stworzKlienta(klient2);
            //   Console.WriteLine("Klient: " + klient.wyswietlKlienta());

        }

        public void WypelnijListeOpisowStanow(DataRepository dataRepo)
        {
            OpisStanu opisStanu = new OpisStanu ( new Film("Twoja stara", "Twoj stary", "zubr"), "zajebista ksiazka", "o Twojej starej", 12);
            dataRepo.dodajStan(opisStanu);
            OpisStanu opisStanu2 = new OpisStanu(new Film("Twoja stara", "Twoj stary", "zubr"), "zajebista ksiazka",
                "o Twojej starej", 12);
            dataRepo.dodajStan(opisStanu2);
            // Console.WriteLine("Opis stanu: " + opisStanu.wyswietlOpisStanu());
        }

        public void WypelnijSlownikFilmow(DataRepository dataRepo)
        {
            Film opisStanu = new Film("Twoja stara", "Twoj Stary", "zubr");
            dataRepo.dodajFilm(opisStanu);
            Film film2 = new Film("Twoja stara", "Twoj Stary", "zubr");
            dataRepo.dodajFilm(film2);
            //  Console.WriteLine("OpisStanu: " + opisStanu.wyswietlFilmy());
        }
    }
}
