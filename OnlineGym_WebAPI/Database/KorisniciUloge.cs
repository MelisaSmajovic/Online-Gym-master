using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class KorisniciUloge
    {
        public int KorisniciUlogeId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        [JsonIgnore]
        public virtual Korisnik Korisnik { get; set; }
        public Uloga Uloga { get; set; }
    }
}
