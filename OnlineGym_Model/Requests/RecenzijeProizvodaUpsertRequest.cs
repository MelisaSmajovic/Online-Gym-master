using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
   public class RecenzijeProizvodaUpsertRequest
    {
        public int RecenzijaProizvodaId { get; set; }
        public int? Ocjena { get; set; }
        public string Komentar { get; set; }
        public int ProizvodId { get; set; }
        public int ClanId { get; set; }
    }
}
