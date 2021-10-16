using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.DTO
{
    public class Kunstwerk_DTO
    {
        [Required]
        public string Naam { get; set; }
        [Required]
        public DateTime Einddatum { get; set; }
        [Required]
        public double Prijs { get; set; }
        [Required]
        public string Beschrijving { get; set; }
        [Required]
        public byte[] Fotos { get; set; }
        [Required]
        public bool TeKoop { get; set; }
        [Required]
        public bool IsVeilbaar { get; set; }
        [Required]
        public string Materiaal { get; set; }
        [Required]
        public string NaamKunstenaar { get; set; }
    }
}
