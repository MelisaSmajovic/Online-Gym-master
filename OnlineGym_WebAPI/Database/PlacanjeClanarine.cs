using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class PlacanjeClanarine
    {
        public int PlacanjeClanarineId { get; set; }
        public double UkupanIznos { get; set; }
        public DateTime DatumUplate { get; set; }
        public int TipClanarineId { get; set; }
        public int ClanId { get; set; }
        public int? TeretanaId { get; set; }

        public virtual Clan Clan { get; set; }
        public virtual Teretana Teretana { get; set; }
        public virtual TipClanarine TipClanarine { get; set; }
    }
}
