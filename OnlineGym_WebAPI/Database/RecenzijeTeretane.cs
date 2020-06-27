using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class RecenzijeTeretane
    {
        public int KomentarId { get; set; }
        public string Komentar { get; set; }
        public int ClanId { get; set; }
        public int TeretanaId { get; set; }
        public int? Ocjena { get; set; }

        public virtual Clan Clan { get; set; }
        public virtual Teretana Teretana { get; set; }
    }
}
