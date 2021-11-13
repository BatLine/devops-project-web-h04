using Domain;
using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models.Payment.Response;
using Project3H04.Server.Data;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbcontext DbContext;

        public OrderService(ApplicationDbcontext dbContext)
        {
            DbContext = dbContext;
        }

        //public Bestelling Bestelling { get; private set; } = new Bestelling();
        public IList<Kunstwerk_DTO.Detail> CartKunstwerken { get; set; } = new List<Kunstwerk_DTO.Detail>();

        public IList<Kunstwerk_DTO.Detail> GetCartKunstwerken()
        {
            return CartKunstwerken.ToList();
        }
        public void AddKunstwerk(Kunstwerk_DTO.Detail kunstwerk)
        {
            CartKunstwerken.Add(kunstwerk);
        }

        public void RemoveKunstwerk(Kunstwerk_DTO.Detail kunstwerk)
        {
            CartKunstwerken.Remove(kunstwerk);
        }

        public async Task PostOrderAsync(Bestelling_DTO.Create bestelling)
        {
            Bestelling b = new Bestelling(DateTime.UtcNow, bestelling.Straat, bestelling.Postcode, bestelling.Gemeente,bestelling.PaymentId,bestelling.TotalePrijs);
            Klant k = DbContext.Gebruikers.OfType<Klant>().FirstOrDefault(k => k.GebruikerId == 1);
            k.Bestellingen.Add(b);
           await DbContext.Bestellingen.AddAsync(b);
           await DbContext.SaveChangesAsync();
        }

        public async Task RemoveBestelling(string id)
        {
            Bestelling b = DbContext.Bestellingen.FirstOrDefault(b => b.PaymentId == id);
            DbContext.Bestellingen.Remove(b);
            await DbContext.SaveChangesAsync();
        }
    }
}
