using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class NarudzbaStavkaSearchRequest
    {
        public int? NarudzbeStavkeId { get; set; }
        //public int? StavkaId { get; set; }
        public int? NarudzbaId { get; set; }
        public int? ProizvodId { get; set; }
        public int? KategorijaId { get; set; }
    }
}
