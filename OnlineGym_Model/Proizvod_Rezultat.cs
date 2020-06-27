using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
   public class Proizvod_Rezultat
    {
        public int ProizvodId { get; set; }
        public int KategorijaProizvodaId { get; set; }
        public string KategorijaProizvoda { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Sifra { get; set; }
        public double ProsjecnaOcjena { get; set; }
        public decimal? Cijena { get; set; } 
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public int VrstaProizvodaId { get; set; }
        public string VrstaProizvoda { get; set; }
        public Proizvod_Rezultat(Proizvod item)
        {
            ProizvodId = item.ProizvodId;
            KategorijaProizvodaId = item.KategorijaProizvodaId;
            KategorijaProizvoda = item.KategorijaProizvoda.Naziv;
            Naziv = item.Naziv;
            Opis = item.Opis;
            Sifra = item.Sifra;
            ProsjecnaOcjena = item.ProsjecnaOcjena;
            Cijena = item.Cijena;
            Slika = item.Slika;
            SlikaThumb = item.SlikaThumb;
            VrstaProizvodaId = item.VrstaProizvodaId;
            VrstaProizvoda = item.VrstaProizvoda.Naziv;
        }
    }
}
