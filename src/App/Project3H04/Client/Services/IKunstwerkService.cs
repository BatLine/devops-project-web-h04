using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3H04.Shared.Kunstwerken;
namespace Project3H04.Client.Services
{
    public interface IKunstwerkService
    {
        List<Kunstwerk_DTO.Detail> Kunstwerken { get; set; }
        Task<List<Kunstwerk_DTO.Index>> GetKunstwerken();
        Task<Kunstwerk_DTO.Detail> GetDetailAsync(int id);
    }
}
