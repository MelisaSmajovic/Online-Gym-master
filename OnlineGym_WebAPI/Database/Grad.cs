using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Teretana = new HashSet<Teretana>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
        public int DrzavaId { get; set; }

        public Drzava Drzava { get; set; }
        public ICollection<Teretana> Teretana { get; set; }
    }
}
