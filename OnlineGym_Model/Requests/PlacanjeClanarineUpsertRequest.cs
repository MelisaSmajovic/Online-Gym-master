using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
   public class PlacanjeClanarineUpsertRequest
    {
        public int ClanId { get; set; }
        public int TeretanaId { get; set; }
        public double UkupanIznos { get; set; }
        public DateTime DatumUplate { get; set; }
        public int TipClanarineId { get; set; }
    }
}
