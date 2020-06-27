using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class ClanTeretanaUpsertRequest
    {
        public int ClanId { get; set; }
        public int TeretanaId { get; set; }
        public DateTime DatumUclanjivanja { get; set; }
    }
}
