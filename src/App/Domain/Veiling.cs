using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Veiling
    {
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public double MinPrijs { get; set; }
         public ICollection<Bod> BodenOpVeiling { get; set; }
        public Kunstwerk Kunstwerk { get; set; }
        public Gebruiker gewonnenGeb { get; set; }
        public Veiling(DateTime startDatum, DateTime eindDatum, double minPrijs, Kunstwerk kunstwerk)
        {
            StartDatum = startDatum;
            EindDatum = eindDatum;
            MinPrijs = minPrijs;
            BodenOpVeiling = new List<Bod>();
            Kunstwerk = kunstwerk;
            gewonnenGeb = new Gebruiker();
        }

    }
}
