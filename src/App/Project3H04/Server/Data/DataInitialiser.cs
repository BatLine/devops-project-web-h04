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
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database, see DBContext
                AbonnementType at = new AbonnementType("default", 3, 200);
                Abonnement a = new Abonnement(DateTime.Now, at);
                Abonnement a2 = new Abonnement(DateTime.Now, at);
                Abonnement a3 = new Abonnement(DateTime.Now, at);
                Kunstenaar k = new Kunstenaar("kunstenaar", DateTime.Now, "naam@gmail.com", "details", a);
                Kunstenaar b = new Kunstenaar("kunstenaar2", DateTime.Now, "naame@gmail.com", "details", a2);
                Kunstenaar c = new Kunstenaar("babafafoey", DateTime.Now, "naamee@gmail.com", "details", a3);

                Kunstwerk kunst = new Kunstwerk("kunstwerk1", DateTime.Now, 200, "bla bla bla", new List<Foto> { new() { Pad = "artist1.PNG" } }, false, "metaal", "kunstenaar");
                Kunstwerk kunst2 = new Kunstwerk("kunstwerk2", DateTime.Now, 300, "bla bla bla", new List<Foto> { new() { Pad = "artist2.PNG" } }, false, "hout", "kunstenaar2");
                Kunstwerk kunst3 = new Kunstwerk("tha bababoey", DateTime.Now, 1500, "bla bla bla", new List<Foto> { new() { Pad = "artist3.PNG" } }, false, "hout", "babafafoey");
                k.AddKunstwerk(kunst);
                b.AddKunstwerk(kunst2);
                c.AddKunstwerk(kunst3);
                _dbContext.Gebruikers.Add(k);
                _dbContext.Gebruikers.Add(b);
                _dbContext.Gebruikers.Add(c);
                k.AddKunstwerk(kunst);
                _dbContext.SaveChanges();
            }
        }
    }
}
