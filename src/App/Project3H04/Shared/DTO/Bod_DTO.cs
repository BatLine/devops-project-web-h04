using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Shared.DTO
{
    public class Bod_DTO
    {
        public Klant_DTO Klant{ get; set; }
        public Veiling_DTO Veiling { get; set; }
        public double BodPrijs { get; set; }
    }
}
