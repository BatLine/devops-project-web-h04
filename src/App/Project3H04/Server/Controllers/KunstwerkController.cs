using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project3H04.Server.Data;
using Project3H04.Server.DTO;
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
        private readonly ApplicationDbcontext _context;

        public KunstwerkController(ApplicationDbcontext context)
        {
            _context = context;
        }

        //GET: api/<KunstwerkController>
        [HttpGet]
        public async Task<IActionResult> GetKunstwerken()
        {
            return Ok(await _context.Kunstwerken.Include(k => k.Fotos).ToListAsync());
        }

        // GET api/<KunstwerkController>/5
        [HttpGet("{id}")]
        public ActionResult<Kunstwerk> Get(string naam)
        {
            if (!string.IsNullOrEmpty(naam))
                return _context.Kunstwerken.SingleOrDefault(x => x.Naam.Equals(naam));



            return NotFound();
        }



        // POST api/<KunstwerkController>
/*        [HttpPost]
        public ActionResult<Kunstwerk> Post(Kunstwerk_DTO kunst)
        {
            Kunstwerk kunstwerkToCreate = new Kunstwerk(kunst.Naam, kunst.Einddatum, kunst.Prijs, kunst.Beschrijving, kunst.Fotos, kunst.IsVeilbaar, kunst.Materiaal, kunst.NaamKunstenaar); ;



            _context.Kunstwerken.Add(kunstwerkToCreate);
            _context.SaveChanges();



            return CreatedAtAction(nameof(Get), new { id = kunstwerkToCreate.Naam }, kunstwerkToCreate);
        }*/



        // PUT api/<KunstwerkController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string naam)
        {
            /* if (string.IsNullOrEmpty(naam))
            return BadRequest();*/



            Kunstwerk kunstwerk = _context.Kunstwerken.SingleOrDefault(x => x.Naam.Equals(naam));
            if (kunstwerk == null)
                return NotFound();




            _context.Kunstwerken.Update(kunstwerk);
            _context.SaveChanges();
            return NoContent();
        }



        // DELETE api/<KunstwerkController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string naam)
        {
            /*if (string.IsNullOrEmpty(naam))
            return BadRequest();*/
            Kunstwerk kunst = _context.Kunstwerken.SingleOrDefault(x => x.Naam.Equals(naam));
            if (kunst == null)
            {
                return NotFound();
            }
            _context.Kunstwerken.Remove(kunst);
            _context.SaveChanges();
            return NoContent();
        }
    }
}