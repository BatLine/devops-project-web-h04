using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Shared.DTO
{
    public class Bod_DTO
    {
        public string GebruikersNaam { get; set; }
        public Veiling_DTO Veiling { get; set; }
        public double BodPrijs { get; set; }
    }
}
