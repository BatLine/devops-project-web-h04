using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class Bestelling
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Straat { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
        public DateTime LeverDatum { get; set; }
        public decimal TotalePrijs { get; set; }
        public ICollection<Kunstwerk> WinkelmandKunstwerken { get; set; } // deze niet in DB, winkelmand lokaal bijhouden

        public Bestelling()
        {
            WinkelmandKunstwerken = new List<Kunstwerk>();
        }

        public Bestelling(DateTime datum, string straat, int postcode, string gemeente, DateTime leverDatum)
        {
            //Id = id;
            Datum = Guard.Against.Null(datum, nameof(datum));
            Straat = Guard.Against.NullOrWhiteSpace(straat, nameof(straat));
            Postcode = Guard.Against.Null(postcode, nameof(postcode));
            Gemeente = Guard.Against.NullOrEmpty(gemeente, nameof(gemeente));
            LeverDatum = Guard.Against.Null(leverDatum, nameof(leverDatum));
            TotalePrijs = WinkelmandKunstwerken.Sum(x => x.Prijs);
        }
    }
}


