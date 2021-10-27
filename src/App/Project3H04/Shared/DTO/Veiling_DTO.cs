using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Shared.DTO
{
    public class Veiling_DTO
    {
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public double MinPrijs { get; set; }
        public ICollection<Bod_DTO> BodenOpVeiling { get; set; }
        public Gebruiker_DTO gewonnenGeb { get; set; }
        public Kunstwerk_DTO.Detail Kunstwerk { get; set; }
    }
}
