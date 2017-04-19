﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_zad1
{
    [XmlRoot("Klient")]
    public class Klient
    {
        //konstruktor
        private static int numerObiektu = 0;

        public Klient()
        {
        }

        public Klient(string imie, string nazwisko, string numerTel, string email)
        {
            numerObiektu = ++numerObiektu;
            _imie = imie;
            _nazwisko = nazwisko;
            _numerTel = numerTel;
            _email = email;
        }

        [XmlElement("Imie")]
        public string _imie { get; set; }
        [XmlElement("Nazwisko")]
        public string _nazwisko { get; set; }
        [XmlElement("Telefon")]
        public string _numerTel { get; set; }
        [XmlElement("Mail")]
        public string _email { get; set; }



        public string wyswietlKlienta()
        {
           
            return ("Imie: " + _imie + ", nazwisko: " + _nazwisko + ", numer telefonu: " + _numerTel + ", email: " + _email + "\n");
        }

        //public string imie
        //{
        //    get { return _imie; }
        //    set { _imie = value; }
        //}

        //public string nazwisko
        //{
        //    get { return _nazwisko; }
        //    set { _nazwisko = value; }
        //}

        //public string numerTel
        //{
        //    get { return _numerTel; }
        //    set { _numerTel = value; }
        //}


        //public string email
        //{
        //    get { return _email; }
        //    set { _email = value; }
        //}


    }
}
