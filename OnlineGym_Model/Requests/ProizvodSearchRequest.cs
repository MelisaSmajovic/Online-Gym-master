using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class ProizvodSearchRequest
    {
        public int? ProivodId { get; set; }
        public int? KategorijaProizvodaId { get; set; }
        public string Naziv { get; set; }
        public int? VrstaProizvodaId { get; set; }

    }
}
