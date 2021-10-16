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
        public string GebruikersNaam { get; private set; }
        public Veiling Veiling { get; set; }
        public double BodPrijs { get; set; }

        public Bod(string gebruikersnaam, Veiling veiling, double bodPrijs)
        {
            GebruikersNaam = gebruikersnaam;
            Veiling = veiling;
            BodPrijs = bodPrijs;
        }

        public Bod()
        {

        }
    }
}

