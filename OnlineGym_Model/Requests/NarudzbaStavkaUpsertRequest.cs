using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class NarudzbaStavkaUpsertRequest
    {
        public int? NarudzbeStavkeId { get; set; }
        public int? Kolicina { get; set; }
        public int? ProizvodId { get; set; }
        public int? NarudzbaId { get; set; }
    }
}
