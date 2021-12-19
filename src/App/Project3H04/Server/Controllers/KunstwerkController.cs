﻿using Domain;
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
    [Authorize] //AUTH, op controller level altijd Authorize en dan bij de methods AllowAnonymous !
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
        [AllowAnonymous]
        [HttpGet]
        public Task<List<Kunstwerk_DTO.Index>> GetKunstwerken([FromQuery] Kunstwerk_DTO.Filter request)
        {
            return kunstwerkService.GetKunstwerken(request);
        }

        // GET api/<KunstwerkController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public Task<Kunstwerk_DTO.Detail> Get(int id)
        {
            return kunstwerkService.GetDetailAsync(id);
            //if(k == null)
            //    return NotFound();

            //return k;
        }



        // POST api/<KunstwerkController>
        [Authorize(Roles = "Administrator,Kunstenaar")]
        [HttpPost]
        public Task<KunstwerkResponse.Create> Create(Kunstwerk_DTO.Create kunst)
        {

            //int gebruikerId = GetAangemeldeGebruikerId();
            return kunstwerkService.CreateAsync(kunst);
        }



        // PUT api/<KunstwerkController>/5
        [Authorize(Roles = "Administrator,Kunstenaar")]
        [HttpPut("{id}")]
        public Task<KunstwerkResponse.Edit> Put(int id, Kunstwerk_DTO.Edit kunst)
        {
            /*if (id != kunst.Id)
                return BadRequest(); */



            /*Kunstwerk kunstwerk = _context.Kunstwerken.SingleOrDefault(x => x.Naam.Equals(naam));
            if (kunstwerk == null)
                return NotFound();*/

            int gebruikerId = GetAangemeldeGebruikerId();

            /*if (gebruikerId != kunst.KunstenaarId)
            {
                return BadRequest();
            }*/

            return kunstwerkService.UpdateAsync(kunst, gebruikerId);
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
        [AllowAnonymous]
        [HttpGet("materiaal/{amount}")]
        public Task<List<string>> GetMediums(int amount)
        {
            return kunstwerkService.GetMediums(amount);
        }

        [AllowAnonymous]
        [HttpGet("aantalKunst")]
        public Task<int> GetAantalKunst()
        {
            return kunstwerkService.GetAantalKunst();
        }

        private int GetAangemeldeGebruikerId()
        {
            //fakedata: 
            return 4;
        }
    }
}