using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3H04.Shared.Kunstwerken
{
    public class FakeKunstwerkService : IKunstwerkService
    {
        private static List<KunstwerkDTO.Detail> _kunstwerken = new();
        static FakeKunstwerkService()
        {
            var lijstKunstwerken = new List<KunstwerkDTO.Detail>()
            {
               new KunstwerkDTO.Detail(1, "kunstwerk 1", 200, new List<string>{"artist1.PNG"},"Hout", "kunstenaar 1","bla bla"),
               new KunstwerkDTO.Detail(2, "kunstwerk 2", 300, new List<string>{"artist2.PNG"},"Hout", "kunstenaar 1", "bla bla")
            };
            _kunstwerken.AddRange(lijstKunstwerken);
        }
        public async Task<IEnumerable<KunstwerkDTO.Index>> GetIndexAsync()
        {
            await Task.Delay(100);
            return _kunstwerken.AsEnumerable();
        }

        public async Task<KunstwerkDTO.Detail> GetDetailAsync(int id)
        {
            await Task.Delay(100);
            return  _kunstwerken.SingleOrDefault(k => k.Id == id);
        }

       
    }
}
