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
            Klient klient1 = new Klient("Emil", "Szczepaniak", "577960967", "Szczepan");
            dataRepo.stworzKlienta(klient1);
            Klient klient2 = new Klient("Malgorzata", "Patora", "123321123", "Patora");
            dataRepo.stworzKlienta(klient2);
            //Console.WriteLine("Klient: " + klient1.wyswietlKlienta());

        }

        public void WypelnijListeOpisowStanow(DataRepository dataRepo)
        {
            OpisStanu opisStanu = new OpisStanu(new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny"), "dobry film", "opowiada o...", 12);
            dataRepo.dodajStan(opisStanu);
            OpisStanu opisStanu2 = new OpisStanu(new Film("Harry Potter", "rezyser", "sci"), "jest ok", "o...", 12);
            dataRepo.dodajStan(opisStanu2);
            // Console.WriteLine("Opis stanu: " + opisStanu.wyswietlOpisStanu());
        }

        public void WypelnijSlownikFilmow(DataRepository dataRepo)
        {
            Film opisStanu = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");
            dataRepo.dodajFilm(opisStanu);
            Film film2 = new Film("Harry Potter", "rezyser", "sci");
            dataRepo.dodajFilm(film2);
            //  Console.WriteLine("OpisStanu: " + opisStanu.wyswietlFilmy());
        }
    }
}
