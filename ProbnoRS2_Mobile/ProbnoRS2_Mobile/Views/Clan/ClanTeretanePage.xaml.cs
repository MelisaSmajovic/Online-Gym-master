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
    public partial class ClanTeretanePage : ContentPage
    {
        private readonly APIService _recenzije = new APIService("RecenzijeTeretane");
        private ClanTeretaneVM model = null;
        public ClanTeretanePage()
        {
            InitializeComponent();
            BindingContext = model = new ClanTeretaneVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void DodajRecenziju_Clicked(object sender, EventArgs e)
        {
            
            var terID = ((Button)sender).BindingContext;
            int teretanaID = int.Parse(terID.ToString());

            RecenzijeTeretaneSearchRequest request = new RecenzijeTeretaneSearchRequest();
            request.ClanId = Global.LogiraniClanId;
            request.TeretanaId = teretanaID;

            var list = await _recenzije.Get<IEnumerable<RecenzijeTeretane>>(request);

            if (list.Count() > 0)
            {
                var stringBuilder = new StringBuilder();
                await Application.Current.MainPage.DisplayAlert("Već ste dali recenziju za tu teretanu!", stringBuilder.ToString(), "OK");
              
            }
            else
            {
                await Navigation.PushAsync(new RecenzijaTeretanePage(teretanaID));
            }

        }
       
               private async void PregledClanarina_Clicked(object sender, EventArgs e)
        {
           
            var terID = ((Button)sender).BindingContext;
            int teretanaID = int.Parse(terID.ToString());
            await Navigation.PushAsync(new PlaceneClanarinePage(teretanaID));

        }
    }
}