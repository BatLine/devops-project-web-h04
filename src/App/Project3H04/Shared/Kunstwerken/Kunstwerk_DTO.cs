﻿using FluentValidation;
using Project3H04.Shared.Kunstenaars;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Project3H04.Shared.Kunstwerken
{
    public static class Kunstwerk_DTO
    {
        public class Index
        {
            public int Id { get; set; }
            public string Naam { get; set; }
            public decimal Prijs { get; set; }
            public string Materiaal { get; set; }
            public Kunstenaar_DTO Kunstenaar { get; set; }
            public Foto_DTO HoofdFoto { get; set; }

        }
        public class Detail : Index
        {
            public List<Foto_DTO> Fotos { get; set; }
            public string Beschrijving { get; set; }
            public bool TeKoop { get; set; }

            public Detail()
            {
                HoofdFoto = Fotos?.FirstOrDefault();
            }
        }
        public class Filter
        {
            public string Naam { get; set; }
            public decimal MinimumPrijs { get; set; }
            public decimal MaximumPrijs { get; set; }
            public List<string> Materiaal { get; set; }
            public string Kunstenaar { get; set; }
        }

        public class Create
        {
            public Create()
            {
                Fotos = new();
                NieuweFotos = new();
            }
            public string Naam { get; set; }
            public decimal Prijs { get; set; }
            public List<Foto_DTO> Fotos { get; set; }
            public List<Foto_DTO> NieuweFotos { get; set; }

            public string Materiaal { get; set; }
            public string Beschrijving { get; set; }
            public bool TeKoop { get; set; }
            public bool IsVeilbaar { get; set; }
        }

        public class Edit : Create
        {
            public Edit() : base()
            {

            }
            public Edit(Detail kunstwerk)
            {
                Id = kunstwerk.Id;
                Naam = kunstwerk.Naam;
                Prijs = kunstwerk.Prijs;
                Fotos = kunstwerk.Fotos;
                Materiaal = kunstwerk.Materiaal;
                Beschrijving = kunstwerk.Beschrijving;
                KunstenaarId = kunstwerk.Kunstenaar.GebruikerId;
                TeKoop = kunstwerk.TeKoop;
            }

            public int Id { get; set; }
            public int KunstenaarId { get; set; }

        }
        //bij aanmaken van kunstwerk dan validatie met validator
        //=>bij andere DTO's wnr nodig/moet aanmaken/create heeft, dan ook validatie doen !!!
        public class Validator : AbstractValidator<Create>
        {
            public Validator()
            {
                RuleFor(artwork => artwork.Naam).NotEmpty().OverridePropertyName("Name");
                RuleFor(artwork => artwork.Prijs).GreaterThanOrEqualTo(0).OverridePropertyName("Price");
                RuleFor(artwork => artwork.Materiaal).NotEmpty().OverridePropertyName("Material");
                RuleFor(artwork => artwork.Fotos).NotEmpty().OverridePropertyName("Images");
            }
        }


    }
}
