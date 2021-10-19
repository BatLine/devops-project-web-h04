using Domain;
using Microsoft.AspNetCore.Mvc;
using Project3H04.Server.Data;
using Project3H04.Server.DTO;
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
        private readonly ApplicationDbcontext _context;
        private readonly IEnumerable<Kunstenaar> _kunstenaars;

        //private readonly IConfiguration _configuration;

        /* public DepartmentController(IConfiguration config)
         {
             this._configuration = config;
         }*/
        public KunstenaarController(ApplicationDbcontext context)
        {
            _context = context;
            _kunstenaars = (IEnumerable<Kunstenaar>)_context.Gebruikers.Where(x => x is Kunstenaar).ToList();
        }

        // GET: api/<KunstwerkController>
        [HttpGet]
        public IEnumerable<Kunstenaar> Get()
        {
            //werkt niet meer ViewData["Statussen"] = GetStatusSelectList(status);

            return _kunstenaars;
        }

        // GET api/<KunstwerkController>/5
        [HttpGet("{id}")]
        public ActionResult<Kunstenaar> Get(int id)
        {
            Kunstenaar kunst = _kunstenaars.SingleOrDefault(x => x.GebruikerId==id);
            if(kunst == null )
            return NotFound();

            return kunst;
        }

        // POST api/<KunstwerkController>
        [HttpPost]
        public ActionResult<Kunstenaar> Post(Kunstenaar_DTO kunst)
        {

            Abonnement ab = new Abonnement(kunst.Abonnenment.StartDatum,
                new AbonnementType(kunst.Abonnenment.AbonnementType.Naam, kunst.Abonnenment.AbonnementType.Verlooptijd
                , kunst.Abonnenment.AbonnementType.Prijs));
            Kunstenaar kunstenaarToCreate = new Kunstenaar(kunst.Gebruikersnaam, kunst.GeboorteDatum, kunst.Email, kunst.Details,ab);

            _context.Gebruikers.Add(kunstenaarToCreate);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = kunstenaarToCreate.GebruikerId },kunstenaarToCreate);
        }

        // PUT api/<KunstwerkController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            /* if (string.IsNullOrEmpty(naam))
                 return BadRequest();*/

            Kunstenaar kunst = _kunstenaars.SingleOrDefault(x => x.GebruikerId==id);
            if (kunst == null)
                return NotFound();


            _context.Gebruikers.Update(kunst);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<KunstwerkController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            /*if (string.IsNullOrEmpty(naam))
                return BadRequest();*/

            Kunstenaar kunst = _kunstenaars.SingleOrDefault(x => x.GebruikerId == id);
            if (kunst == null)
                return NotFound();

            _context.Gebruikers.Remove(kunst);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
