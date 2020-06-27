using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public class Narudzbe
    {
        public int NarudzbaId { get; set; }
        public int ClanId { get; set; }
        public DateTime Datum { get; set; }
        public bool Procesirana { get; set; }
        public virtual Clan Clan { get; set; }
        public string BrojNarudzbe { get; set; }
        public int KorisnikId { get; set; }

    }
}
