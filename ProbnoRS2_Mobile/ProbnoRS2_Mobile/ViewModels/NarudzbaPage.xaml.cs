using ProbnoRS2_Mobile.Views.Uplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbnoRS2_Mobile.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NarudzbaPage : ContentPage
    {
        private readonly APIService _stavke = new APIService("NarudzbaStavka");
        private NarudzbaVM model = null;
        public NarudzbaPage()
        {
            InitializeComponent();
            BindingContext = model = new NarudzbaVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void btnUkloni_Clicked(object sender, EventArgs e)
        {
            if (Global.NarudzbaId != 0)
            {
                var stavkaID = ((Button)sender).BindingContext;
                int stavka = int.Parse(stavkaID.ToString());

                    bool obrisi = await _stavke.Delete(stavka);
                    if (obrisi == true)
                        await model.Init();
               
            }
            else
            {
                var stringBuilder = new StringBuilder();
                await Application.Current.MainPage.DisplayAlert("Narudžba je već plaćena, te ne možete brisati proizvode iz nje!", stringBuilder.ToString(), "OK");
            }
        }
        private async void btnPlati_Clicked(object sender, EventArgs e)
        {
            var stringBuilder = new StringBuilder();
            if (Global.NarudzbaId == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Već ste platili narudžbu!", stringBuilder.ToString(), "OK");
            }
            else
            {
                
                bool provjera = model.Provjera();
                if (provjera == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Vaša košarica je prazna!", stringBuilder.ToString(), "OK");

                }
                else
                {
                    await Navigation.PushAsync(new StripePlacanjePage());

                }
            }
        }
    }
    }
    