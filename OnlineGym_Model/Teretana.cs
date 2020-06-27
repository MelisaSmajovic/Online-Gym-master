
using System;
using System.Collections.Generic;
using System.Text;
namespace OnlineGym_Model
{
    public class Teretana
    {
  
        public int TeretanaId { get; set; }
        public string Naziv { get; set; }

        public string Adresa { get; set; }
        public double ProsjecnaOcjena { get; set; }
        public TimeSpan PocetakRadnoVrijeme { get; set; }
        public TimeSpan KrajRadnoVrijeme { get; set; }
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
        public int GradId { get; set; }
        public virtual Gradovi Grad { get; set; }

    }
}
