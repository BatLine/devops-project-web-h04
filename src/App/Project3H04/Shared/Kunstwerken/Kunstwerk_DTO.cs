using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3H04.Shared.Kunstwerken
{
    public class Kunstwerk_DTO
    {
            public string Naam { get; set; }

            public DateTime Einddatum { get; set; }

            public double Prijs { get; set; }

            public string Beschrijving { get; set; }

            public List<Foto_DTO> Fotos { get; set; }

            public bool TeKoop { get; set; }

            public bool IsVeilbaar { get; set; }

            public string Materiaal { get; set; }

            public string NaamKunstenaar { get; set; }
        
    }
}
