using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Data
{
    public class DataInitialiser
    {
        private readonly ApplicationDbcontext _dbContext;

        public DataInitialiser(ApplicationDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            //_dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database, see DBContext
                AbonnementType at = new AbonnementType("default",3,200);
                Abonnement a = new Abonnement(DateTime.Now, at);
                Kunstenaar k = new Kunstenaar("kunsternaar",DateTime.Now,"naam@gmail.com","details",a);
                Kunstwerk kunst = new Kunstwerk("kunstwerk1", DateTime.Now, 200, "bla bla bla", new List<Foto> { new() { Pad = "artist1.PNG" } }, false, "hout", "kunstenaar1");
                k.AddKunstwerk(kunst);
                _dbContext.Gebruikers.Add(k);
                _dbContext.SaveChanges();
            }
        }
    }
}
