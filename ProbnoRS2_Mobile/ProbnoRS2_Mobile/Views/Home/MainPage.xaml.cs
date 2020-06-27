using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ProbnoRS2_Mobile.Models;
using OnlineGym_Model;
using ProbnoRS2_Mobile.Views.Login;
using ProbnoRS2_Mobile.ViewModels;

namespace ProbnoRS2_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Pocetna, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Pocetna:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.Kosarica:
                        MenuPages.Add(id, new NavigationPage(new NarudzbaPage()));
                        break;
                    case (int)MenuItemType.Proizvodi:
                        MenuPages.Add(id, new NavigationPage(new ProizvodiPage()));
                        break;
                    case (int)MenuItemType.Teretane:
                        MenuPages.Add(id, new NavigationPage(new TeretanePage()));
                        break;
                    case (int)MenuItemType.Profil:
                        MenuPages.Add(id, new NavigationPage(new ProfilPage(Global.LogiraniClan)));
                        break;
                    case (int)MenuItemType.Obavijesti:
                        MenuPages.Add(id, new NavigationPage(new ObavijestiPage()));
                        break;
                    case (int)MenuItemType.PlaceneClanarine:
                        MenuPages.Add(id, new NavigationPage(new ClanarinePage()));
                        break;
                    case (int)MenuItemType.KupljeniProizvodi:
                        MenuPages.Add(id, new NavigationPage(new ClanProizvodiPage()));
                        break;
                    case (int)MenuItemType.ClanTeretane:
                        MenuPages.Add(id, new NavigationPage(new ClanTeretanePage()));
                        break;
                    case (int)MenuItemType.Odjava:
                        MenuPages.Add(id, new NavigationPage(new OdjavaPage()));
                        break;         
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}