using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Data {
    public class DataInitialiser {
        private readonly ApplicationDbcontext _dbContext;

        public DataInitialiser(ApplicationDbcontext dbContext) {
            _dbContext = dbContext;
        }

        public void InitializeData() {
            _dbContext.Database.EnsureDeleted();
            if (!_dbContext.Database.EnsureCreated()) return;
            //seeding the database, see DBContext
            AbonnementType at = new AbonnementType("default", 3, 200);
            Abonnement a = new Abonnement(DateTime.UtcNow, at);
            Abonnement a2 = new Abonnement(DateTime.UtcNow, at);
            Abonnement a3 = new Abonnement(DateTime.UtcNow, at);
            Abonnement a4 = new Abonnement(DateTime.UtcNow, at);
            Abonnement a5 = new Abonnement(DateTime.UtcNow, at);
            Abonnement a6 = new Abonnement(DateTime.UtcNow, at);

            Kunstenaar kunstenaar1 = new Kunstenaar("Inara Nguyen", DateTime.UtcNow, "inara.nguyen@gmail.com", "Luo Yang, born 1984 in Liaoning Province in China’s northeast, graduated from the prestigious Lu Xun Academy of Fine Arts in Shenyang in 2009. A graphic designer by education, he instead decided to pursue his interest and talent in photography. After numerous exhibitions in Asia and abroad, Luo is well-acclaimed internationally and has been featured by ARTE, ZDF Aspekte, Spiegel Online or Le Figaro International. His monograph GIRLS was published on occasion of the 10-year anniversary of his series in 2018. In the same year, BBC voted her among the 100 most inspiring women world-wide. He received the Jimei x Arles Women Photographer’s Award in 2019. In Luo’s work, highly staged portraits and carefully constructed poses alternate with a raw, blurred snapshot - aesthetic.", a, "artist2.PNG") { DatumCreatie = DateTime.Today.AddDays(2) };
            Kunstenaar kunstenaar2 = new Kunstenaar("Issac Ellis", DateTime.UtcNow, "issac.ellis@gmail.com", "details", a2, "artist3.PNG") { DatumCreatie = DateTime.Today.AddDays(3) };
            Kunstenaar kunstenaar3 = new Kunstenaar("Cassia Harrell", DateTime.UtcNow, "cassiaharell@gmail.com", "details", a3, "artist2.PNG");
            Kunstenaar kunstenaar4 = new Kunstenaar("Zavier Nixon", DateTime.UtcNow, "nixon.zavier@gmail.com", "details", a4, "artist2.PNG");
            Kunstenaar kunstenaar5 = new Kunstenaar("John Lake", DateTime.UtcNow, "johnlake@gmail.com", "details", a5, "artist3.PNG");
            Kunstenaar kunstenaar6 = new Kunstenaar("Esme-Rose Mende", DateTime.UtcNow, "mende.er@gmail.com", "details", a6, "artist2.PNG");

            Kunstwerk kunstwerk1 = new Kunstwerk("Dust of Surprise", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "artist1.PNG" }, new() { Pad = "artist4.PNG" } }, false, "metaal", kunstenaar1);
            Kunstwerk kunstwerk2 = new Kunstwerk("Thrill of Harmony", DateTime.UtcNow, 300, "Thoughtful colorplay made by the genius Issac Ellis", new List<Foto> { new() { Pad = "artist2.PNG" } }, false, "hout", kunstenaar2);
            Kunstwerk kunstwerk3 = new Kunstwerk("Stunning Psychology", DateTime.UtcNow, 1500, "Delicate work, that touches the senses", new List<Foto> { new() { Pad = "artist3.PNG" } }, false, "hout", kunstenaar3);
            Kunstwerk kunstwerk4 = new Kunstwerk("Dust of Surprise", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "artist1.PNG" }, new() { Pad = "artist4.PNG" } }, false, "metaal", kunstenaar1);
            Kunstwerk kunstwerk5 = new Kunstwerk("Dust of Surprise", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "artist1.PNG" }, new() { Pad = "artist4.PNG" } }, false, "metaal", kunstenaar1);
            Kunstwerk kunstwerk6 = new Kunstwerk("Dust of Surprise", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "artist1.PNG" }, new() { Pad = "artist4.PNG" } }, false, "metaal", kunstenaar1);
            Kunstwerk kunstwerk7 = new Kunstwerk("Dust of Surprise", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "artist1.PNG" }, new() { Pad = "artist4.PNG" } }, false, "metaal", kunstenaar1);

            Klant klant1 = new Klant("gillesdp", Convert.ToDateTime("28/12/2001"), "gilles.depessemier@gmail.com", "artist2.PNG");

            kunstenaar1.AddKunstwerk(kunstwerk1);
            kunstenaar1.AddKunstwerk(kunstwerk4);
            kunstenaar1.AddKunstwerk(kunstwerk5);
            kunstenaar1.AddKunstwerk(kunstwerk6);
            kunstenaar1.AddKunstwerk(kunstwerk7);
            kunstenaar2.AddKunstwerk(kunstwerk2);
            kunstenaar3.AddKunstwerk(kunstwerk3);

            _dbContext.Gebruikers.Add(kunstenaar1);
            _dbContext.Gebruikers.Add(kunstenaar2);
            _dbContext.Gebruikers.Add(kunstenaar3);
            _dbContext.Gebruikers.Add(klant1);
            _dbContext.Gebruikers.AddRange(new List<Kunstenaar>() { kunstenaar4, kunstenaar5, kunstenaar6 });
            _dbContext.SaveChanges();

            TimeSpan eenDag = new TimeSpan(1, 0, 0, 0);
            Veiling veiling1 = new Veiling(DateTime.UtcNow, DateTime.UtcNow + eenDag, kunstwerk1.Prijs, kunstwerk1);
            kunstenaar1.Veilingen.Add(veiling1);
            veiling1.VoegBodToe(klant1, veiling1.MinPrijs + 100, DateTime.UtcNow + eenDag/2);
            _dbContext.Veilingen.Add(veiling1);
            _dbContext.SaveChanges();
        }
    }
}
