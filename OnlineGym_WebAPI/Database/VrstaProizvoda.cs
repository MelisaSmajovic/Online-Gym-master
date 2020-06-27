using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGym_WebAPI.Database
{
    public partial class VrstaProizvoda
    {
        public VrstaProizvoda()
        {
            Proizvod = new HashSet<Proizvod>();
        }

        public int VrstaProizvodaId { get; set; }
        public string Naziv { get; set; }

        public ICollection<Proizvod> Proizvod { get; set; }
    }
}

