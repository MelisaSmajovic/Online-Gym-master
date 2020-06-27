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
    public partial class RecenzijaProizvodaPage : ContentPage
    {
        public int proizvodId;
        private readonly APIService _recenzijeProizvoda = new APIService("RecenzijeProizvoda");
        public RecenzijaProizvodaPage(int proizvodID)
        {
            InitializeComponent();
            proizvodId = proizvodID;
        }
        private async void btnSacuvajRecenziju_Clicked(object sender, EventArgs e)
        {
            RecenzijeProizvodaUpsertRequest request = new RecenzijeProizvodaUpsertRequest();
            request.ClanId = Global.LogiraniClanId;
            request.ProizvodId = proizvodId;
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

                RecenzijeProizvoda entity = null;
                entity = await _recenzijeProizvoda.Insert<RecenzijeProizvoda>(request);
                await Application.Current.MainPage.DisplayAlert("Uspješno ste dodali recenziju!", stringBuilder.ToString(), "OK");
                await Navigation.PushAsync(new ClanProizvodiPage());
            }

        }
    }
}