using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            KorisniciUloge = new HashSet<KorisniciUloge>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public byte[] Fotografija { get; set; }
        public byte[] FotografijaThum { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}
