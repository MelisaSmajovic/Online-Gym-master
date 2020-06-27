using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class ClanTeretana
    {
        public int ClanTeretanaId { get; set; }
        public int TeretanaId { get; set; }
        public int ClanId { get; set; }
        public DateTime DatumUclanjivanja { get; set; }

        public virtual Clan Clan { get; set; }
        public virtual Teretana Teretana { get; set; }
    }
}
