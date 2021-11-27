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
            public Uri UploadUri { get; set; }
        }
    }
}
