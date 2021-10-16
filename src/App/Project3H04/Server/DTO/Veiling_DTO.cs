using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.DTO
{
    public class Veiling_DTO
    {
        [Required]
        public DateTime StartDatum { get; set; }
        [Required]
        public DateTime EindDatum { get; set; }
        [Required]
        public double MinPrijs { get; set; }
        [Required]
        public ICollection<Bod_DTO> BodenOpVeiling { get; set; }
        [Required]
        public Gebruiker_DTO gewonnenGeb { get; set; }
        [Required]
        public string KunstwerkNaam { get; set; }
    }
}
