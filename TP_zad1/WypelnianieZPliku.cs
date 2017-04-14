using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    class WypelnianieZPliku : Interfejs
    {
        public void WypelnijKolekcjeWypozyczen(DataRepository dataRepo)
        {
            StreamReader sr = new StreamReader("../../../data.txt");
            string text = sr.ReadToEnd();
            string[] lines = text.Split('\n');
            int j = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Terminy zwrotu:"))
                {
                    while (!lines[i + 1].Contains("Opisy stanow:"))
                    {
                        
                        dataRepo.dodajWypozyczenie(new Wypozyczenie(dataRepo.dataContext.filmy[j + 1], dataRepo.dataContext.klienci[j], lines[i + 1]));
                        i++;
                        j++;
                    }

                }

                sr.Close();
            }

        }

        public void WypelnijListeKlientow(DataRepository dataRepo)
        {

            StreamReader sr = new StreamReader("../../../data.txt");
            string text = sr.ReadToEnd();
            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Klienci:"))
                {
                    while (!lines[i + 1].Contains("Filmy:"))
                    {
                        string[] data = lines[i + 1].Split(';');
                        dataRepo.stworzKlienta(new Klient(data[0], data[1], data[2], data[3]));
                        i++;
                    }

                }
                sr.Close();
            }

        }

        public void WypelnijListeOpisowStanow(DataRepository dataRepo)
        {
           

            StreamReader sr = new StreamReader("../../../data.txt");
            string stan = "";
            string opisFilmu;
            string dataZakupu;
            while (!sr.EndOfStream)
            {
                if (sr.ReadLine() == "Opisy stanow:")
                {
                    while (!sr.EndOfStream)
                    {
                        stan = sr.ReadLine();
                        string[] parts = stan.Split(';');
                        opisFilmu = parts[0];
                        dataZakupu = parts[1];

                        dataRepo.dodajStan(new OpisStanu(opisFilmu, dataZakupu));
                    }
                }

            }
            sr.Close();
        }

        public void WypelnijSlownikFilmow(DataRepository dataRepo)
        {
            StreamReader sr = new StreamReader("../../../data.txt");
            string text = sr.ReadToEnd();
            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Filmy:"))
                {
                    while (!lines[i + 1].Contains("Terminy zwrotu:"))
                    {
                        string[] data = lines[i + 1].Split(';');
                        dataRepo.dodajFilm(new Film(data[0], data[1], data[2]));
                        i++;
                    }

                }
                sr.Close();
            }
        }
    }
}
