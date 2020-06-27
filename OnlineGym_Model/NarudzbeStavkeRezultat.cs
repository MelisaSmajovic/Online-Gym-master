using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public class NarudzbeStavkeRezultat
    {
        public int NarudzbeStavkeId { get; set; }
        public int NarudzbaId { get; set; }
        public int ProizvodId { get; set; }
        public int Kolicina { get; set; }
        public string Proizvod { get; set; }
        public decimal Cijena { get; set; }
        public NarudzbeStavkeRezultat(NarudzbeStavke item)
        {
            NarudzbaId = item.NarudzbaId;
            NarudzbeStavkeId = item.NarudzbeStavkeId;
            ProizvodId = item.ProizvodId;
            Kolicina = item.Kolicina;
            Proizvod = item.Proizvod.Naziv;
            Cijena = (decimal)item.Proizvod.Cijena;
        }
    }
}
