using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineGym_Model.Requests
{
    public class TeretanaUpsertRequest
    {
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int GradId { get; set; }
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
    }
}
