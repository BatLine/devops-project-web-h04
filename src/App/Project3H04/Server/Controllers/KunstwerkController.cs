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
using Microsoft.AspNetCore.Authorization;  //AUTH

namespace Project3H04.Server.Controllers
{
    [AllowAnonymous] //AUTH
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
        public Task<List<Kunstwerk_DTO.Index>> GetKunstwerken([FromQuery] Kunstwerk_DTO.Filter request)
        {
            return kunstwerkService.GetKunstwerken(request);
        }

        // GET api/<KunstwerkController>/5
        [HttpGet("{id}")]
        public Task<Kunstwerk_DTO.Detail> Get(int id)
        {
            return kunstwerkService.GetDetailAsync(id);
        }



        // POST api/<KunstwerkController>
        [HttpPost]
        [Authorize] //AUTH
        public Task<KunstwerkResponse.Create> Create(Kunstwerk_DTO.Create kunst)
        {
            return kunstwerkService.CreateAsync(kunst);
        }



        // PUT api/<KunstwerkController>/5
        [HttpPut]
        public Task<KunstwerkResponse.Edit> Put(Kunstwerk_DTO.Edit kunst)
        {
            return kunstwerkService.UpdateAsync(kunst, kunst.KunstenaarId);
        }



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

        //GET: api/<KunstwerkController>/materiaal/5
        [HttpGet("materiaal/{amount}")]
        public Task<List<string>> GetMediums(int amount)
        {
            return kunstwerkService.GetMediums(amount);
        }

        [HttpGet("aantalKunst")]
        public Task<int> GetAantalKunst()
        {
            return kunstwerkService.GetAantalKunst();
        }

    }
}