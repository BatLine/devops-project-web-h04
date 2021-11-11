using Ardalis.GuardClauses;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain {
    public class Kunstwerk {
        public int Id { get; set; }
        public string Naam { get; private set; }
        public DateTime Einddatum { get; private set; }
        public decimal Prijs { get; private set; }
        public string Beschrijving { get; private set; }
        public List<Foto> Fotos { get; private set; }
        public bool TeKoop { get; set; }
        public bool IsVeilbaar { get; set; }
        public string Materiaal { get; private set; }
        public Kunstenaar Kunstenaar { get; private set; }

        public Kunstwerk(string naam, DateTime einddatum, decimal prijs, string beschrijving, List<Foto> fotos, bool isVeilbaar, string materiaal, Kunstenaar kunstenaar) : this(){
            Naam = Guard.Against.NullOrWhiteSpace(naam, nameof(naam));
            Einddatum = Guard.Against.Null(einddatum, nameof(einddatum));
            Prijs = Guard.Against.Null(prijs, nameof(prijs));
            Beschrijving = Guard.Against.NullOrWhiteSpace(beschrijving, nameof(beschrijving));
            Materiaal = Guard.Against.NullOrEmpty(materiaal,nameof(materiaal));
            Kunstenaar = Guard.Against.Null(kunstenaar, nameof(kunstenaar));

            TeKoop = true;
            Fotos = fotos;
            IsVeilbaar = isVeilbaar;
        }

        public Kunstwerk() {

        }

    }
}
