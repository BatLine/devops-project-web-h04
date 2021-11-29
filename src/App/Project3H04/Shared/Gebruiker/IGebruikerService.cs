﻿using Project3H04.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3H04.Shared.Gebruiker
{
    public interface IGebruikerService
    {
        Task<Gebruiker_DTO> GetDetailAsync(int id);
        Task EditAsync(int id, Gebruiker_DTO geb);
    }
}