using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3H04.Shared.Kunstwerken;
namespace Project3H04.Shared.Kunstwerken
{
    public interface IKunstwerkService
    {
       // List<Kunstwerk_DTO.Detail> Kunstwerken { get; set; }
        Task<List<Kunstwerk_DTO.Index>> GetKunstwerken(string term, int take);
        Task<Kunstwerk_DTO.Detail> GetDetailAsync(int id);
    }
}
