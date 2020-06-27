using OnlineGym_Model;
using OnlineGym_Model.Requests;
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
    public partial class RecenzijaTeretanePage : ContentPage
    {
        public int teretanaID;
        private readonly APIService _recenzijeTeretane = new APIService("RecenzijeTeretane");
        public RecenzijaTeretanePage(int teretanaId)
        {
            InitializeComponent();
            teretanaID = teretanaId;
        }
        private async void btnSacuvajRecenziju_Clicked(object sender, EventArgs e)
        {
            RecenzijeTeretaneUpsertRequest request = new RecenzijeTeretaneUpsertRequest();
            request.ClanId =Global.LogiraniClanId;
            request.TeretanaId = teretanaID;
            request.Komentar = inputKomentar.Text;
            var r = rating.Value;
            int ocjena = int.Parse(r.ToString());
            request.Ocjena = ocjena;
            var stringBuilder = new StringBuilder();
           
            if (ocjena == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Odaberite ocjenu!", stringBuilder.ToString(), "OK");
            }
            else
            {

                RecenzijeTeretane entity = null;
                entity = await _recenzijeTeretane.Insert<RecenzijeTeretane>(request);
              
                await Application.Current.MainPage.DisplayAlert("Uspješno ste dodali recenziju!", stringBuilder.ToString(), "OK");
                await Navigation.PushAsync(new ClanTeretanePage());


            }
        }
    }
}