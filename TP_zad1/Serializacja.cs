using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_zad1
{
    class Serializacja
    {
        public static void saveToXml(DataContext sdata)
        {
            DataSerializable dataToSer = new DataSerializable();
            dataToSer.copyFromDataContext(sdata);
            TextWriter tw = new StreamWriter("dataCtxt.xml");

            XmlSerializer sr = new XmlSerializer(typeof(DataSerializable));
            sr.Serialize(tw, dataToSer);
            tw.Close();
        }

        public static DataContext readFromXml()
        {
            DataContext deserialized=new DataContext();
            TextReader tr = new StreamReader("dataCtxt.xml");
            XmlSerializer sr = new XmlSerializer(typeof(DataSerializable));
            DataSerializable projectInfo = (DataSerializable)sr.Deserialize(tr);
            tr.Close();
            
            foreach (Film film in projectInfo.filmy)
            {
                deserialized.filmy.Add(projectInfo.filmy.IndexOf(film) + 1, film);
            }

            foreach (Klient klient in projectInfo.klienci)
            {
                deserialized.klienci.Add(klient);
            }

            foreach (Wypozyczenie wyp in projectInfo.wypozyczenia)
            {
                deserialized.wypozyczenia.Add(wyp);
            }

            foreach (OpisStanu opStanu in projectInfo.opisyStanow)
            {
                deserialized.opisyStanow.Add(projectInfo.opisyStanow.IndexOf(opStanu) + 1, opStanu);
            }

            return deserialized;
        }

        public static void saveSingleObjectToXml(Film film)
        {
            TextWriter tw = new StreamWriter("Film.xml");
      
            XmlSerializer sr = new XmlSerializer(typeof(Film));
            sr.Serialize(tw, film);
            tw.Close();
        }
        public static void saveSingleObjectToXml(Klient klient)
        {
            TextWriter tw = new StreamWriter("Klient.xml");

            XmlSerializer sr = new XmlSerializer(typeof(Klient));
            sr.Serialize(tw, klient);
            tw.Close();
        }
        public static void saveSingleObjectToXml(Wypozyczenie wypozyczenie)
        {
            TextWriter tw = new StreamWriter("Wypozyczenie.xml");

            XmlSerializer sr = new XmlSerializer(typeof(Wypozyczenie));
            sr.Serialize(tw, wypozyczenie);
            tw.Close();
        }
        public static void saveSingleObjectToXml(OpisStanu opisStanu)
        {
            TextWriter tw = new StreamWriter("OpisStanu.xml");

            XmlSerializer sr = new XmlSerializer(typeof(OpisStanu));
            sr.Serialize(tw, opisStanu);
            tw.Close();
        }
    }
}
