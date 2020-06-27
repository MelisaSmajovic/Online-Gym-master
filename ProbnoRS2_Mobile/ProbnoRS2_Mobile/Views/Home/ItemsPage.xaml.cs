using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ProbnoRS2_Mobile.Models;
using ProbnoRS2_Mobile.Views;
using ProbnoRS2_Mobile.ViewModels;
using OnlineGym_Model;

namespace ProbnoRS2_Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        private readonly APIService _obavijesti = new APIService("Obavijest");
        private readonly APIService _teretane = new APIService("Teretana");
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
        }

      
        async void Teretane_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeretanePage());
      
        }
        async void TeretanaDetalji_Clicked(object sender, EventArgs e)
        {
            Teretana ter = ((StackLayout)sender).BindingContext as Teretana;
            await Navigation.PushAsync(new TeretaneDetaljiPage(ter));

        }
        async void ProizvodDetalji_Clicked(object sender, EventArgs e)
        {
            Proizvod pro = ((StackLayout)sender).BindingContext as Proizvod;
            await Navigation.PushAsync(new ProizvodDetaljiPage(pro));

        }
        async void Proizvodi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProizvodiPage());
        
        }
        async void Obavijest_Clicked(object sender, EventArgs e)
        {
            int obavijestID = 10;
            Obavijest obv = await _obavijesti.GetById<Obavijest>(obavijestID);
            await Navigation.PushAsync(new ObavijestDetaljiPage(obv));

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
        }
    }
}