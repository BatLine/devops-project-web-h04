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
        public int GebruikerId { get; private set; }
        public DateTime DatumCreatie { get;  set; }

        public Gebruiker(string gebruikersnaam, DateTime geboortedatum, string email)
        {
            //Guard.Against.NullOrEmpty(gebruikersnaam, nameof(gebruikersnaam));
            Gebruikersnaam = gebruikersnaam;
            Geboortedatum = geboortedatum;
            Email = email;
            DatumCreatie = DateTime.UtcNow;
        }
        public Gebruiker()
        {

        }

      /* public void EditGebruiker(Gebruiker gebruiker)
        {
            this.Naam = gebruiker.Naam;
            this.Geboortedatum = gebruiker.
            
        } */

    }
}
