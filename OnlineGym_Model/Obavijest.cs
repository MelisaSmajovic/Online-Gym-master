using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public class Obavijest
    {
        public int ObavijestId { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime? DatumObjave { get; set; }
    }
}
