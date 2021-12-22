using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3H04.Shared.Kunstwerken
{
    public class KunstwerkResponse
    {
        public class Create
        {
            public int KunstwerkId { get; set; }
            public IList<Uri> UploadUris { get; set; }
        }

        public class Edit
        {
            public IList<Uri> UploadUris { get; set; }

        }

        public class Index
        {
            public List<Kunstwerk_DTO.Index> Kunstwerken { get; set; }
        }

        public class Detail
        {
            public Kunstwerk_DTO.Detail Kunstwerk { get; set; }
        }
    }
}
