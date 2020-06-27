using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGym_Model
{
    public class Teretana_Rezultat
    {
        public int TeretanaId { get; set; }
        public string Naziv { get; set; }

        public string Adresa { get; set; }
        public double ProsjecnaOcjena { get; set; }
        public TimeSpan PocetakRadnoVrijeme { get; set; }
        public TimeSpan KrajRadnoVrijeme { get; set; }
        public string RadnoVrijeme { get; set; }
        public int GradId { get; set; }
        public string Grad { get; set; }
        public Teretana_Rezultat(Teretana item)
        {
            TeretanaId = item.TeretanaId;
            Naziv = item.Naziv;
            Adresa = item.Adresa;
            ProsjecnaOcjena = item.ProsjecnaOcjena;
            PocetakRadnoVrijeme = item.PocetakRadnoVrijeme;
            KrajRadnoVrijeme = item.KrajRadnoVrijeme;
            GradId = item.GradId;
            Grad = item.Grad.Naziv;
            RadnoVrijeme = PocetakRadnoVrijeme.ToString(@"hh\:mm") + " - " + KrajRadnoVrijeme.ToString(@"hh\:mm");
        }
        }
}
