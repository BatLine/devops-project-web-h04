using Project3H04.Shared.Kunstwerken;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project3H04.Shared.DTO;

namespace Project3H04.Shared.Veilingen {
    public class Veiling_DTO {
        public int Id { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int MinPrijs { get; set; }
        public IEnumerable<Bod_DTO> BodenOpVeiling { get; set; }
        public Kunstwerk_DTO.Detail Kunstwerk { get; set; }
        public Bod_DTO HoogsteBod => BodenOpVeiling.OrderByDescending(b => b.BodPrijs).FirstOrDefault();
    }
}
