using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
   public class RecenzijeTeretaneUpsertRequest
    {
        public int? KomentarId { get; set; }
        public int? Ocjena { get; set; }
        public string Komentar { get; set; }
        public int? ClanId { get; set; }
        public int TeretanaId { get; set; }
    }
}
