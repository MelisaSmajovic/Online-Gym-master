using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public partial class KorisnikUloge
    {
        public int KorisniciUlogeId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        public Uloga Uloga { get; set; }
    }
}
