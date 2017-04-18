using TP_zad1;
using System;
using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace TP_zad1.Tests
{
    [TestClass]
    public class UnitTest
    {

        

        [TestMethod]
        public void dodajKlienta()
        {
            DataRepository dr = new DataRepository();
            Klient k = new Klient("Emil", "Szczepaniak", "577960967", "emil.szczepaniak.it@gmail.com");

            Assert.IsTrue(dr.stworzKlienta(k));
        }
        [TestMethod]
        public void dodajFilmTest()
        {
            DataRepository dr = new DataRepository();
            Film fl = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");

            Assert.IsTrue(dr.dodajFilm(fl));

        }
        [TestMethod]
        public void dodajWypozyczenieTest()
        {
            DataRepository dr = new DataRepository();
            Klient klient = new Klient("Emil", "Szczepaniak", "577960967", "emil.szczepaniak.it@gmail.com");
            Film film = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");
            DateTime now = DateTime.Now;
            DateTime dt = now.AddDays(5);
            Wypozyczenie wyp = new Wypozyczenie(film, klient, now.ToString());

            Assert.IsTrue(dr.dodajWypozyczenie(wyp));
        }
        [TestMethod]
        public void dodajStanTest()
        {
            DataRepository dr = new DataRepository();
            DateTime now = DateTime.Now;
            Film film = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");
            OpisStanu os = new OpisStanu(film, "Opis", now.ToString(), 12);

            Assert.IsTrue(dr.dodajStan(os));

        }
        [TestMethod]
        public void getKlientTest()
        {
            DataRepository dr = new DataRepository();
            Klient k = new Klient("Emil", "Szczepaniak", "577960967", "emil.szczepaniak.it@gmail.com");

            dr.stworzKlienta(k);

            //oczekiwana wartosc: true
            Assert.AreEqual(k, dr.getKlient(k));
        }

        [TestMethod]
        public void getFilmTest()
        {
            DataRepository dr = new DataRepository();
            Film fl = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");

            dr.dodajFilm(fl);

            Assert.AreEqual(fl, dr.getFilm(fl));
        }
        [TestMethod]
        public void getFilmIDTest()
        {
            DataRepository dr = new DataRepository();
            DataContext dc = new DataContext();
            Film film = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");

            dc.filmy.Add(1, film);
            Assert.AreEqual(film, dc.filmy[1]);

        }

        [TestMethod]
        public void getOpisStanuIDTest()
        {
            DataRepository dr = new DataRepository();
            DataContext dc = new DataContext();
            Film film = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");
            DateTime now = DateTime.Now;
            DateTime dt = now.AddDays(5);
            OpisStanu os = new OpisStanu(film, "Opis", now.ToString(), 12);


            dc.opisyStanow.Add(1, os);
            Assert.AreEqual(os, dc.opisyStanow[1]);
        }

        [TestMethod]
        public void getWypozyczenieTest()
        {
            DataRepository dr = new DataRepository();
            Klient klient = new Klient("Emil", "Szczepaniak", "577960967", "emil.szczepaniak.it@gmail.com");
            Film film = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");
            DateTime now = DateTime.Now;
            DateTime dt = now.AddDays(5);
            Wypozyczenie wyp = new Wypozyczenie(film, klient, dt.ToString());

            dr.dodajWypozyczenie(wyp);
            Assert.AreEqual(wyp, dr.getWypozyczenie(wyp));

        }
        [TestMethod]
        public void usunKlientaTest()
        {
            DataRepository dr = new DataRepository();
            Klient klient = new Klient("Emil", "Szczepaniak", "577960967", "emil.szczepaniak.it@gmail.com");

            dr.stworzKlienta(klient);
            Assert.IsTrue(dr.usunKlienta(klient));


        }
        [TestMethod]
        public void usunOpisStanuTest()
        {
            DataRepository dr = new DataRepository();
            DataContext dc = new DataContext();
            Film film = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");
            DateTime now = DateTime.Now;
            DateTime dt = now.AddDays(5);
            OpisStanu os = new OpisStanu(film, "Opis", now.ToString(), 12);
            dc.opisyStanow.Add(1, os);
            Assert.IsTrue(dc.opisyStanow.Remove(1));
        }
        [TestMethod]
        public void usunWypozyczenieTest()
        {

            DataRepository dr = new DataRepository();
            Klient klient = new Klient("Emil", "Szczepaniak", "577960967", "emil.szczepaniak.it@gmail.com");
            Film film = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");
            DateTime now = DateTime.Now;
            DateTime dt = now.AddDays(5);
            Wypozyczenie wyp = new Wypozyczenie(film, klient, dt.ToString());

            dr.dodajWypozyczenie(wyp);

            Assert.IsTrue(dr.usunWypozecznie(wyp));

        }

        [TestMethod]
        public void usunFilmTest()
        {
            DataRepository dr = new DataRepository();
            Film film = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");
            Dictionary<int, Film> fl = new Dictionary<int, Film>();

            foreach (var filmy in dr.dataContext.filmy)
            {
                Assert.AreEqual(filmy, fl[filmy.Key]);// fl[filmy.Key] jeden obiekt slownika fl 
            }



        }

        [TestMethod]
        public void filtrowanieKlientowTest()
        {
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();
            DataRepository dataRepository = new DataRepository(wypelnianieStalymi);
            DataService dataService = new DataService(dataRepository);
            List<Klient> klienciList = null;

            klienciList = dataService.filtrowanieKlientow("Nieistniejacy");
            Assert.IsNull(klienciList);
            klienciList = dataService.filtrowanieKlientow("Szczepaniak");
            Assert.IsNotNull(klienciList);
            Assert.AreEqual("Imie: Emil, nazwisko: Szczepaniak, numer telefonu: 577960967, email: Szczepan\n\n", dataService.wyswietlKolekcjeKlientow(klienciList));

        }
        [TestMethod]
        public void filtrowanieFilmowTest()
        {
            // create FillDataRepository data object (inherits from DataInterface)
            WypelnianieStalymi data = new WypelnianieStalymi();

            // create repository using Dependency Injection pattern (pass FillDataRepository object to DataRepository constructor)
            DataRepository repository = new DataRepository(data);

            // create a data service
            DataService ds = new DataService(repository);

            // obtain a new dictionary of filtered books

            Dictionary<int, Film> dic = ds.filtrowanieFilmow("Jonathan Demme");

            // expected value: true
            Assert.AreEqual("Tytul filmu: Milczenie owiec, rezyser: Jonathan Demme, gatunek: Film kryminalny\n\n", ds.wyswietlKolekcjeFilmow(dic));

        }

        // [TestMethod]
        // public void filtrowanieWypozyczenTest()
        //{
        //    WypelnianieStalymi data = new WypelnianieStalymi();
        //    DataRepository repository = new DataRepository(data);
        //    DataContext dc = new DataContext();
        //    DataService ds = new DataService(repository);
        //    DateTime now = DateTime.Now;

           
        //    Film film = new Film("Milczenie owiec", "Jonathan Demme", "Film kryminalny");

        //    var dod = ds.dodajWypozyczenie(new Klient("Emil", "Szczepaniak", "577960967", "emil.szczepaniak.it@gmail.com"), new OpisStanu(film, "Opis", now.ToString(), 12));
        //    var kol = ds.wyswietlKolekcjeWypozyczen(dc.wypozyczenia);

        //    var exp =  ds.filtrowanieWypozyczen(now.ToString());

        //   // ObservableCollection<Wypozyczenie> wyp = ds.filtrowanieWypozyczen("");

        //    Assert.AreEqual(exp,kol);

        //}
        [TestMethod]
        public void EfficiencyTest()
        {
            Stopwatch stopWatch = new Stopwatch();
            // check the time of the static mode
            stopWatch.Start();

            // create FillDataRepositoryStatic fillData object (inherits from DataInterface)
            //FillDataRepositoryStatic fillData = new FillDataRepositoryStatic();
            WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();

            // create a repository using Dependency Injection pattern (pass FillDataRepositoryStatic object to DataRepository constructor)
            DataRepository repository = new DataRepository(wypelnianieStalymi);

            // create a data service
            DataService ds = new DataService(repository);

            // elapsed time (ms)
            stopWatch.Stop();
            double staticTime = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Reset();

            // check the time of the file mode
            stopWatch.Start();

            // create FillDataRepositoryFile fileData object (inherits from DataInterface)
            WypelnianieZPliku wypelnianieZPliku = new WypelnianieZPliku();
            // create a repository using Dependency Injection pattern (pass FillDataRepositoryFile object to DataRepository constructor)
            DataRepository dr = new DataRepository(wypelnianieZPliku);

            // create a data service 
            DataService dataService = new DataService(dr);

            // elapsed time (ms)
            stopWatch.Stop();
            double fileTime = stopWatch.Elapsed.TotalMilliseconds;

            // expected value: true
            Assert.IsTrue(fileTime > staticTime);

        }
    
    }
}
