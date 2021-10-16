using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.DTO
{
    public class Klant_DTO : Gebruiker_DTO
    {
        [Required]
        public ICollection<Bod_DTO> Boden { get; set; }
        [Required]
        public ICollection<Bestelling_DTO> Bestellingen { get; set; }
    }
}
