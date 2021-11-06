using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Data
{
    public class ApplicationDbcontext : DbContext
    {
        //Bij relatie moet foreign keys meestal niet meegeven, nrml pakt hij altijd de primary key
        
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Gebruiker
            builder.Entity<Gebruiker>()
                    .ToTable("Gebruiker").HasKey(x=>x.GebruikerId);

            builder.Entity<Gebruiker>()
             .HasDiscriminator<String>("gebruiker_type")
             .HasValue<Klant>("gebruiker_klant")
             .HasValue<Kunstenaar>("gebruiker_kunstenaar")
             .HasValue<Admin>("gebruiker_admin");


            builder.Entity<Gebruiker>().Property(x=>x.GebruikerId).ValueGeneratedOnAdd();
            builder.Entity<Gebruiker>().Property(x => x.Email).HasMaxLength(100);
            builder.Entity<Gebruiker>().Property(x => x.Geboortedatum).IsRequired();
            builder.Entity<Gebruiker>().Property(x => x.Gebruikersnaam).HasMaxLength(50).IsRequired();
            builder.Entity<Gebruiker>().Property(x => x.FotoPad);

            builder.Entity<Klant>().HasMany(x => x.Boden).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Klant>().HasMany(x => x.Bestellingen).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Kunstenaar>().HasOne(x => x.Abonnenment).WithOne().HasForeignKey<Kunstenaar>(x => x.AbonnenmentId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Kunstenaar>().HasMany(x => x.Kunstwerken).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Kunstenaar>().HasMany(x => x.Veilingen).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Kunstenaar>().Property(x => x.Details).HasMaxLength(1000).IsRequired();
            builder.Entity<Kunstenaar>().Property(x => x.StatusActiefKunstenaar).IsRequired();
            

            //Kunstwerk

            builder.Entity<Kunstwerk>()
                   .ToTable("Kunstwerk").HasKey(x => x.Id);
            builder.Entity<Kunstwerk>().Property(x => x.Naam).HasMaxLength(500).IsRequired();
            builder.Entity<Kunstwerk>().Property(x => x.Beschrijving).HasMaxLength(500).IsRequired();
            builder.Entity<Kunstwerk>().Property(x => x.Einddatum).IsRequired();
            //builder.Entity<Kunstwerk>().Property(x => x.Fotos);
            builder.Entity<Kunstwerk>().Property(x => x.IsVeilbaar).IsRequired();
            builder.Entity<Kunstwerk>().Property(x => x.Materiaal).IsRequired().HasMaxLength(100);
            builder.Entity<Kunstwerk>().Property(x => x.Naam).IsRequired().HasMaxLength(100);
            //builder.Entity<Kunstwerk>().Property(x => x.NaamKunstenaar).IsRequired().HasMaxLength(100);
            builder.Entity<Kunstwerk>().Property(x => x.Prijs).IsRequired();
            builder.Entity<Kunstwerk>().Property(x => x.TeKoop).IsRequired();
            builder.Entity<Kunstwerk>().HasMany(x => x.Fotos).WithOne().IsRequired();
            builder.Entity<Kunstwerk>().HasOne(x => x.Kunstenaar).WithMany(k => k.Kunstwerken).IsRequired();

            //Veiling
            builder.Entity<Veiling>()
                  .ToTable("Veiling").HasKey(x => x.Id);
            builder.Entity<Veiling>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Veiling>().Property(x => x.StartDatum).IsRequired();
            builder.Entity<Veiling>().Property(x => x.EindDatum).IsRequired();
            builder.Entity<Veiling>().Property(x => x.MinPrijs).IsRequired();
            builder.Entity<Veiling>().Property(x => x.KunstwerkNaam).IsRequired().HasMaxLength(100);

            //builder.Entity<Veiling>().HasOne(x => x.Kunstwerk).WithOne().HasForeignKey<Veiling>(x => x.KunstwerkNaam).IsRequired().OnDelete(DeleteBehavior.Cascade).HasForeignKey("Id");
            builder.Entity<Veiling>().HasMany(x => x.BodenOpVeiling).WithOne().OnDelete(DeleteBehavior.NoAction);

            //Bod
            builder.Entity<Bod>()
                 .ToTable("Bod").HasKey(x => x.Id);
            builder.Entity<Bod>().Property(x => x.Id).ValueGeneratedOnAdd();
            //builder.Entity<Bod>().Property(x => x.).IsRequired().HasMaxLength(100);
            builder.Entity<Bod>().Property(x => x.BodPrijs).IsRequired();


            //Bestellingen
            builder.Entity<Bestelling>()
              .ToTable("Bestelling").HasKey(x => x.Id);
            builder.Entity<Bestelling>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Bestelling>().Property(x => x.Datum).IsRequired();
            builder.Entity<Bestelling>().Property(x => x.Gemeente).IsRequired().HasMaxLength(100);
            builder.Entity<Bestelling>().Property(x => x.LeverDatum).IsRequired();
            builder.Entity<Bestelling>().Property(x => x.Postcode).IsRequired();
            builder.Entity<Bestelling>().Property(x => x.Straat).IsRequired().HasMaxLength(200);
            builder.Entity<Bestelling>().Property(x => x.TotalePrijs).IsRequired();

            //builder.Entity<Bestelling>().HasMany(x => x.WinkelmandKunstwerken).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Abonnement
            builder.Entity<Abonnement>()
                        .ToTable("Abonnement").HasKey(x => x.Id);
            builder.Entity<Abonnement>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Abonnement>().Property(x => x.StartDatum).IsRequired();
            builder.Entity<Abonnement>().Property(x => x.EindDatum).IsRequired();

            builder.Entity<Abonnement>().HasOne(x => x.AbonnementType).WithMany().IsRequired();

            //AbonnementType
            builder.Entity<AbonnementType>()
                        .ToTable("AbonnementType").HasKey(x => x.Naam);
            builder.Entity<AbonnementType>().Property(x => x.Naam).HasMaxLength(50).IsRequired();
            builder.Entity<AbonnementType>().Property(x => x.Prijs).IsRequired();
            builder.Entity<AbonnementType>().Property(x => x.Verlooptijd).IsRequired();
            //Foto
            builder.Entity<Foto>()
                                .ToTable("Foto").HasKey(f => f.Id);
            builder.Entity<Bestelling>().Property(x => x.Id).ValueGeneratedOnAdd();





            /*  modelBuilder.Entity<PersonTph>()
      .HasDiscriminator(person => person.Discriminator)
      .HasValue<PersonTph>(nameof(PersonTph))
      .HasValue<CustomerTph>(nameof(CustomerTph))
      .HasValue<EmployeeTph>(nameof(EmployeeTph));*/
            /* base.OnModelCreating(builder);
             builder.Entity<Recipe>()
                 .HasMany(p => p.Ingredients)
                 .WithOne()
                 .IsRequired()
                 .HasForeignKey("RecipeId"); //Shadow property
             builder.Entity<Recipe>().Property(r => r.Name).IsRequired().HasMaxLength(50);
             builder.Entity<Recipe>().Property(r => r.Chef).HasMaxLength(50);
             builder.Entity<Ingredient>().Property(r => r.Name).IsRequired().HasMaxLength(50);
             builder.Entity<Ingredient>().Property(r => r.Unit).HasMaxLength(10);

             //Another way to seed the database
             builder.Entity<Recipe>().HasData(
                  new Recipe { Id = 1, Name = "Spaghetti", Created = DateTime.Now, Chef = "Piet" },
                  new Recipe { Id = 2, Name = "Tomato soup", Created = DateTime.Now }
   );

             builder.Entity<Ingredient>().HasData(
                     //Shadow property can be used for the foreign key, in combination with anaonymous objects
                     new { Id = 1, Name = "Tomatoes", Amount = (double?)0.75, Unit = "liter", RecipeId = 1 },
                     new { Id = 2, Name = "Minced Meat", Amount = (double?)500, Unit = "grams", RecipeId = 1 },
                     new { Id = 3, Name = "Onion", Amount = (double?)2, RecipeId = 1 }
                  );

             */
        }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Kunstwerk> Kunstwerken { get; set; }
        public DbSet<Veiling> Veilingen { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Bod> Boden { get; set; }
        public DbSet<Abonnement> Abonnementen { get; set; }
        public DbSet<AbonnementType> AbonnementTypes { get; set; }

    }
}
