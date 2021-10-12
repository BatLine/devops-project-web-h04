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
        public ICollection<Kunstwerk> Kunstwerken { get; set; }
        public Abonnement HuidigAbonnement { get; private set; }


        public Gebruiker(string gebruikersnaam, DateTime geboortedatum, string email, GebruikerType type)
        {
            //Guard.Against.NullOrEmpty(gebruikersnaam, nameof(gebruikersnaam));
            Gebruikersnaam = gebruikersnaam;
            Geboortedatum = geboortedatum;
            Email = email;
            Type = type;
            Kunstwerken = new List<Kunstwerk>();
        }



      /* public void EditGebruiker(Gebruiker gebruiker)
        {
            this.Naam = gebruiker.Naam;
            this.Geboortedatum = gebruiker.
            
        } */

    }
}
