using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class Teretana
    {
        public Teretana()
        {
            ClanTeretana = new HashSet<ClanTeretana>();
            PlacanjeClanarine = new HashSet<PlacanjeClanarine>();
            RecenzijeTeretane = new HashSet<RecenzijeTeretane>();
        }

        public int TeretanaId { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int GradId { get; set; }
        public double ProsjecnaOCjena { get; set; }
        public TimeSpan KrajRadnoVrijeme { get; set; }
        public TimeSpan PocetakRadnoVrijeme { get; set; }
        public byte[] Slika1 { get; set; }
        public byte[] SlikaThumb1 { get; set; }

        public byte[] Slika2 { get; set; }
        public byte[] SlikaThumb2 { get; set; }

        public byte[] Slika3 { get; set; }
        public byte[] SlikaThumb3 { get; set; }

        public byte[] Slika4 { get; set; }
        public byte[] SlikaThumb4 { get; set; }

        public byte[] Slika5 { get; set; }
        public byte[] SlikaThumb5 { get; set; }

        public virtual Grad Grad { get; set; }
        public ICollection<ClanTeretana> ClanTeretana { get; set; }
        public ICollection<PlacanjeClanarine> PlacanjeClanarine { get; set; }
        public ICollection<RecenzijeTeretane> RecenzijeTeretane { get; set; }
    }
}
