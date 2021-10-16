using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.DTO
{
    public class AbonnementType_DTO
    {
        [Required]
        public string Naam { get; set; }
        [Required]
        public int Verlooptijd { get; set; }
        [Required]
        public double Prijs { get; set; }
    }
}
