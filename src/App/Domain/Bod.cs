using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bod
    {
        public int Id { get; private set; }
        public Klant Klant{ get; private set; }
        public Veiling Veiling { get; set; }
        public double BodPrijs { get; set; }

        public Bod(Klant klant, Veiling veiling, double bodPrijs)
        {
            Klant = klant;
            Veiling = veiling;
            BodPrijs = bodPrijs;
        }

        public Bod()
        {

        }
    }
}

