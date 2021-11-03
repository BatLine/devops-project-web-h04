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
                Kunstenaar k = new Kunstenaar("Inara Nguyen", DateTime.Now, "inara.nguyen@gmail.com", "details", a, "artist2.PNG") { DatumCreatie = DateTime.Today.AddDays(2) };
                Kunstenaar b = new Kunstenaar("Issac Ellis", DateTime.Now, "issac.ellis@gmail.com", "details", a2, "artist3.PNG") { DatumCreatie = DateTime.Today.AddDays(3) };
                Kunstenaar c = new Kunstenaar("Cassia Harrell", DateTime.Now, "cassiaharell@gmail.com", "details", a3, "artist2.PNG");
                Kunstenaar d = new Kunstenaar("Zavier Nixon", DateTime.Now, "nixon.zavier@gmail.com", "details", a4, "artist2.PNG");
                Kunstenaar e = new Kunstenaar("John Lake", DateTime.Now, "johnlake@gmail.com", "details", a5, "artist3.PNG");
                Kunstenaar f = new Kunstenaar("Esme-Rose Mende", DateTime.Now, "mende.er@gmail.com", "details", a6, "artist2.PNG");

                Kunstwerk kunst = new Kunstwerk("Dust of Surprise", DateTime.Now, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "artist1.PNG" }, new() { Pad = "artist4.PNG" } }, false, "metaal", k);
                Kunstwerk kunst2 = new Kunstwerk("Thrill of Harmony", DateTime.Now, 300, "Thoughtful colorplay made by the genius Issac Ellis", new List<Foto> { new() { Pad = "artist2.PNG" } }, false, "hout", b);
                Kunstwerk kunst3 = new Kunstwerk("Stunning Psychology", DateTime.Now, 1500, "Delicate work, that touches the senses", new List<Foto> { new() { Pad = "artist3.PNG" } }, false, "hout", c);

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
