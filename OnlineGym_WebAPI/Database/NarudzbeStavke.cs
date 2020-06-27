using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class NarudzbeStavke
    {
        public int NarudzbeStavkeId { get; set; }


        public int NarudzbaId { get; set; }
        public int ProizvodId { get; set; }
        public int? Kolicina { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public virtual Narudzbe Narudzba { get; set; }
    }
}
