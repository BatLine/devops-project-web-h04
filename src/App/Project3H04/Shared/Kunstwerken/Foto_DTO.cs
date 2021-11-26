

using System.IO;

namespace Project3H04.Shared.Kunstwerken
{
    public class Foto_DTO
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public string Pad => Path.Combine(Locatie is not null ? Locatie : "", Naam);
        //public bool Uploaded { get; set; } 

        public Foto_DTO()
        {
            //Uploaded = false;
        }

        public Foto_DTO(string naam) : this()
        {
            Naam = naam;
        }

        public Foto_DTO(string naam, string locatie) : this(naam)
        {
            Locatie = locatie;
        }
    }
}
