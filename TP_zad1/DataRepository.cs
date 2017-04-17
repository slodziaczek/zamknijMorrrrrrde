using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    public class DataRepository
    {
        public DataRepository()
        {
            dataContext = new DataContext();
        }

        public DataContext dataContext { get; }



        public DataRepository(Interfejs interfejs)
        {
            dataContext = new DataContext();

            //ws.WypelnijListeKlientow(this);
            //ws.WypelnijSlownikFilmow(this);
            //ws.WypelnijKolekcjeWypozyczen(this);
            //ws.WypelnijListeOpisowStanow(this);

            interfejs.WypelnijListeKlientow(this);
            interfejs.WypelnijSlownikFilmow(this);
            interfejs.WypelnijKolekcjeWypozyczen(this);
            interfejs.WypelnijListeOpisowStanow(this);

        }

        public bool stworzKlienta(Klient kl)
        {
            if (!dataContext.klienci.Contains(kl)) //as not to duplicate information
            {
                dataContext.klienci.Add(kl);
                return true;
            }
            return false;
        }

        public bool dodajFilm(Film fl)
        {
            if (!dataContext.filmy.ContainsValue(fl)) //as to avoid runtime error
            {
                dataContext.filmy.Add(dataContext.filmy.Count + 1, fl);
                return true;
            }
            return false;
        }

        public bool dodajWypozyczenie(Wypozyczenie wyp)
        {
            if (!dataContext.wypozyczenia.Contains(wyp))
            {
                dataContext.wypozyczenia.Add(wyp);
                return true;
            }
            return false;
        }

        public bool dodajStan(OpisStanu os)
        {
            if (!dataContext.opisyStanow.ContainsValue(os)) //as not to duplicate information
            {
                dataContext.opisyStanow.Add(dataContext.opisyStanow.Count + 1, os);
                return true;
            }
            return false;
        }


        public Klient getKlient(Klient k)
        {
            if (dataContext.klienci.Contains(k))
            {
                foreach (Klient klient in dataContext.klienci)
                {
                    if (klient == k) return k;
                }
            }
            return null;
        }

        public Film getFilm(int ID)
        {
            if (dataContext.filmy.ContainsKey(ID))
            {
                foreach (int id in dataContext.filmy.Keys)
                {
                    if (id.Equals(ID)) return dataContext.filmy[id];
                }
            }
            return null;
        }

        public Film getFilm(Film fl)
        {
            if (dataContext.filmy.ContainsValue(fl))
            {
                foreach (Film value in dataContext.filmy.Values)
                {
                    if (fl._tytul.Equals(value._tytul)) return value;
                }
            }
            return null;
        }

        public OpisStanu getOpisStanu(int ID)
        {
            if (dataContext.filmy.ContainsKey(ID))
            {
                foreach (int id in dataContext.opisyStanow.Keys)
                {
                    if (id.Equals(ID)) return dataContext.opisyStanow[id];
                }
            }
            return null;
        }


        public Wypozyczenie getWypozyczenie(Wypozyczenie wyp)
        {
            if (dataContext.wypozyczenia.Contains(wyp))
            {
                foreach (Wypozyczenie wypozyczenie in dataContext.wypozyczenia)
                {
                    if (wypozyczenie == wyp) return wyp;
                }
            }
            return null;
        }

        public List<Klient> getKlienci()
        {
            return dataContext.klienci;
        }

        public Dictionary<int, Film> getFilmy()
        {
            return dataContext.filmy;
        }

        public ObservableCollection<Wypozyczenie> getWypozyczenia()
        {
            return dataContext.wypozyczenia;
        }

        public Dictionary<int, OpisStanu> getOpisyStanow()
        {
            return dataContext.opisyStanow;
        }

        public bool usunKlienta(Klient kl)
        {
            foreach (Klient klient in dataContext.klienci)
            {
                if (klient == kl)
                {
                    dataContext.klienci.Remove(kl);
                    return true;
                }
            }
            return false;
        }


        public bool usunFilm(Film fl)
        {
            foreach (KeyValuePair<int, Film> film in dataContext.filmy)
            {
                if (film.Value._tytul == fl._tytul)
                {
                    dataContext.filmy.Remove(film.Key);
                   
                }
                
            }
            
            return false;
        }

        public bool usunOpisStanu(OpisStanu os)
        {
            foreach (KeyValuePair<int, OpisStanu> opisStanu in dataContext.opisyStanow)
            {
                if (opisStanu.Value._dataZakupu == os._dataZakupu)
                {
                    dataContext.opisyStanow.Remove(opisStanu.Key);
                }
            
        }
            return false;
        }

        public bool usunWypozecznie(Wypozyczenie wyp)
        {
            foreach (Wypozyczenie wypozyczenie in dataContext.wypozyczenia)
            {
                if (wypozyczenie == wyp) dataContext.wypozyczenia.Remove(wyp);
                return true;
            }
            return false;
        }

    }

    }
