﻿using Project3H04.Shared.Kunstenaars;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project3H04.Shared.Kunstwerken
{
    public static class Kunstwerk_DTO
    {
        public class Index
        {
            public int Id { get; set; }
            public string Naam { get; set; }
            public decimal Prijs { get; set; }
            public Kunstenaar_DTO Kunstenaar { get; set; }
            public List<Foto_DTO> Fotos { get; set; }

        }
        public class Detail : Index
        {
            public string Materiaal { get; set; }
            public string Beschrijving { get; set; }

        }
        public class Edit
        {
            public Edit()
            {
              
            }
            public string Naam { get; set; }
            public decimal Prijs { get; set; }
            public List<Foto_DTO> Fotos { get; set; }
            public string Materiaal { get; set; }
            public string Beschrijving { get; set; }
            public bool TeKoop { get; set; }
            public bool IsVeilbaar { get; set; }
        }
        

    }
}
