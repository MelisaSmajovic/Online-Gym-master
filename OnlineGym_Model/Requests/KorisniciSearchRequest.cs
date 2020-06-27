using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class KorisniciSearchRequest
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }
        public string KorisnickoIme{ get; set; }

        public bool IsUlogeLoadingEnabled { get; set; }
        public bool AdminChecked { get; set; }
    }
}
