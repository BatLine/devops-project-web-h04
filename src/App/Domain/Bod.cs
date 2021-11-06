using Ardalis.GuardClauses;
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
            Klant = Guard.Against.Null(klant, nameof(klant));
            Veiling = Guard.Against.Null(veiling, nameof(veiling));
            BodPrijs = Guard.Against.Null(bodPrijs, nameof(bodPrijs));
        }

        public Bod()
        {

        }
    }
}

