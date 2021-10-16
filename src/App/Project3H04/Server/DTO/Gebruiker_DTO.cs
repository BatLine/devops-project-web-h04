using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.DTO
{
    public class Gebruiker_DTO
    {
        [Required]
        public string Gebruikersnaam { get; set; }
        [Required]
        public DateTime GeboorteDatum { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
