using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class ObavijestUpsertRequest
    {
        public int? ObavijestId { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
    }
}
