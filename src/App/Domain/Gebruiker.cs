using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Gebruiker
    {
        public string Gebruikersnaam { get; private set; }
        public DateTime Geboortedatum { get; private set; }
        public string Email { get; private set; }
        public GebruikerType Type { get; private set; }
        public string KunstenaarDetails { get; private set; }
        public int GebruikerId { get; private set; }
        public bool StatusActiefKunstenaar { get; set; }

        public ICollection<Kunstwerk> Kunstwerken { get; set; }
        public ICollection<Veiling> Veilingen { get; set; }
        public ICollection<Bod> Boden { get; set; }
        public Bestelling Bestelling { get; set; }
        public Abonnement Abonnenment { get;  set; }

        //klant
        public Gebruiker(string gebruikersnaam, DateTime geboortedatum, string email, GebruikerType type)
        {
            //Guard.Against.NullOrEmpty(gebruikersnaam, nameof(gebruikersnaam));0
            Gebruikersnaam = gebruikersnaam;
            Geboortedatum = geboortedatum;
            Email = email;
            Type = type;
            Kunstwerken = new List<Kunstwerk>();
            Veilingen = new List<Veiling>();
            Boden = new List<Bod>();
            Bestelling = new Bestelling();
        }
        //kunstenaar
        public Gebruiker(string gebruikersnaam, DateTime geboortedatum, string email, GebruikerType type, string kuntenaarDetails, Abonnement abonnement) :this(gebruikersnaam, geboortedatum, email, type)
        {
            this.KunstenaarDetails = kuntenaarDetails;
            this.StatusActiefKunstenaar = false;
            this.Abonnenment = abonnement;
        }


      /* public void EditGebruiker(Gebruiker gebruiker)
        {
            this.Naam = gebruiker.Naam;
            this.Geboortedatum = gebruiker.
            
        } */

    }
}
