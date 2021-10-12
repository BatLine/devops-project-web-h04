using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Veiling
    {
        public Kunstwerk Kunstwerk { get; }
        public DateTime StartDatum { get; }
        public DateTime EindDatum { get; }
        public double MinPrijs { get; }
        public ICollection<Bod> Boden { get; }

    }
}
