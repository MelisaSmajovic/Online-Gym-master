using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
   public class RecenzijeTeretane
    {
        public int RecenzijaTeretaneId { get; set; }
        public int TeretanaId { get; set; }
        public int? Ocjena { get; set; }
        public string Komentar { get; set; }

        public int ClanId { get; set; }
        public virtual Clan Clan { get; set; }
        public virtual Teretana Teretana { get; set; }
    }
}
