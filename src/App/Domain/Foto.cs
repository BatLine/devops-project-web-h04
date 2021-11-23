using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Foto
    {
        public int Id { get; set; }
        public string Pad{ get; set; }

        public override bool Equals(object obj)
        {
            return obj is Foto foto &&
                   Id == foto.Id;
        }
    }
}
