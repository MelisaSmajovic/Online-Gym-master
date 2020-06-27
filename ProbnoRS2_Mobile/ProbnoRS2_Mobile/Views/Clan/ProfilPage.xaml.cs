using OnlineGym_Model;
using OnlineGym_Model.Requests;
using ProbnoRS2_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbnoRS2_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPage : ContentPage
    {
        private ProfilVM model = null;
        public ProfilPage(Clan clan)
        {
            InitializeComponent();
            BindingContext = model = new ProfilVM()
            {
                LogiraniClan=clan
            };
        
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        private async void Uredi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UrediProfilPage());

        }
        private async void Teretane_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClanTeretanePage());
        }
        }
}