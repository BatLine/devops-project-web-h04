using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public class Klant : Gebruiker {
        private string gebruikersnaam;
        private DateTime geboorteDatum;
        private string email;

        //public ICollection<Bod> Boden { get; set; } bod kent gebruiker niet omgekeerd
        public ICollection<Bestelling> Bestellingen { get; set; }
        public Klant(string gebruikersnaam, DateTime geboortedatum, string email, string fotoPad, string details) : base(gebruikersnaam, geboortedatum, email, fotoPad, details)
        {
            //Boden = new List<Bod>();
            Bestellingen = new List<Bestelling>();
        }

        public Klant(string gebruikersnaam, DateTime geboorteDatum, string email, string fotopad)
        {
            this.gebruikersnaam = gebruikersnaam;
            this.geboorteDatum = geboorteDatum;
            this.email = email;
            FotoPad = fotopad;
        }
    }
}
