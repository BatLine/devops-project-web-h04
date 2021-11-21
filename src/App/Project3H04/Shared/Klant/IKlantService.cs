using Project3H04.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3H04.Shared.Klant
{
    public interface IKlantService
    {
        Task<Klant_DTO> GetKlantById(int id);
        Task<Klant_DTO> GetKlantByEmail(string email);
        Task<string> CreateAsync(Klant_DTO klant);
        Task EditAsync(int id, Klant_DTO klant);
    }
}
