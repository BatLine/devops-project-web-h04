using Project3H04.Shared.Kunstenaars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Client.Services
{
    interface IKunstenaarService
    {
        List<Kunstenaar_DTO> Kunstenaars { get; set; }
        Task<List<Kunstenaar_DTO>> GetKunstenaars();
    }
}
