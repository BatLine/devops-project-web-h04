using Project3H04.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3H04.Shared.Kunstwerken
{
   public interface IOrderService
    {
       public IList<Kunstwerk_DTO.Detail> CartKunstwerken { get; set; }
       public IList<Kunstwerk_DTO.Detail> GetCartKunstwerken();

        public void AddKunstwerk(Kunstwerk_DTO.Detail kunstwerk);
        public void RemoveKunstwerk(Kunstwerk_DTO.Detail kunstwerk);

        public Task PostOrderAsync(Bestelling_DTO.Create bestelling);
        public Task RemoveBestelling(string id);
        //public Task CreateBestelling();
    }
}
