using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class Clan
    {
        public Clan()
        {
            ClanTeretana = new HashSet<ClanTeretana>();
            Narudzbe = new HashSet<Narudzbe>();
            PlacanjeClanarine = new HashSet<PlacanjeClanarine>();
            RecenzijeProizvoda = new HashSet<RecenzijeProizvoda>();
            RecenzijeTeretane = new HashSet<RecenzijeTeretane>();
        }

        public int ClanId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public int GradId { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public ICollection<ClanTeretana> ClanTeretana { get; set; }
        public ICollection<Narudzbe> Narudzbe { get; set; }
        public virtual Grad Grad { get; set; }
        public ICollection<PlacanjeClanarine> PlacanjeClanarine { get; set; }
        public ICollection<RecenzijeProizvoda> RecenzijeProizvoda { get; set; }
        public ICollection<RecenzijeTeretane> RecenzijeTeretane { get; set; }
    }
}
