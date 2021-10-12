using System;
using System.Collections.Generic;

namespace Domain
{
    public class Bestelling
    {
        public int Id { get; private set; }
        public DateTime Datum { get; set; }
        public string Straat { get; set; }
        public int Postcode { get; set; }
        public int Gemeente { get; set; }
        public DateTime LeverDatum { get; set; }
        public double TotalePrijs { get; set; }

        public ICollection<Kunstwerk> WinkelmandKunstwerken { get; set; }

        public Bestelling()
        {
            WinkelmandKunstwerken = new List<Kunstwerk>();
        }
    }
}