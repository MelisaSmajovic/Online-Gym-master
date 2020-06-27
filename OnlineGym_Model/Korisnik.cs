using System;
using System.Collections.Generic;
using System.Text;
namespace OnlineGym_Model
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash{ get; set; }
        public byte[] Fotografija { get; set; }
        public byte[] FotografijaThum { get; set; }

        public ICollection<KorisnikUloge>KorisniciUloge { get; set; }

    }
}
