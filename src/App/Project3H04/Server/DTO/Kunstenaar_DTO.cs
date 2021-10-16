using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.DTO
{
    public class Kunstenaar_DTO : Gebruiker_DTO
    {
        [Required]
        public string Details { get; set; }
        [Required]
        public bool StatusActiefKunstenaar { get; set; }
        [Required]
        public ICollection<Kunstwerk_DTO> Kunstwerken { get; set; }
        [Required]
        public ICollection<Veiling_DTO> Veilingen { get; set; }
        [Required]
        public Abonnement_DTO Abonnenment { get; set; }

    }
}
