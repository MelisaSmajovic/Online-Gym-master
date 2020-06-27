using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
   public class IzlazUpsertRequest
    {
        public int? IzlazId { get; set; }
        public int? NarudzbaId { get; set; }
        public bool? Zakljucen { get; set; } 
        public DateTime Datum { get; set; }
        public decimal IznosSaPdv { get; set; }
    }
}
