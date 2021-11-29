﻿using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Kunstenaar : Gebruiker
    {
        private string gebruikersnaam;
        private DateTime geboorteDatum;
        private string email;
        private Abonnement abonnement;

        //public string Details { get; set; }
        public bool StatusActiefKunstenaar { get; set; }
        public ICollection<Kunstwerk> Kunstwerken { get; set; }
        public ICollection<Veiling> Veilingen { get; set; }
        public Abonnement Abonnenment { get; set; }
        public int AbonnenmentId { get; private set; }
        public Kunstenaar(string gebruikersnaam, DateTime geboortedatum, string email, Abonnement abonnement, string fotoPad, string details) : base(gebruikersnaam, geboortedatum, email, fotoPad,details)
        {
           // this.Details = Guard.Against.NullOrWhiteSpace(details, nameof(details));
            this.StatusActiefKunstenaar = false;
            this.Abonnenment = Guard.Against.Null(abonnement, nameof(abonnement));
            AbonnenmentId = Abonnenment.Id;
            Kunstwerken = new List<Kunstwerk>();
            Veilingen = new List<Veiling>();
        }

        public void AddKunstwerk(Kunstwerk kunst)
        {
            Kunstwerken.Add(kunst);
        }

        public Kunstenaar()
        {
            Kunstwerken = new List<Kunstwerk>();
        }

        public Kunstenaar(string gebruikersnaam, DateTime geboorteDatum, string email, string details, Abonnement abonnement, string fotopad)
        {
            this.gebruikersnaam = gebruikersnaam;
            this.geboorteDatum = geboorteDatum;
            this.email = email;
            Details = details;
            this.abonnement = abonnement;
            FotoPad = fotopad;
        }
    }
}
