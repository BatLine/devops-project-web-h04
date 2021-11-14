using FluentValidation;
using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Shared.DTO
{
    public static class Bestelling_DTO
    {
        public class Index {  
        public DateTime Datum { get; set; }
        public string Straat { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
        public DateTime LeverDatum { get; set; }
        public decimal TotalePrijs { get; set; }
        public ICollection<Kunstwerk_DTO.Detail> WinkelmandKunstwerken { get; set; }
        }
        public class Create
        {
           // public DateTime Datum { get; set; }
            public string Straat { get; set; }
            public string Postcode{ get; set; }
            public string Land { get; set; }
            public string Gemeente { get; set; }
            public decimal TotalePrijs { get; set; }
            public ICollection<Kunstwerk_DTO.Detail> WinkelmandKunstwerken { get; set; }
            public string PaymentId { get; set; }

            public class Validator : AbstractValidator<Create>
            {

                public Validator()
                {
                    RuleFor(b => b.Straat).NotEmpty();
                    RuleFor(b => b.Postcode).NotEmpty().Length(4).Custom((x, context) =>
                    {
                        if ((!(int.TryParse(x, out int value)) || value < 0))
                        {
                            context.AddFailure($"{x} is geen geldige postcode");
                        }
                    }); 
                    RuleFor(b => b.Gemeente).NotEmpty();
                    RuleFor(b => b.Land).NotEmpty();

                  //  RuleFor(b => b.TotalePrijs).GreaterThan(0);
                   // RuleFor(b => b.WinkelmandKunstwerken).NotEmpty();
                }
            }
        }
    }

}
