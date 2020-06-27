using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class NarudzbaSearchRequest
    {
        public int? NarudzbaId { get; set; }
        public int? ClanId { get; set; }
        public DateTime? Datum { get; set; }
        public bool? Procesirana { get; set; }
    }
}
