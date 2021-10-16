using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.DTO
{
    public class Bod_DTO
    {
        [Required]
        public string GebruikersNaam { get; set; }
        [Required]
        public Veiling_DTO Veiling { get; set; }
        [Required]
        public double BodPrijs { get; set; }
    }
}
