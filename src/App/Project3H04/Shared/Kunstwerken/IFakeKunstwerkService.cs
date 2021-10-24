using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project3H04.Shared.Kunstwerken
{
    public interface IFakeKunstwerkService
    {
        Task<IEnumerable<KunstwerkDTO.Index>> GetIndexAsync();
        Task<KunstwerkDTO.Detail> GetDetailAsync(int id);
    }
}
