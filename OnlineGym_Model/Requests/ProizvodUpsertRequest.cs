using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class ProizvodUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Sifra { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Cijena { get; set; }
        public string Opis { get; set; }
        public int KategorijaProizvodaId { get; set; }
        public int VrstaProizvodaId { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

    }
}
