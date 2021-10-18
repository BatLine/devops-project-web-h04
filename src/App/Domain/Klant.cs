﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Klant : Gebruiker
    {

        public ICollection<Bod> Boden { get; set; }
        public ICollection<Bestelling> Bestellingen { get; set; }
        public Klant(string gebruikersnaam, DateTime geboortedatum, string email):base(gebruikersnaam, geboortedatum, email)
        {
            Boden = new List<Bod>();
            Bestellingen = new List<Bestelling>();
        }

    }
}