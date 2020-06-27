using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class RecenzijeTeretaneSearchRequest
    {
        public int? RecenzijaTeretaneId { get; set; }
        public int? TeretanaId { get; set; }
        public int? ClanId { get; set; }
    }
}
