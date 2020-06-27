using System;
using System.Collections.Generic;
using System.Text;

namespace ProbnoRS2_Mobile.Models
{
    public enum MenuItemType
    {
        Pocetna,
        Kosarica,
        Proizvodi,
        Teretane,
        Profil,
        Obavijesti,
        PlaceneClanarine,
        KupljeniProizvodi,
        ClanTeretane,
        Odjava
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
