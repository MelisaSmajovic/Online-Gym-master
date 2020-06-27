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
    public partial class ClanProizvodiPage : ContentPage
    {
        private readonly APIService _recenzije = new APIService("RecenzijeProizvoda");
        private ClanProizvodiVM model = null;
        public ClanProizvodiPage()
        {
            InitializeComponent();
            BindingContext = model = new ClanProizvodiVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void DodajRecenziju_Clicked(object sender, EventArgs e)
        {
            var proID = ((Button)sender).BindingContext;
            int proizvodID = int.Parse(proID.ToString());


            RecenzijeProizvodaSearchRequest request = new RecenzijeProizvodaSearchRequest();
            request.ClanId = Global.LogiraniClanId;
            request.ProizvodId = proizvodID;

            var list = await _recenzije.Get<IEnumerable<RecenzijeProizvoda>>(request);

            if (list.Count() > 0)
            {
                var stringBuilder = new StringBuilder();
                await Application.Current.MainPage.DisplayAlert("Već ste dali recenziju za taj proizvod!", stringBuilder.ToString(), "OK");
            }
            else
            {
                await Navigation.PushAsync(new RecenzijaProizvodaPage(proizvodID));
            }

        }
    }
}