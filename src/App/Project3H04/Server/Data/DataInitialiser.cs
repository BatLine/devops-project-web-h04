﻿using Domain;
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
            Klant klant1 = new Klant("gillesdp", Convert.ToDateTime("28/12/2001"), "gilles.depessemier@gmail.com", "artist3.PNG");

            AbonnementType at = new AbonnementType("default", 3, 200);
            Abonnement abonnement1 = new Abonnement(DateTime.UtcNow, at);
            Abonnement abonnement2 = new Abonnement(DateTime.UtcNow, at);
            Abonnement abonnement3 = new Abonnement(DateTime.UtcNow, at);
            Abonnement abonnement4 = new Abonnement(DateTime.UtcNow, at);
            Abonnement abonnement5 = new Abonnement(DateTime.UtcNow, at);
            Abonnement abonnement6 = new Abonnement(DateTime.UtcNow, at);

            Kunstenaar kunstenaar1 = new Kunstenaar("Inara Nguyen", DateTime.UtcNow, "inara.nguyen@gmail.com", "Inara Nguyen, born 1984 in Liaoning Province in China’s northeast, graduated from the prestigious Lu Xun Academy of Fine Arts in Shenyang in 2009. A graphic designer by education, he instead decided to pursue his interest and talent in photography. After numerous exhibitions in Asia and abroad, Luo is well-acclaimed internationally and has been featured by ARTE, ZDF Aspekte, Spiegel Online or Le Figaro International. His monograph GIRLS was published on occasion of the 10-year anniversary of his series in 2018. In the same year, BBC voted her among the 100 most inspiring women world-wide. He received the Jimei x Arles Women Photographer’s Award in 2019. In Luo’s work, highly staged portraits and carefully constructed poses alternate with a raw, blurred snapshot - aesthetic.", abonnement1, "artist2.PNG") { DatumCreatie = DateTime.UtcNow.AddDays(2) };

            Kunstenaar kunstenaar2 = new Kunstenaar("Issac Ellis", DateTime.UtcNow, "issac.ellis@gmail.com", "Throughout his sculptures, installations, photography, and paintings, Liu Bolin explores the tensions between individualism and collectivism, particularly in his native China. In his most famous series, “Hiding in the City” (also known as “Invisible Man”), the photographer stands immobile, perfectly painted in camouflage to blend into detailed backgrounds that range from magazine stands to the Great Wall. With these compositions, Bolin comments on consumerism, rapid development, and the role of the artist in contemporary Chinese society. He has exhibited in New York, London, Paris, Beijing, Stockholm, and Hong Kong, and has given performances at the Hirshhorn Museum and Sculpture Garden, the Centre Pompidou, and Art Basel in Miami Beach. Bolin’s work belongs in the collections of the Baltimore Museum of Art, Fotografiska, the M+ Sigg Collection, the Museo Enzo Ferrari, and the Red Mansion Foundation.", abonnement2, "A1.png") { DatumCreatie = DateTime.UtcNow.AddDays(3) };
            Kunstenaar kunstenaar3 = new Kunstenaar("Sophie von Hellermann", DateTime.UtcNow, "sophie.vonhellermann@gmail.com", "In her imaginative large-scale paintings, Sophie von Hellermann depicts imagery from fables, mythology, literature, and current events that she imbues with subconscious associations. Von Hellermann studied at the Kunstakademie, Düsseldorf, and received her MFA from the Royal College of Art in London in 2001. She has exhibited widely throughout Europe and the United States, and her paintings are held in the collections of the Metropolitan Museum of Art and LACMA. Von Hellermann’s lush, gestural paintings—whose lyrical compositions express intense emotional and psychological content—are informed by German Expressionism. She smears pastel-hued paints directly onto wet, unprimed canvases using a broad brush to create a soft, romantic effect. All rendered in the same loose, painterly style, figures and their surroundings dissolve into each other, blurring the boundaries between subjects and space.", abonnement3, "A2.png");
            Kunstenaar kunstenaar4 = new Kunstenaar("Brian Alfred", DateTime.UtcNow, "brian.alfred@gmail.com", "Brian Alfred's paintings, collages, and animations examine how technology has altered our perception of our surroundings and how we process information. Working from photographs, Alfred uses a computer to reduce images (often of architecture, machinery, urban landscapes, and office interiors) to their essential forms, before turning these elements into flattened, bold color fields that retain a handmade feel. The 2009 series \"Millions Now Living Will Never Die!!!\" departs from Alfred's typically depopulated imagery, presenting 333 portraits of cultural figures who have influenced his artistic practice, including Pop artists Andy Warhol and James Rosenquist and musicians Miles Davis and Bob Marley. In 2004, a documentary about the Alfred titled ArtFlick 001 was featured at the Sundance Film Festival.", abonnement4, "A3.png");
            Kunstenaar kunstenaar5 = new Kunstenaar("KAWS", DateTime.UtcNow, "kaws@gmail.com", "KAWS, born Brian Donnelly, straddles the worlds of art and design with a prolific body of work that ranges from paintings, murals, and large-scale sculptures to merchandise, furniture, and toys. Much of it centers on Companion, a depressed Mickey Mouse–like character with X’s for eyes. KAWS got his start as a street artist in the late ’90s. His practice has earned him major shows at the Brooklyn Museum, the National Gallery of Victoria in Melbourne, and the Yuz Museum in Shanghai, among other institutions. Evoking the sensibilities of Pop artists such as Andy Warhol and Claes Oldenburg, KAWS embraces frequent brand collaborations and addresses the intersection of art and commerce with a playful sense of humor. His work has fetched eight figures on the secondary market.", abonnement5, "A4.jfif");
            //Kunstenaar kunstenaar6 = new Kunstenaar("Esme-Rose Mende", DateTime.UtcNow, "mende.er@gmail.com", "details", a6, "artist2.PNG");

            Kunstwerk kunstwerk1 = new Kunstwerk("Inspiring Flowers", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A1AT1.png" } }, false, "painting", kunstenaar2);
            Kunstwerk kunstwerk2 = new Kunstwerk("Thrill of Harmony", DateTime.UtcNow, 300, "Thoughtful colorplay made by the genius Issac Ellis", new List<Foto> { new() { Pad = "A1AT2.png" } }, false, "painting", kunstenaar2);
            Kunstwerk kunstwerk3 = new Kunstwerk("Stunning Psychology", DateTime.UtcNow, 1500, "Delicate work, that touches the senses", new List<Foto> { new() { Pad = "A2AT1.png" } }, false, "painting", kunstenaar3);
            Kunstwerk kunstwerk4 = new Kunstwerk("Curtain of Desire", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A3AT1.png" } }, false, "sculpture", kunstenaar4);
            Kunstwerk kunstwerk5 = new Kunstwerk("Reality of Crime", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A3AT2.png" }  }, false, "sculpture", kunstenaar4);
            Kunstwerk kunstwerk6 = new Kunstwerk("Gone", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A4AT1.png"} }, false, "drawing", kunstenaar5);
            Kunstwerk kunstwerk7 = new Kunstwerk("Supermodel", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A4AT2.png" }}, false, "drawing", kunstenaar5);
            Kunstwerk kunstwerk8 = new Kunstwerk("We've found comfort here", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "InaraA2.png" }, new() { Pad = "inaraA2Bis.png" } }, false, "painting", kunstenaar1);
            Kunstwerk kunstwerk9 = new Kunstwerk("Flowers", DateTime.UtcNow, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "artist3.PNG" }}, false, "painting", kunstenaar1);

                
            // kunstenaar1.AddKunstwerk(kunstwerk6);
            // kunstenaar1.AddKunstwerk(kunstwerk7);
            kunstenaar1.AddKunstwerk(kunstwerk8);
            kunstenaar1.AddKunstwerk(kunstwerk9);
            kunstenaar2.AddKunstwerk(kunstwerk1);
            kunstenaar2.AddKunstwerk(kunstwerk2);
            kunstenaar3.AddKunstwerk(kunstwerk3);

            kunstenaar4.AddKunstwerk(kunstwerk4);
            kunstenaar4.AddKunstwerk(kunstwerk5);
            kunstenaar5.AddKunstwerk(kunstwerk6);
            kunstenaar5.AddKunstwerk(kunstwerk7);

            _dbContext.Gebruikers.Add(klant1);
            _dbContext.Gebruikers.Add(kunstenaar1);
            _dbContext.Gebruikers.Add(kunstenaar2);
            _dbContext.Gebruikers.Add(kunstenaar3);
            _dbContext.Gebruikers.AddRange(new List<Kunstenaar>() { kunstenaar4, kunstenaar5 });
            kunstenaar1.AddKunstwerk(kunstwerk1);
            _dbContext.SaveChanges();

            Veiling veiling1 = new Veiling(DateTime.UtcNow, DateTime.UtcNow.AddDays(1), kunstwerk1.Prijs, kunstwerk1);
            kunstenaar1.Veilingen.Add(veiling1);
            veiling1.VoegBodToe(klant1, veiling1.MinPrijs + 100, DateTime.UtcNow.AddHours(12));
            _dbContext.Veilingen.Add(veiling1);
            _dbContext.SaveChanges();
        }
    }
}
