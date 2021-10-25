using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Shared.DTO
{
    public class Bestelling_DTO
    {
        public DateTime Datum { get; set; }
        public string Straat { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
        public DateTime LeverDatum { get; set; }
        public double TotalePrijs { get; set; }
        public ICollection<Kunstwerk_DTO.Detail> WinkelmandKunstwerken { get; set; }
    }
}
