using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.DTO
{
    public class Bestelling_DTO
    {
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public string Straat { get; set; }
        [Required]
        public int Postcode { get; set; }
        [Required]
        public string Gemeente { get; set; }
        [Required]
        public DateTime LeverDatum { get; set; }
        [Required]
        public double TotalePrijs { get; set; }
        [Required]
        public ICollection<Kunstwerk_DTO> WinkelmandKunstwerken { get; set; }
    }
}
