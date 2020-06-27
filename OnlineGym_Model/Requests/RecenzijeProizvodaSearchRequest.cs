using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class RecenzijeProizvodaSearchRequest
    {
        public int? RecenzijaProizvodaId { get; set; }
        public int? ProizvodId { get; set; }
        public int? ClanId { get; set; }
    }
}
