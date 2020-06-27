using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
   public class Izlazi
    {
        public int IzlazId { get; set; }
        public DateTime Datum { get; set; }
        public bool Zakljucen { get; set; }
        public virtual Narudzbe Narudzba { get; set; }
        public decimal IznosSaPdv { get; set; }
        public int NarudzbaId { get; set; }
    }
}
