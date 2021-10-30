using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; //deze voor de async toevoegen, de andere is kek
using Project3H04.Server.Data;
using Project3H04.Shared.Kunstenaars;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project3H04.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KunstenaarController : ControllerBase
    {
        private readonly IKunstenaarService kunstenaarService;

        public KunstenaarController(IKunstenaarService KunstenaarService)
        {
            this.kunstenaarService = KunstenaarService;
        }

        //GET: api/<KunstenaarController>
        [HttpGet]
        public Task<List<Kunstenaar_DTO>> GetKunstenaars(string term = "", int take = 25, bool recentArtists = false)
        {
            return kunstenaarService.GetKunstenaars(term,take,recentArtists);
        }

        // GET api/<KunstenaarController>/5
        [HttpGet("{id}")]
        public Task<Kunstenaar_DTO> Get(int id)
        {
            return kunstenaarService.GetDetailAsync(id);
            //if(k == null)
            //    return NotFound();

            //return k;
        }


        //    return NotFound();
        //}

        // POST api/<KunstenaarController>
        //[HttpPost]
        //public ActionResult<Kunstenaar> Post(Kunstenaar_DTO kunst)
        //{

        //    Abonnement ab = new Abonnement(kunst.Abonnenment.StartDatum,
        //        new AbonnementType(kunst.Abonnenment.AbonnementType.Naam, kunst.Abonnenment.AbonnementType.Verlooptijd
        //        , kunst.Abonnenment.AbonnementType.Prijs));
        //    Kunstenaar kunstenaarToCreate = new Kunstenaar(kunst.Gebruikersnaam, kunst.GeboorteDatum, kunst.Email, kunst.Details,ab);

        //    _context.Gebruikers.Add(kunstenaarToCreate);
        //    _context.SaveChanges();

        //    return CreatedAtAction(nameof(Get), new { id = kunstenaarToCreate.GebruikerId },kunstenaarToCreate);
        //}

        // PUT api/<KunstenaarController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id)
        //{
        //    /* if (string.IsNullOrEmpty(naam))
        //         return BadRequest();*/

        //    Kunstenaar kunst = _kunstenaars.SingleOrDefault(x => x.GebruikerId==id);
        //    if (kunst == null)
        //        return NotFound();


        //    _context.Gebruikers.Update(kunst);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        //// DELETE api/<KunstenaarController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    /*if (string.IsNullOrEmpty(naam))
        //        return BadRequest();*/

        //    Kunstenaar kunst = _kunstenaars.SingleOrDefault(x => x.GebruikerId == id);
        //    if (kunst == null)
        //        return NotFound();

        //    _context.Gebruikers.Remove(kunst);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
