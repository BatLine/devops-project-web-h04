using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
       // private IDbContextTransaction Transaction;

        public OrderService(ApplicationDbcontext dbContext)
        {
            DbContext = dbContext;
            //Transaction = DbContext.Database.BeginTransaction();
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

        
        public async Task PostOrderAsync(Bestelling_DTO.Create bestelling) //besteling persisteren in db (dit gebeurt al voordat de betaling wordt uitgevoerd)
        {
            //Transaction = await DbContext.Database.BeginTransactionAsync();
            //  DbContext.Database.UseTransaction(Transaction.GetDbTransaction());

                IEnumerable<int> kunstwerkids = bestelling.WinkelmandKunstwerken.Select(k => k.Id);
                List<Kunstwerk> kunstwerken = DbContext.Kunstwerken.Where(k => kunstwerkids.Contains(k.Id)).ToList();
                foreach (var item in kunstwerken)
                {
                    item.TeKoop = false;             //alle kunstwerken in de bestelling krijgen te koop = false
                }
            Address adres = new Address(bestelling.Land, bestelling.Gemeente, bestelling.Postcode, bestelling.Straat);
                Bestelling b = new Bestelling(DateTime.UtcNow, adres/* bestelling.Straat, bestelling.Postcode, bestelling.Gemeente,*/, bestelling.PaymentId, bestelling.TotalePrijs, kunstwerken);
                Klant k = DbContext.Gebruikers.OfType<Klant>().FirstOrDefault(k => k.GebruikerId == 1);
                k.Bestellingen.Add(b);

                DbContext.Kunstwerken.UpdateRange(kunstwerken);
                await DbContext.Bestellingen.AddAsync(b);
                await DbContext.SaveChangesAsync();
            
        }

        
        public async Task RemoveBestelling(string id) //als een bestelling geanulleerd wordt, halen we deze uit de db
        {
            // DbContext.Database.UseTransaction(Transaction.GetDbTransaction());
/*            if (Transaction != null)
                await Transaction.RollbackAsync();*/
           

               Bestelling b = DbContext.Bestellingen.Include(k => k.WinkelmandKunstwerken).FirstOrDefault(b => b.PaymentId == id);
            if (b == null) return;
            foreach(var item in b.WinkelmandKunstwerken)
            {
                item.TeKoop = true;                  //bestelling wordt geannuleerd, kunstwerk kan weer gekocht worden
            }
            DbContext.UpdateRange(b.WinkelmandKunstwerken);
            DbContext.Bestellingen.Remove(b);
            await DbContext.SaveChangesAsync();
        }

/*        public async Task CreateBestelling()
        {
            //  DbContext.Database.UseTransaction(Transaction.GetDbTransaction());
            if(Transaction != null)
            await Transaction.CommitAsync();
        }*/
    }
}
