using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    using System;
    public partial class Clan
    {        
        public int ClanId { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public int GradId { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public virtual Gradovi Grad { get; set; }
    

    }
}
