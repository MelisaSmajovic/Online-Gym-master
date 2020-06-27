using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineGym_WebAPI.Database
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            NarudzbeStavke = new HashSet<NarudzbeStavke>();
            RecenzijeProizvoda = new HashSet<RecenzijeProizvoda>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProizvodId { get; set; }
        public int KategorijaProizvodaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Sifra { get; set; }
        public double ProsjecnaOcjena { get; set; }
        public decimal? Cijena { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public int VrstaProizvodaId { get; set; }

        public virtual KategorijaProizvoda KategorijaProizvoda { get; set; }
        public virtual VrstaProizvoda VrstaProizvoda { get; set; }
        public ICollection<NarudzbeStavke> NarudzbeStavke { get; set; }
        public ICollection<RecenzijeProizvoda> RecenzijeProizvoda { get; set; }
    }
}
