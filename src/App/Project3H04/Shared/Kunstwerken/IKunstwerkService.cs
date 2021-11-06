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
        Task<List<Kunstwerk_DTO.Index>> GetKunstwerken(string termArtwork, string termArtist, decimal termMinimumPrice, decimal termMaximumPrice, int take, List<String> filters);
        Task<Kunstwerk_DTO.Detail> GetDetailAsync(int id);
        Task<int> CreateAsync(Kunstwerk_DTO.Create kunstwerk, int gebruikerId);
        Task UpdateAsync(Kunstwerk_DTO.Edit kunstwerk, int gebruikerId);

    }
}
