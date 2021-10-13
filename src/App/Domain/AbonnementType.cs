using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AbonnementType
    {
        public string Naam { get; private set; }
        public int Verlooptijd { get; private set; }
        public double Prijs { get; private set; }

        public AbonnementType()
        {

        }
    }
}
    


