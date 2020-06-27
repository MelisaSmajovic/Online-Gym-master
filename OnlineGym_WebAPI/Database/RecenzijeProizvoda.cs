using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class RecenzijeProizvoda
    {
        public int RecenzijaProizvodaId { get; set; }
        public int? Ocjena { get; set; }
        public string Komentar { get; set; }
        public int ClanId { get; set; }
        public int ProizvodId { get; set; }

        public virtual Clan Clan { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}
