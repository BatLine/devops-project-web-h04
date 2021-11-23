using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Foto
    {
        private static readonly string defaultLocatie = "https://devopsh04storage.blob.core.windows.net/fotos/images/";

        public int Id { get; set; }
        public string Pad => Path.Combine(defaultLocatie, Naam);

        public string Naam { get; set; }
        public string Locatie { get; set; }

        public Foto()
        {
            Locatie = defaultLocatie;
        }

        public override bool Equals(object obj)
        {
            return obj is Foto foto &&
                   Id == foto.Id;
        }
    }
}
