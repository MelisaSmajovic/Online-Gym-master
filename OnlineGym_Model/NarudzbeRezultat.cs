using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public class NarudzbeRezultat
    {
        public int NarudzbaId { get; set; }
        public int ClanId { get; set; }
        public DateTime Datum { get; set; }
        public bool Otkazana { get; set; } 
        public bool Procesirana { get; set; }
        public string BrojNarudzbe { get; set; }
        public string Clan { get; set; }
        public NarudzbeRezultat(Narudzbe item)
        {
            NarudzbaId = item.NarudzbaId;
            ClanId = item.ClanId;
            Datum = item.Datum;
            Procesirana = item.Procesirana;
            Clan = item.Clan.Ime + " " + item.Clan.Prezime;
            BrojNarudzbe = item.BrojNarudzbe;
        }
        }
}
