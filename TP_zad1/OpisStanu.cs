using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_zad1
{
    class OpisStanu
    {
       

        public OpisStanu(string opisFilmu, string dataZakupu)
        {
            
            _opisFilmu = opisFilmu;
            _dataZakupu = dataZakupu;
        }



        public string _opisFilmu { get; }
        public string _dataZakupu { get; }
      

        public string wyswietlOpisStanu()
        {
        

            return ("Opis filmu: " + _opisFilmu + ",  data zakupu: " + _dataZakupu + "\n");

        }
    }
}

