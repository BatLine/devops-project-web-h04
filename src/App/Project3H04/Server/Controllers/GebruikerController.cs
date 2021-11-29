﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly IGebruikerService gebruikerService;

        public GebruikerController(IGebruikerService gebruikerService)
        {
            this.gebruikerService = gebruikerService;
        }

        [HttpGet("{id}")]
        public Task<Gebruiker_DTO> Get(int id)
        {
            return gebruikerService.GetDetailAsync(id);
            //if(k == null)
            //    return NotFound();

            //return k;
        }

        [HttpPut("{id}")]
        public Task EditAsync(int id, Gebruiker_DTO geb)
        {
            return gebruikerService.EditAsync(id, geb);
        }


    }
}