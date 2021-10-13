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
        public double TotalePrijs { get; set; }
        public ICollection<Kunstwerk> WinkelmandKunstwerken { get; set; } // deze niet in DB, winkelmand lokaal bijhouden

        
        public Bestelling()
        {
            WinkelmandKunstwerken = new List<Kunstwerk>();
        }
    }
}
