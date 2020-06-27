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
    public partial class UclanjivanjePage : ContentPage
    {
       
        private UclanjivanjeVM model = null;
        private readonly APIService _teretane = new APIService("Teretana");
        public UclanjivanjePage(int teretana)
        {
            InitializeComponent();
            BindingContext = model = new UclanjivanjeVM()
            {
              TeretanaId=teretana
            };
        
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        
        private async void Uclani_Clicked(object sender, EventArgs e)
        { 
            await model.UclaniSnimi();
            var stringBuilder = new StringBuilder();
            await Application.Current.MainPage.DisplayAlert("Uspješno ste se učlanili u teretanu!", stringBuilder.ToString(), "OK");
            await Navigation.PushAsync(new TeretanePage());
        }
    }
}