using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    class Program
    {
        static void Main(string[] args)
        {


            
            //DateTime time = DateTime.Now;
            //Console.WriteLine(time.ToString("dd/MM/yyyy"));
            //DateTime chuj = time.AddDays(5);
            //Console.WriteLine(chuj.ToString("dd/MM/yyyy"));


            //WypelnianieStalymi ws = new WypelnianieStalymi();
            //DataRepository dr = new DataRepository(ws);

            //DataService dataService = new DataService(dr);

            WypelnianieZPliku wzp = new WypelnianieZPliku();

            DataRepository dr1 = new DataRepository(wzp);

            DataService dataService1 = new DataService(dr1);

            dataService1.testWydajnosci();

            Console.WriteLine(dataService1.wszystkieDaneString());

          //  Console.WriteLine(dataService.wyswietlKolekcjeFilmow(dr.dataContext.filmy));

           // Console.WriteLine("--------------------Klienci-----------------------");
            
           // Console.Write(dataService1.wyswietlKolekcjeKlientow(dr1.dataContext.klienci));

           //Console.Write(dataService1.wyswietlKolekcjeFilmow(dr1.dataContext.filmy));

          
            Console.Write("cokolwiek");
            // Console.WriteLine(dataService1.wyswietlKolekcjeWypozyczen(dr1.dataContext.wypozyczenia));

            Console.Write(dataService1.wyswietlKolekcjeWypozyczen(dataService1.filtrowanieWypozyczen("01-01-2018"))); //<-----------------------filtrowanie wypozyczen nie dziala...


            Console.WriteLine("--------------------------------------------------");


            //Console.WriteLine(dataService.wyswietlKolekcjeOpisowStanow(dr.dataContext.opisyStanow));

            //Console.WriteLine(dataService1.wyswietlKolekcjeWypozyczen(dr1.dataContext.wypozyczenia));

           

            //Console.WriteLine(dataService1.wszystkieDaneString());

            //WypelnianieLosowe wl = new WypelnianieLosowe();
            //DataRepository dr2 = new DataRepository(wl);

            //DataService dataService2 = new DataService(dr2);

            

            //Console.WriteLine(dataService2.wszystkieDaneString());

            

            Console.ReadKey();

        }
    }
}
