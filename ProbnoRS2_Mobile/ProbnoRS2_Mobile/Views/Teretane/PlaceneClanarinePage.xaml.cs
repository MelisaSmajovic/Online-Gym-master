using OnlineGym_Model;
using ProbnoRS2_Mobile.ViewModels;
using ProbnoRS2_Mobile.Views.Uplate;
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
    public partial class PlaceneClanarinePage : ContentPage
    {
        private PlaceneClanarineVM model = null;
        private readonly APIService _teretane = new APIService("Teretana");
        public int TerId = 0;
        public PlaceneClanarinePage(int teretanaId)
        {
            InitializeComponent();
       
            BindingContext = model = new PlaceneClanarineVM() { 
            TeretanaId=teretanaId
            };
            TerId = teretanaId;
         
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            Teretana Teretanaa = await _teretane.GetById<Teretana>(TerId);
            string Naziv = Teretanaa.Naziv;
            labNaziv.Text = Naziv;
        }
        private async void Uplata_Clicked(object sender, EventArgs e)
        {
            var t = ((Button)sender).BindingContext;
            int trtId = int.Parse(t.ToString());
            await Navigation.PushAsync(new UplataClanarinePage());


        }
    }
}