using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project3H04.Server.Data;
using Project3H04.Shared;
using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KunstwerkController : ControllerBase
    {
        private readonly IKunstwerkService kunstwerkService;

        public KunstwerkController(IKunstwerkService kunstwerkService)
        {
            this.kunstwerkService = kunstwerkService;
        }

        //GET: api/<KunstwerkController>
        [HttpGet]
        public Task<List<Kunstwerk_DTO.Index>> GetKunstwerken([FromQuery(Name = "termArtwork")] string termArtwork = "", [FromQuery(Name = "termArtist")] string termArtist = "", int take = 25, [FromQuery(Name = "filters")] List<string> filters = null)
        {
            return kunstwerkService.GetKunstwerken(termArtwork, termArtist, take, filters);
        }

        // GET api/<KunstwerkController>/5
        [HttpGet("{id}")]
        public Task<Kunstwerk_DTO.Detail> Get(int id)
        {
            return kunstwerkService.GetDetailAsync(id);
            //if(k == null)
            //    return NotFound();

            //return k;
        }



        // POST api/<KunstwerkController>
        [HttpPost]
        public async Task<int> Create(Kunstwerk_DTO.Create kunst)
        {
            //Kunstwerk kunstwerkToCreate = new Kunstwerk(kunst.Naam, kunst.Einddatum, kunst.Prijs, kunst.Beschrijving, kunst.Fotos, kunst.IsVeilbaar, kunst.Materiaal, kunst.NaamKunstenaar); ;
            //_context.Kunstwerken.Add(kunstwerkToCreate);
            //_context.SaveChanges();

            int gebruikerId = GetAangemeldeGebruikerId();
            int kunstwerkId = await kunstwerkService.CreateAsync(kunst, gebruikerId);
            return kunstwerkId;
        }



        // PUT api/<KunstwerkController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(string naam)
        //{
        //    /* if (string.IsNullOrEmpty(naam))
        //    return BadRequest();*/



        //    Kunstwerk kunstwerk = _context.Kunstwerken.SingleOrDefault(x => x.Naam.Equals(naam));
        //    if (kunstwerk == null)
        //        return NotFound();




        //    _context.Kunstwerken.Update(kunstwerk);
        //    _context.SaveChanges();
        //    return NoContent();
        //}



        //// DELETE api/<KunstwerkController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string naam)
        //{
        //    /*if (string.IsNullOrEmpty(naam))
        //    return BadRequest();*/
        //    Kunstwerk kunst = _context.Kunstwerken.SingleOrDefault(x => x.Naam.Equals(naam));
        //    if (kunst == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Kunstwerken.Remove(kunst);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        private int GetAangemeldeGebruikerId()
        {
            //fakedata: 
            return 1;
        }
    }
}