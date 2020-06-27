using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public class Proizvod
    {
        public int ProizvodId { get; set; }
        public int KategorijaProizvodaId { get; set; }
        public int VrstaProizvodaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Sifra { get; set; }
        public double ProsjecnaOcjena { get; set; }
        public decimal? Cijena { get; set; }

        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
 

        public virtual KategorijeProizvoda KategorijaProizvoda { get; set; }
        public virtual VrsteProizvoda VrstaProizvoda { get; set; }


    }
}
