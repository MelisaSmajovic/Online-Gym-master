using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public class PlacanjeClanarineRezultat
    {
        public double UkupanIznos { get; set; }
        public DateTime DatumUplate { get; set; }
        public int Godina { get; set; }
        public int Mjesec { get; set; }
        public int TipClanarineId { get; set; }
        public int ClanId { get; set; }
        public int TeretanaId { get; set; }
        public string TipClanarine { get; set; }
        public string Teretana { get; set; }
        public string  Clan { get; set; }
        public PlacanjeClanarineRezultat(PlacanjeClanarine item)
        {
            UkupanIznos = item.UkupanIznos;
            ClanId = item.ClanId;
            DatumUplate = item.DatumUplate;
            TipClanarineId = item.TipClanarineId;
            ClanId = item.ClanId;
            TeretanaId = item.TeretanaId;
            TipClanarine = item.TipClanarine.Tip;
            Teretana = item.Teretana.Naziv;
            Clan = item.Clan.Ime + " " + item.Clan.Prezime;
            Godina = item.DatumUplate.Year;
            Mjesec = item.DatumUplate.Month;
      
        }
    }
}
