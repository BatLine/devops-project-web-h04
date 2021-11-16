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
          //  _dbContext.Database.EnsureDeleted();
           // if (_dbContext.Database.EnsureCreated())
           // {


                //seeding the database, see DBContext

                Klant klant = new Klant("klant1",DateTime.UtcNow,"klant@gmail.com", "artist3.PNG");

                AbonnementType at = new AbonnementType("default", 3, 200);
                Abonnement a = new Abonnement(DateTime.Now, at);
                Abonnement a2 = new Abonnement(DateTime.Now, at);
                Abonnement a3 = new Abonnement(DateTime.Now, at);
                Abonnement a4 = new Abonnement(DateTime.Now, at);
                Abonnement a5 = new Abonnement(DateTime.Now, at);
                Abonnement a6 = new Abonnement(DateTime.Now, at);

                Kunstenaar k = new Kunstenaar("Inara Nguyen", DateTime.Now, "inara.nguyen@gmail.com", "Inara Nguyen, born 1984 in Liaoning Province in China’s northeast, graduated from the prestigious Lu Xun Academy of Fine Arts in Shenyang in 2009. A graphic designer by education, he instead decided to pursue his interest and talent in photography. After numerous exhibitions in Asia and abroad, Luo is well-acclaimed internationally and has been featured by ARTE, ZDF Aspekte, Spiegel Online or Le Figaro International. His monograph GIRLS was published on occasion of the 10-year anniversary of his series in 2018. In the same year, BBC voted her among the 100 most inspiring women world-wide. He received the Jimei x Arles Women Photographer’s Award in 2019. In Luo’s work, highly staged portraits and carefully constructed poses alternate with a raw, blurred snapshot - aesthetic."
                    , a, "artist2.PNG") { DatumCreatie = DateTime.Today.AddDays(2) };

                Kunstenaar b = new Kunstenaar("Issac Ellis", DateTime.Now, "issac.ellis@gmail.com", "Throughout his sculptures, installations, photography, and paintings, Liu Bolin explores the tensions between individualism and collectivism, particularly in his native China. In his most famous series, “Hiding in the City” (also known as “Invisible Man”), the photographer stands immobile, perfectly painted in camouflage to blend into detailed backgrounds that range from magazine stands to the Great Wall. With these compositions, Bolin comments on consumerism, rapid development, and the role of the artist in contemporary Chinese society. He has exhibited in New York, London, Paris, Beijing, Stockholm, and Hong Kong, and has given performances at the Hirshhorn Museum and Sculpture Garden, the Centre Pompidou, and Art Basel in Miami Beach. Bolin’s work belongs in the collections of the Baltimore Museum of Art, Fotografiska, the M+ Sigg Collection, the Museo Enzo Ferrari, and the Red Mansion Foundation.", a2, "A1.png") { DatumCreatie = DateTime.Today.AddDays(3) };
                Kunstenaar c = new Kunstenaar("Sophie von Hellermann", DateTime.Now, "sophie.vonhellermann@gmail.com", "In her imaginative large-scale paintings, Sophie von Hellermann depicts imagery from fables, mythology, literature, and current events that she imbues with subconscious associations. Von Hellermann studied at the Kunstakademie, Düsseldorf, and received her MFA from the Royal College of Art in London in 2001. She has exhibited widely throughout Europe and the United States, and her paintings are held in the collections of the Metropolitan Museum of Art and LACMA. Von Hellermann’s lush, gestural paintings—whose lyrical compositions express intense emotional and psychological content—are informed by German Expressionism. She smears pastel-hued paints directly onto wet, unprimed canvases using a broad brush to create a soft, romantic effect. All rendered in the same loose, painterly style, figures and their surroundings dissolve into each other, blurring the boundaries between subjects and space.", a3, "A2.png");
                Kunstenaar d = new Kunstenaar("Brian Alfred", DateTime.Now, "brian.alfred@gmail.com", "Brian Alfred's paintings, collages, and animations examine how technology has altered our perception of our surroundings and how we process information. Working from photographs, Alfred uses a computer to reduce images (often of architecture, machinery, urban landscapes, and office interiors) to their essential forms, before turning these elements into flattened, bold color fields that retain a handmade feel. The 2009 series \"Millions Now Living Will Never Die!!!\" departs from Alfred's typically depopulated imagery, presenting 333 portraits of cultural figures who have influenced his artistic practice, including Pop artists Andy Warhol and James Rosenquist and musicians Miles Davis and Bob Marley. In 2004, a documentary about the Alfred titled ArtFlick 001 was featured at the Sundance Film Festival.", a4, "A3.png");
                Kunstenaar e = new Kunstenaar("KAWS", DateTime.Now, "kaws@gmail.com", "KAWS, born Brian Donnelly, straddles the worlds of art and design with a prolific body of work that ranges from paintings, murals, and large-scale sculptures to merchandise, furniture, and toys. Much of it centers on Companion, a depressed Mickey Mouse–like character with X’s for eyes. KAWS got his start as a street artist in the late ’90s. His practice has earned him major shows at the Brooklyn Museum, the National Gallery of Victoria in Melbourne, and the Yuz Museum in Shanghai, among other institutions. Evoking the sensibilities of Pop artists such as Andy Warhol and Claes Oldenburg, KAWS embraces frequent brand collaborations and addresses the intersection of art and commerce with a playful sense of humor. His work has fetched eight figures on the secondary market.", a5, "A4.jfif");
                //Kunstenaar f = new Kunstenaar("Esme-Rose Mende", DateTime.Now, "mende.er@gmail.com", "details", a6, "artist2.PNG");

                Kunstwerk kunst = new Kunstwerk("Flowers", DateTime.Now, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A1AT1.png" }}, false, "metaal", b);
                Kunstwerk kunst2 = new Kunstwerk("Thrill of Harmony", DateTime.Now, 300, "Thoughtful colorplay made by the genius Issac Ellis", new List<Foto> { new() { Pad = "A1AT2.png" } }, false, "hout", b);
                Kunstwerk kunst3 = new Kunstwerk("Stunning Psychology", DateTime.Now, 1500, "Delicate work, that touches the senses", new List<Foto> { new() { Pad = "A2AT1.png" } }, false, "hout", c);

                Kunstwerk kunst4 = new Kunstwerk("Curtain of Desire", DateTime.Now, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A3AT1.png" } }, false, "metaal", d);
                Kunstwerk kunst5 = new Kunstwerk("Reality of Crime", DateTime.Now, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A3AT2.png" }  }, false, "metaal", d);

                Kunstwerk kunst6 = new Kunstwerk("Gone", DateTime.Now, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A4AT1.png"} }, false, "metaal", e);
                Kunstwerk kunst7 = new Kunstwerk("Supermodel", DateTime.Now, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "A4AT2.png" }}, false, "metaal", e);
                Kunstwerk kunst8 = new Kunstwerk("We've found comfort here", DateTime.Now, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "InaraA2.png" }}, false, "metaal", k);
                Kunstwerk kunst9 = new Kunstwerk("Flowers", DateTime.Now, 200, "Beautiful work that inspires", new List<Foto> { new() { Pad = "artist3.PNG" }}, false, "metaal", k);

                
               // k.AddKunstwerk(kunst6);
               // k.AddKunstwerk(kunst7);
                k.AddKunstwerk(kunst8);
                k.AddKunstwerk(kunst9);
                b.AddKunstwerk(kunst);
                b.AddKunstwerk(kunst2);
                c.AddKunstwerk(kunst3);

                d.AddKunstwerk(kunst4);
                d.AddKunstwerk(kunst5);
                e.AddKunstwerk(kunst6);
                e.AddKunstwerk(kunst7);

                _dbContext.Gebruikers.Add(klant);
                _dbContext.Gebruikers.Add(k);
                _dbContext.Gebruikers.Add(b);
                _dbContext.Gebruikers.Add(c);
                _dbContext.Gebruikers.AddRange(new List<Kunstenaar>() { d, e});
                k.AddKunstwerk(kunst);
                _dbContext.SaveChanges();
         //   }
        }
    }
}
