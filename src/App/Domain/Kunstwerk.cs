using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Kunstwerk
    {
        public string Naam { get; private set; }
        public DateTime Einddatum { get; private set; }
        public double Prijs { get; private set; }
        public string Beschrijving { get; private set; }
        public ICollection<string> Fotos { get; private set; }
        public bool TeKoop { get; set; }
        public bool IsVeilbaar { get; set; }

        public Kunstwerk(string naam, DateTime einddatum, double prijs, string beschrijving, ICollection<string> fotos, bool isVeilbaar)
        {
            Naam = naam;
            Einddatum = einddatum;
            Prijs = prijs;
            Beschrijving = beschrijving;
            Fotos = fotos;
            TeKoop = true;
            IsVeilbaar = isVeilbaar;
        }



    }
}
