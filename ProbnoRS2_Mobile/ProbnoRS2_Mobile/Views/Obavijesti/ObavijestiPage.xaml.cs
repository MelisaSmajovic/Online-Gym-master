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
    public partial class ObavijestiPage : ContentPage
    {
        private readonly APIService _obavijesti = new APIService("Obavijest");
        private ObavijestiVM model = null;
        public ObavijestiPage()
        {
            InitializeComponent();
            BindingContext = model = new ObavijestiVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void OnDateSelected(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            date = DatePicker.Date;
            await model.CalcDatum(date);
          
        }
        private async void Obavijest_Clicked(object sender, EventArgs e)
        {
         
            var obID = ((Button)sender).BindingContext;
            int obavijestID = int.Parse(obID.ToString());

            Obavijest obv = await _obavijesti.GetById<Obavijest>(obavijestID);

            await Navigation.PushAsync(new ObavijestDetaljiPage(obv));

        }
        private async void btnClear_Clicked(object sender, EventArgs e)
        {
            await model.Init();
        }
        }
}