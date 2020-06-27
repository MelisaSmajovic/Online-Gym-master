using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class TipClanarine
    {
        public TipClanarine()
        {
            PlacanjeClanarine = new HashSet<PlacanjeClanarine>();
        }

        public int TipClanarineId { get; set; }
        public string Tip { get; set; }
        public double Cijena { get; set; }

        public ICollection<PlacanjeClanarine> PlacanjeClanarine { get; set; }
    }
}
