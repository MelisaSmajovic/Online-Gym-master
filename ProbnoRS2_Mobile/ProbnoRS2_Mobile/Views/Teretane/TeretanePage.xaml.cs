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
    public partial class TeretanePage : ContentPage
    {
        private readonly APIService _clanTeretane = new APIService("ClanTeretana");
        private TeretaneVM model = null;
        public TeretanePage()
        {
            InitializeComponent();
            BindingContext = model = new TeretaneVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Teretana;

            await Navigation.PushAsync(new TeretaneDetaljiPage(item));
        }
        private async void UclaniSe_Clicked(object sender, EventArgs e)
        {
            var terID = ((Button)sender).BindingContext;
            int teretanaID = int.Parse(terID.ToString());


            ClanTeretanaSearchRequest request = new ClanTeretanaSearchRequest();
            request.ClanId = Global.LogiraniClanId;
            request.TeretanaId = teretanaID;

            var list = await _clanTeretane.Get<IEnumerable<ClanTeretana>>(request);

            if (list.Count() > 0)
            {
                var stringBuilder = new StringBuilder();
                await Application.Current.MainPage.DisplayAlert("Već ste učlanjeni u ovu teretanu!", stringBuilder.ToString(), "OK");
              
            }
            else
            {

                await Navigation.PushAsync(new UclanjivanjePage(teretanaID));
            }

        }
        private async void PretragaPoNazivu_Clicked(object sender, EventArgs e)
        {
            await model.PretragaPoNazivu();
        }
        async void OnTextChanged(object sender, EventArgs e)
        {
            await model.PretragaPoNazivu();
        }
  
    }
}