using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_zad1
{
    class Program
    {
        static void Main(string[] args)
        {

            WypelnianieStalymi wzp=new WypelnianieStalymi();

            //WypelnianieZPliku wzp = new WypelnianieZPliku();

            DataRepository dr1 = new DataRepository(wzp);

            DateTime dataWypozyczenia = DateTime.Now;
            DateTime terminZwrotuData = dataWypozyczenia.AddDays(30);
            String terminZwrotuString = terminZwrotuData.ToString("dd/MM/yyyy");
            DataService dataService1 = new DataService(dr1);

            Console.WriteLine(dataService1.wszystkieDaneString());

          //  Console.WriteLine(dataService.wyswietlKolekcjeFilmow(dr.dataContext.filmy));

           // Console.WriteLine("--------------------Klienci-----------------------");
            
           // Console.Write(dataService1.wyswietlKolekcjeKlientow(dr1.dataContext.klienci));

           //Console.Write(dataService1.wyswietlKolekcjeFilmow(dr1.dataContext.filmy));

          
            // Console.WriteLine(dataService1.wyswietlKolekcjeWypozyczen(dr1.dataContext.wypozyczenia));
            Console.WriteLine("Wyfiltrowane filmy: ");
            Console.Write(dataService1.wyswietlKolekcjeWypozyczen(dataService1.filtrowanieWypozyczen("01-01-2018"))); //<-----------------------filtrowanie wypozyczen nie dziala...


            Console.WriteLine("--------------------------------------------------");


            Console.WriteLine("Serializacja XML");
            Serializacja.saveToXml(dr1.dataContext);


            Console.WriteLine("Stan kolekcji przed deserializacją:");
            Console.WriteLine(dataService1.wszystkieDaneString());

            dr1.dataContext = Serializacja.readFromXml();

            Console.WriteLine("Stan kolekcji po deserializacji:");
            Console.WriteLine(dataService1.wszystkieDaneString());

            Serializacja.saveSingleObjectToXml(dr1.getFilm(new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny")));
            Serializacja.saveSingleObjectToXml(dr1.getKlient(new Klient("Emil", "Szczepaniak", "577960967", "Szczepan")));
            Serializacja.saveSingleObjectToXml(dr1.getOpisStanu(new OpisStanu(new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny"), "dobry film", "opowiada o...", 12)));
            Serializacja.saveSingleObjectToXml(dr1.getWypozyczenie(new Wypozyczenie(new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny"), new Klient("Emil", "Szczepaniak", "577960967", "Szczepan"), terminZwrotuString)));


            Console.ReadKey();

        }
    }


}
