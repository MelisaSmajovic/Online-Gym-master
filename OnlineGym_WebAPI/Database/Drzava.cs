using System;
using System.Collections.Generic;

namespace OnlineGym_WebAPI.Database
{
    public partial class Drzava
    {
        public Drzava()
        {
            Grad = new HashSet<Grad>();
        }

        public int DrzavaId { get; set; }
        public string Naziv { get; set; }

        public ICollection<Grad> Grad { get; set; }
    }
}
