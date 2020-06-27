using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class TeretanaSearchRequest
    {
        public int? GradId { get; set; }
        public int? TeretanaId { get; set; }
        public string Naziv { get; set; }
    }
}
