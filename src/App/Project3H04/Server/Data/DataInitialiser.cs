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
                Abonnement a4 = new Abonnement(DateTime.Now, at);
                Abonnement a5 = new Abonnement(DateTime.Now, at);
                Abonnement a6 = new Abonnement(DateTime.Now, at);
                Kunstenaar k = new Kunstenaar("kunstenaar", DateTime.Now, "naam@gmail.com", "details", a, "artist2.PNG") { DatumCreatie = DateTime.Today.AddDays(2) };
                Kunstenaar b = new Kunstenaar("kunstenaar2", DateTime.Now, "naame@gmail.com", "details", a2, "artist3.PNG") { DatumCreatie = DateTime.Today.AddDays(3) };
                Kunstenaar c = new Kunstenaar("babafafoey", DateTime.Now, "naamee@gmail.com", "details", a3, "artist2.PNG");
                Kunstenaar d = new Kunstenaar("kunstenaar3", DateTime.Now, "naameee@gmail.com", "details", a4, "artist2.PNG");
                Kunstenaar e = new Kunstenaar("kunstenaar4", DateTime.Now, "naameeee@gmail.com", "details", a5, "artist3.PNG");
                Kunstenaar f = new Kunstenaar("kunstenaar5", DateTime.Now, "naameeeee@gmail.com", "details", a6, "artist2.PNG");

                Kunstwerk kunst = new Kunstwerk("kunstwerk1", DateTime.Now, 200, "bla bla bla", new List<Foto> { new() { Pad = "artist1.PNG" } }, false, "metaal", k);
                Kunstwerk kunst2 = new Kunstwerk("kunstwerk2", DateTime.Now, 300, "bla bla bla", new List<Foto> { new() { Pad = "artist2.PNG" } }, false, "hout", b);
                Kunstwerk kunst3 = new Kunstwerk("tha bababoey", DateTime.Now, 1500, "bla bla bla", new List<Foto> { new() { Pad = "artist3.PNG" } }, false, "hout", c);

                k.AddKunstwerk(kunst);
                //k.Kunstwerken.Add(kunst);
                b.AddKunstwerk(kunst2);
                c.AddKunstwerk(kunst3);
                _dbContext.Gebruikers.Add(k);
                _dbContext.Gebruikers.Add(b);
                _dbContext.Gebruikers.Add(c);
                _dbContext.Gebruikers.AddRange(new List<Kunstenaar>() { d, e, f });
                k.AddKunstwerk(kunst);
                _dbContext.SaveChanges();
            }
        }
    }
}
