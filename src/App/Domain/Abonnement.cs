using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Abonnement
    {
        public DateTime StartDatum { get; private set; }
        public DateTime EindDatum { get; private set; }
        public int Id { get; private set; }
        public AbonnementType AbonnementType { get; set; }

        public Abonnement(DateTime startDatum, DateTime eindDatum,AbonnementType abonnementType)
        {
            StartDatum = startDatum;
            EindDatum = eindDatum;
            this.AbonnementType = abonnementType;
        }

    }
}
