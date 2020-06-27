using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
   public class IzlazSearchRequest
    {
        public int? NarudzbaId { get; set; }
        public DateTime? Datum { get; set; }
        public bool? Zakljucen { get; set; }
    }
}
