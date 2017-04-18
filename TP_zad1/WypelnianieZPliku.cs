using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
   public class WypelnianieZPliku : Interfejs
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
                        var charsToRemove = new string[] { "\r","\n"};
                        foreach (var c in charsToRemove)
                        {
                            lines[i+1] = lines[i+1].Replace(c, string.Empty);
                        }
                        
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
            string tytul;
            string rezyser;
            string gatunek;
            string opisFilmu;
            string dataZakupu;
            int stan1;

            while (!sr.EndOfStream)
            {
                if (sr.ReadLine() == "Opisy stanow:")
                {
                    while (!sr.EndOfStream)
                    {
                        stan = sr.ReadLine();
                        string[] parts = stan.Split(';');
                        tytul = parts[0];
                        rezyser = parts[1];
                        gatunek = parts[2];
                        opisFilmu = parts[3];
                        dataZakupu = parts[4];
                        stan1 = int.Parse(parts[5]);


                        dataRepo.dodajStan(new OpisStanu(new Film(tytul, rezyser, gatunek), opisFilmu, dataZakupu,
                            stan1));
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
