using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project3H04.Shared.Kunstwerken
{
    public interface IFakeKunstwerkService
    {
        Task<IEnumerable<Kunstwerk_DTO.Index>> GetIndexAsync();
        Task<Kunstwerk_DTO.Detail> GetDetailAsync(int id);
    }
}
