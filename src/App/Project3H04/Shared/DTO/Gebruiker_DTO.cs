﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Shared.DTO
{
    public class Gebruiker_DTO
    {
        public string Gebruikersnaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Email { get; set; }
    }
}