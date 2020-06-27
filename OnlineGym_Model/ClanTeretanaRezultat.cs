using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public class ClanTeretanaRezultat
    {
        public int ClanTeretanaId { get; set; }
        public int TeretanaId { get; set; }
        public int ClanId { get; set; }
        public DateTime DatumUclanjivanja { get; set; }
        public string Clan { get; set; }
        public string Teretana { get; set; }
        public ClanTeretanaRezultat(ClanTeretana item)
        {
            ClanTeretanaId = item.ClanTeretanaId;
            TeretanaId = item.TeretanaId;
            ClanId = item.ClanId;
            DatumUclanjivanja = item.DatumUclanjivanja;
            Clan = item.Clan.Ime + " " + item.Clan.Prezime;
            if (item.Teretana != null)
                Teretana = item.Teretana.Naziv;
            else
                Teretana = "Sve teretane";

        }
    }
}
