using ProbnoRS2_Mobile.Models;
using ProbnoRS2_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbnoRS2_Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private GlobalVM model = null;
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = model = new GlobalVM();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Pocetna, Title="Početna" ,Icon= "\xf2bd" },
                new HomeMenuItem {Id = MenuItemType.Kosarica, Title="Košarica",Icon="\xf004" },
                new HomeMenuItem {Id = MenuItemType.Proizvodi, Title="Proizvodi" ,Icon="\xf1c4"},
                new HomeMenuItem {Id = MenuItemType.Teretane, Title="Teretane",Icon="\xf1ad" },
                new HomeMenuItem {Id = MenuItemType.Profil, Title="Moj profil",Icon="\xf2bd" },
                new HomeMenuItem {Id = MenuItemType.Obavijesti, Title="Obavijesti",Icon="\xf0f3" },
                new HomeMenuItem {Id = MenuItemType.PlaceneClanarine, Title="Plaćene članarine",Icon="\xf09d" },
                new HomeMenuItem {Id = MenuItemType.KupljeniProizvodi, Title="Kupljeni proizvodi",Icon="\xf3d1" },
                new HomeMenuItem {Id = MenuItemType.ClanTeretane, Title="Moje teretane",Icon="\xf058" },
                 new HomeMenuItem {Id = MenuItemType.Odjava, Title="Odjavi se",Icon="\xf14d" },

            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}