using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class PlacanjeClanarineSearchRequest
    {
        public int? ClanId { get; set; }
        public int? TipClanarineId { get; set; }
        public int? TeretanaId { get; set; }
        public int MjesecUplate { get; set; }
        public int GodinaUplate { get; set; }
    }
}
