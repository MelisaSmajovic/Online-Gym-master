using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class Narudzbe
    {
        public Narudzbe()
        {
            NarudzbeStavke = new HashSet<NarudzbeStavke>();
        }

        public int NarudzbaId { get; set; }
        public int ClanId { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public bool Procesirana { get; set; }

        public virtual Clan Clan { get; set; }
        public ICollection<NarudzbeStavke> NarudzbeStavke { get; set; }
    }
}
