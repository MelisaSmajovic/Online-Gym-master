using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class Obavijest
    {
        public int ObavijestId { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumObjave { get; set; }
    }
}
