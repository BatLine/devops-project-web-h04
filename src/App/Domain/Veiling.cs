using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Veiling
    {
        public int Id { get; private set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public double MinPrijs { get; set; }
        public ICollection<Bod> BodenOpVeiling { get; set; }
        //public Kunstwerk Kunstwerk { get; set; }
        public Gebruiker gewonnenGeb { get; set; }
        public string KunstwerkNaam{ get; private set; }
        public Veiling(DateTime startDatum, DateTime eindDatum, double minPrijs, string kunstwerknaam)
        {
            StartDatum = Guard.Against.Null(startDatum, nameof(startDatum));
            EindDatum = Guard.Against.Null(eindDatum, nameof(eindDatum));
            MinPrijs = Guard.Against.Null(minPrijs, nameof(MinPrijs));
            BodenOpVeiling = new List<Bod>();
            //Kunstwerk = kunstwerk;
            KunstwerkNaam = Guard.Against.NullOrEmpty(kunstwerknaam, nameof(kunstwerknaam));
            gewonnenGeb = new Gebruiker();
        }
        public Veiling()
        {

        }
    }
}
