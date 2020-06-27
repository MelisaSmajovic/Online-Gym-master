using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class KategorijaProizvoda
    {
        public KategorijaProizvoda()
        {
            Proizvod = new HashSet<Proizvod>();
        }

        public int KategorijaProizvodaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public ICollection<Proizvod> Proizvod { get; set; }
    }
}
