using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bod
    {
        public string GebruikersNaam { get; set; }
        public Veiling Veiling { get; set; }
        public double BodPrijs { get; set; }

        public Bod(string gebruikersnaam, Veiling veiling, double bodPrijs)
        {
            GebruikersNaam = gebruikersnaam;
            Veiling = veiling;
            BodPrijs = bodPrijs;
        }
    }
}
