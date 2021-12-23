using Domain;
using Microsoft.EntityFrameworkCore;
using Project3H04.Server.Data;
using Project3H04.Shared.Kunstenaars;
using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Services
{
    public class KunstenaarService : IKunstenaarService
    {

        private readonly ApplicationDbcontext dbContext;


        public KunstenaarService(ApplicationDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public List<Kunstenaar_DTO> Kunstenaars { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<Kunstenaar_DTO> GetDetailAsync(int id)
        {
            //vanaf nu ALTIJD IList gebruiken, anders werkt de cast niet  !!!
            //=>>>DEZE zijn slecht, kan NIET casten op deze manier!!!<<<=
            //---
            //DbSet<Kunstenaar> kunst = (DbSet<Kunstenaar>)dbContext.Gebruikers.Where(x => x is Kunstenaar).AsQueryable();
            //----
            //plan b
            // var y = dbContext.Kunstwerken.Where(z=>z.Kunstenaar.GebruikerId==id).Include(x=>x.Fotos).ToList();
            //IQueryable<Kunstenaar> y = (IQueryable<Kunstenaar>)dbContext.Gebruikers.Where(x => x is Kunstenaar);
            //y.Include(x => x.Kunstwerken).ThenInclude(x => x.Fotos).SingleOrDefault(x=>x.GebruikerId);

            //kunstwerk.fotos nog includen !!!

            var x = (Kunstenaar)dbContext.Gebruikers.OfType<Kunstenaar>().Include(k => k.Kunstwerken).ThenInclude(x => x.Fotos).SingleOrDefault(x => x.GebruikerId == id);
            //include van fotos ...
            Kunstenaar_DTO k = await Task.Run(() => new Kunstenaar_DTO
            {
                Gebruikersnaam = x.Gebruikersnaam,
                GebruikerId = x.GebruikerId,
                Details = x.Details,
                Email = x.Email,
                //deze nog goe omzette
                Kunstwerken = x.Kunstwerken.Select(x => new Kunstwerk_DTO.Index
                {
                    Id = x.Id,
                    Naam = x.Naam,
                    HoofdFoto = new(x.Fotos.FirstOrDefault().Naam, x.Fotos.FirstOrDefault().Locatie), //enkel eerste foto is nodig voor index
                    Prijs = x.Prijs
                }).ToList(),
                Fotopad = x.FotoPad
                //,Veilingen = (ICollection<Shared.DTO.Veiling_DTO>)x.Veilingen //omzetten naar dto
            });

            return k;
        }

        public async Task<Kunstenaar_DTO> GetKunstenaarByEmail(string email)
        {
            var x = (Kunstenaar)dbContext.Gebruikers.OfType<Kunstenaar>().Include(k => k.Kunstwerken).ThenInclude(x => x.Fotos).SingleOrDefault(x => x.Email == email);
            //include van fotos ...
            Kunstenaar_DTO k = await Task.Run(() => new Kunstenaar_DTO
            {
                Gebruikersnaam = x.Gebruikersnaam,
                GebruikerId = x.GebruikerId,
                Details = x.Details,
                Email = x.Email,
                //deze nog goe omzette
                Kunstwerken = x.Kunstwerken.Select(x => new Kunstwerk_DTO.Index
                {
                    Id = x.Id,
                    Naam = x.Naam,
                    HoofdFoto = new(x.Fotos.FirstOrDefault().Naam, x.Fotos.FirstOrDefault().Locatie), //enkel eerste foto is nodig voor index
                    Prijs = x.Prijs
                }).ToList(),
                Fotopad = x.FotoPad
                //,Veilingen = (ICollection<Shared.DTO.Veiling_DTO>)x.Veilingen //omzetten naar dto
            });

            return k;
        }

        public async Task<List<Kunstenaar_DTO>> GetKunstenaars(string term, int take, bool recentArtists)
        {
            if (term is null)
                term = "";
            //.Where(x=>x.Naam.Contains(searchterm))
            List<Kunstenaar_DTO> kunstenaars =
            await dbContext.Gebruikers.Where(x => x is Kunstenaar)  // .OfType<Kunstenaar>()
            .Select(x => new Kunstenaar_DTO
            {
                Gebruikersnaam = x.Gebruikersnaam,
                GebruikerId = x.GebruikerId,
                DatumCreatie = x.DatumCreatie,
                Fotopad = x.FotoPad,
               GeboortedatumShort = x.Geboortedatum.ToShortDateString()
            }).Where(k => k.Gebruikersnaam.Contains(term)).Take(take)
            .ToListAsync();
            if (recentArtists)
                return kunstenaars.OrderByDescending(x => x.DatumCreatie).ToList();

            return kunstenaars;


            // return items;
        }
    }
}
