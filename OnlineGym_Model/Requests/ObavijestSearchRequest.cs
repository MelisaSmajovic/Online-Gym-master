using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
   public class ObavijestSearchRequest
    {
        public int? ObavijestId { get; set; }
        public string Naziv { get; set; }

        public DateTime? DatumObjave { get; set; }
    }
}
