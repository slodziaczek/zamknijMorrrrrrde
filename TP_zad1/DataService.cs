using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
   public class DataService
    {

        public DataService(DataRepository dataRepo)
            {
            _dataRepo = dataRepo;
            _dataRepo.dataContext.wypozyczenia.CollectionChanged += new NotifyCollectionChangedEventHandler(zmianaWKolekcji);

        }

        private DataRepository _dataRepo;

        private void zmianaWKolekcji(object s, NotifyCollectionChangedEventArgs zdarzenie)
        {
            if (zdarzenie.Action.Equals(NotifyCollectionChangedAction.Add))
            {
                foreach (Wypozyczenie wypozyczenie in zdarzenie.NewItems)
                {
                    Console.WriteLine("Nowe wypozyczenie: " + wypozyczenie.WypiszWypozyczenia());
                }
            }
            if (zdarzenie.Action.Equals(NotifyCollectionChangedAction.Remove))
            {
                foreach (Wypozyczenie wypozyczenie in zdarzenie.OldItems)
                {
                    Console.WriteLine("Wypozyczyenie usuniete" + wypozyczenie.WypiszWypozyczenia());
                }
            }
        }


        public bool dodajWypozyczenie(Klient klient, OpisStanu opisStanu)
        {
            if (opisStanu._stan > 0)
            {
                opisStanu._stan--;
                _dataRepo.dodajWypozyczenie(new Wypozyczenie(opisStanu._film, klient));         
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool usunWypozyczenie(Klient klient, OpisStanu opisStanu)
        {
            opisStanu._stan++;
            _dataRepo.usunWypozecznie(new Wypozyczenie(opisStanu._film, klient));
            return true;
        }

        public string wyswietlKolekcjeFilmow(Dictionary<int, Film> filmy)  // tutaj mozemy przekazywac pofiltrowana kolekcje
        {
            string spisFilmow = "";
            if (filmy != null)
            {
                foreach (KeyValuePair<int, Film> film in filmy)
                {
                    spisFilmow += film.Value.wyswietlFilmy();
                }
            spisFilmow += "\n";
        }
            return spisFilmow;
        }

        public string wyswietlKolekcjeKlientow(List<Klient> klienci) // tutaj toże
        {
            string spisKlientow = "";
            if (klienci != null)
            {
                foreach (Klient klient in klienci)
                {
                    spisKlientow += klient.wyswietlKlienta();
                }
                spisKlientow += "\n";
            }
            return spisKlientow;
        }

        public string wyswietlKolekcjeWypozyczen(ObservableCollection<Wypozyczenie> wypozyczenia)
        {
            string spisWypozyczen = "";
            foreach (Wypozyczenie wypozyczenie in wypozyczenia)
            {
                spisWypozyczen += wypozyczenie.WypiszWypozyczenia();
            }
            spisWypozyczen += "\n";
            return spisWypozyczen;
        }

        public string wyswietlKolekcjeOpisowStanow(Dictionary<int, OpisStanu> opisyStanow) 
        {
            string spisOpisowStanow = "";
            if (opisyStanow != null)
            {
                foreach (KeyValuePair<int, Film> film in _dataRepo.dataContext.filmy)
                {
                    foreach (KeyValuePair<int, OpisStanu> opisStanu in _dataRepo.dataContext.opisyStanow)
                    {
                        if (opisStanu.Key == film.Key)
                            spisOpisowStanow += "Tytul filmu: " + film.Value._tytul + ", " + opisStanu.Value.wyswietlOpisStanu();
                    }
                }
                spisOpisowStanow += "\n";
            }
            return spisOpisowStanow;
        }

        public string daneKlientowString()
        {
            string daneKlientow = "";
            foreach (Klient klient in _dataRepo.dataContext.klienci)
            {
               daneKlientow += klient.wyswietlKlienta();
            }
            daneKlientow += "\n";
            if (daneKlientow != "\n") return daneKlientow;
            else return null;
        }
        
        public string daneFilmowString()
        {
            string daneFilmow = "";
            foreach (KeyValuePair<int, Film> film in _dataRepo.dataContext.filmy)
            {
                daneFilmow += film.Value.wyswietlFilmy();
            }
            daneFilmow += "\n";
            if (daneFilmow != "") return daneFilmow;
            else return null;
        }

        public string daneWypozyczenString()
        {
            string daneWypozyczen = "";
            foreach (Wypozyczenie wypozyczenie in _dataRepo.dataContext.wypozyczenia)
            {
                daneWypozyczen += wypozyczenie.WypiszWypozyczenia();
            }
            daneWypozyczen += "\n";
            if (daneWypozyczen != "\n") return daneWypozyczen;
            else return null;

        }

        public string daneOpisowStanowString()
        {
            string daneOpisowStanow = "";

            foreach (KeyValuePair<int, Film> film in _dataRepo.dataContext.filmy)
            {
                foreach (KeyValuePair<int, OpisStanu> opisStanu in _dataRepo.dataContext.opisyStanow)
                {
                    if (opisStanu.Key == film.Key)
                    daneOpisowStanow += "Tytul filmu: " + film.Value._tytul + ", " + opisStanu.Value.wyswietlOpisStanu()  ;
                }
            }
            daneOpisowStanow += "\n";
            if (daneOpisowStanow != "\n") return daneOpisowStanow;
            else return null;

        }


        public string wszystkieDaneString()
        {
            string wypozyczenia = "Wypozyczenia: \n\n";
            string klienci = "Klienci: \n\n";
            klienci += daneKlientowString();
            string filmy = "Filmy: \n\n";
            filmy += daneFilmowString();
            string opisyStanow = "Opisy stanow: \n\n";
            opisyStanow += daneOpisowStanowString();
            if (_dataRepo.dataContext.wypozyczenia.Count !=0 )
            {
                foreach (Wypozyczenie wypozyczenie in _dataRepo.dataContext.wypozyczenia)
                {
                    wypozyczenia += wypozyczenie.WypiszWypozyczenia();
                }
                wypozyczenia += "\n";
            }
            return klienci + filmy + wypozyczenia + opisyStanow;
        }

        public Dictionary<int, Film> filtrowanieFilmow(string rezyserFilmow)
        {
            Dictionary<int, Film> szukaneFilmy = new Dictionary<int, Film>();
            foreach (KeyValuePair<int,Film> fl  in _dataRepo.dataContext.filmy)
            {
                if (fl.Value._rezyser == rezyserFilmow)
                {
                    szukaneFilmy.Add(fl.Key, fl.Value);
                }
            }
            if (szukaneFilmy.Count != 0) return szukaneFilmy;
            else return null;
        }


        public List<Klient> filtrowanieKlientow(string nazwisko)
        {
            List<Klient> szukaniKlienci = new List<Klient>();
            foreach (Klient klient in _dataRepo.dataContext.klienci)
            {
                if (klient._nazwisko == nazwisko) szukaniKlienci.Add(klient);
            }
            if (szukaniKlienci.Count != 0) return szukaniKlienci;
            else return null;
        }


        public ObservableCollection<Wypozyczenie> filtrowanieWypozyczen(string terminZwrotu)
        {
            ObservableCollection<Wypozyczenie> szukaneWypozyczenia = new ObservableCollection<Wypozyczenie>();
            foreach (Wypozyczenie wypozyczenie in _dataRepo.dataContext.wypozyczenia)
            {
                if (wypozyczenie._terminZwrotu == terminZwrotu) szukaneWypozyczenia.Add(wypozyczenie);
            }
            if (szukaneWypozyczenia.Count != 0) return szukaneWypozyczenia;
            else return null;
        }


        public Dictionary<int, OpisStanu> filtrowanieOpisowStanow(string dataZakupu)
        {
            Dictionary<int, OpisStanu> szukaneOpisystanow = new Dictionary<int, OpisStanu>();
            foreach (KeyValuePair<int, OpisStanu> opisStanu in _dataRepo.dataContext.opisyStanow)
            {
                if (opisStanu.Value._dataZakupu == dataZakupu)
                {
                    szukaneOpisystanow.Add(opisStanu.Key, opisStanu.Value);
                }
            }
            if (szukaneOpisystanow.Count != 0) return szukaneOpisystanow;
            else return null;
        }


        public void testWydajnosci()
        {
            Stopwatch stopWatch = new Stopwatch();
            // check the time of the static mode
            stopWatch.Start();

            // create FillDataRepositoryStatic fillData object (inherits from DataInterface)
            WypelnianieStalymi fillData = new WypelnianieStalymi();

            // create a repository using Dependency Injection pattern (pass FillDataRepositoryStatic object to DataRepository constructor)
            DataRepository repository = new DataRepository(fillData);

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
            Console.WriteLine("Czas wypelniania stalymi wynosi : " + staticTime.ToString());
            Console.WriteLine("Czas wypelniania z pliku wynosi : " + fileTime.ToString());
            
        }
     

    }
}
