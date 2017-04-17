using TP_zad1;
using System;
using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TP_zad1.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void stworzKlienta()
        {
            DataRepository dr = new DataRepository();
            Klient k = new Klient("Emil", "Szczepaniak", "577960967", "emil.szczepaniak.it@gmail.com");

            Assert.IsTrue(dr.stworzKlienta(k));
        }
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

        [TestMethod()]
        public void WypelnijKolekcjeWypozyczenTest()
        {
           WypelnianieStalymi wypelnianieStalymi = new WypelnianieStalymi();

            DataRepository dataRepository = new DataRepository(wypelnianieStalymi);

            DataService dataService = new DataService(dataRepository);

            List<Klient> klienciList = null;
            klienciList = dataService.filtrowanieKlientow("Szczepaniak");
            List<Klient> klienciList1 = new List<Klient>();
            klienciList1.Add(new Klient("Emil", "Szczepaniak", "577960967", "emial"));

            foreach (var klienci in klienciList)
            {
                Assert.AreEqual(klienci, klienciList1[0]);
                    
            }
        
            


        }

     


        //[TestMethod]
        //public void getKlienciTest()
        //{
        //    DataContext dc = new DataContext();
        //    DataRepository dr = new DataRepository();
        //    List<Klient> kl = new List<Klient>();
        //    Klient klient = new Klient("Emil", "Szczepaniak", "577960967", "emil.szczepaniak.it@gmail.com");

        //    dc.klienci.Add(klient);
        //    kl.Add(klient);


        //    //dc.klienci;
        //    //dr.getKlienci(); // CO JEST ??????


        //    Assert.AreEqual(dr.getKlienci(),kl);


        //}
    }
}
