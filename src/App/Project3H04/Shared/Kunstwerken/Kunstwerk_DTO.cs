using System;
using System.Collections.Generic;

namespace Project3H04.Shared.Kunstwerken
{
    public static class Kunstwerk_DTO
    {
        public class Index
        {
            public int Id { get; set; }
            public string Naam { get; set; }

            public decimal Prijs { get; set; }
            public string NaamKunstenaar { get; set; }

            public List<Foto_DTO> Fotos { get; set; }

            public Index(int id, string naam, decimal prijs, List<Foto_DTO> fotos, string naamKunstenaar)
            {
                Id = id;
                Naam = naam;
                Prijs = prijs;
                Fotos = fotos;
                NaamKunstenaar = naamKunstenaar;
            }

        }
        public class Detail : Index
        {
            public string Materiaal { get; set; }

            public string Beschrijving { get; set; }

            public Detail(int id, string naam, decimal prijs,List<Foto_DTO> fotos, string materiaal, string naamKunstenaar, string beschrijving) : base(id,naam,prijs,fotos,naamKunstenaar )
            {
                Materiaal = materiaal;
                Beschrijving = beschrijving;
            }
        }
        

    }
}
