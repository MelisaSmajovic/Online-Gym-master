using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Database
{
    public partial class Izlazi
    {
        public int IzlazId { get; set; }
        public decimal IznosSaPdv { get; set; }
        public DateTime Datum { get; set; }
        public bool Zakljucen { get; set; }

        public int NarudzbaId { get; set; }
        public virtual Narudzbe Narudzbe { get; set; }
    }
}
