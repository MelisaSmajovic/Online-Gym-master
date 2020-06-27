using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public class ClanRezultat
    {
        public int ClanId { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public int GradId { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string Grad { get; set; }
        public ClanRezultat(Clan item)
        {
            ClanId = item.ClanId;
            Ime = item.Ime;
            Prezime = item.Prezime;
            Email = item.Email;
            GradId = item.GradId;
            DatumRegistracije = item.DatumRegistracije;
            KorisnickoIme = item.KorisnickoIme;
            LozinkaHash = item.LozinkaHash;
            Grad = item.Grad.Naziv;


        }
        }
}
