using Domain;
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

        public Task PostOrderAsync(Bestelling_DTO.Create bestelling)
        {

            throw new NotImplementedException();
            //Bestelling b = new Bestelling(DateTime.UtcNow, bestelling.Straat, bestelling.Postcode);
        }
    }
}
