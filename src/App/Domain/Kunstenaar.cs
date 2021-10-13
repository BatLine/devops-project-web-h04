using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Kunstenaar:Gebruiker
    {

        public string Details { get; set; }
        public bool StatusActiefKunstenaar { get; set; }
        public ICollection<Kunstwerk> Kunstwerken { get; set; }
        public ICollection<Veiling> Veilingen { get; set; }
        public Abonnement Abonnenment { get; set; }
        public Kunstenaar(string gebruikersnaam, DateTime geboortedatum, string email, string details, Abonnement abonnement) : base(gebruikersnaam, geboortedatum, email)
        {
            this.Details = details;
            this.StatusActiefKunstenaar = false;
            this.Abonnenment = abonnement;
            Kunstwerken = new List<Kunstwerk>();
            Veilingen = new List<Veiling>();
        }
    }
}
