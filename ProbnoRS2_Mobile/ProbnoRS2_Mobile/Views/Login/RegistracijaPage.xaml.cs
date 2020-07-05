using OnlineGym_Model;
using OnlineGym_Model.Requests;
using ProbnoRS2_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbnoRS2_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistracijaPage : ContentPage
    {
        int odabraniGrad = 0;
        private RegistracijaVM model = null;
        private readonly APIService _clanovi = new APIService("Clan");
        public RegistracijaPage()
        {
            InitializeComponent();
            BindingContext = model = new RegistracijaVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
   

        private async void GradPicker_Changed(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            Gradovi odabrani = selectedItem as Gradovi;
            odabraniGrad = odabrani.GradId;

        }
            private async void Registracija_Clicked(object sender, EventArgs e)
        {

            if (ValidateInput())
            {

                Global.Username = inputKorisnickoIme.Text;
                var request = new ClanUpsertRequest
                {
                    Email = inputEmail.Text,
                    Ime = inputIme.Text,
                    Prezime = inputPrezime.Text,
                    KorisnickoIme = inputKorisnickoIme.Text,
                    Password = inputLozinka.Text,
                    PasswordPotvrda = inputLozinkaPotvrda.Text,
                    GradId = odabraniGrad,
                    DatumRegistracije = DateTime.Now
                };
               
                APIService.Context = "Clan";
                Clan entity = null;
                var stringBuilder = new StringBuilder();
                try
                {
                    entity = await _clanovi.Insert<Clan>(request);
                }
                catch (Exception exception) {
                    await Application.Current.MainPage.DisplayAlert("Korisničko ime je već zauzeto. Odaberite drugo!", stringBuilder.ToString(), "OK");
                    return;
                }
                await Application.Current.MainPage.DisplayAlert("Uspješno ste se registrovali!", stringBuilder.ToString(), "OK");
                if (entity != null)
                {
                    Application.Current.MainPage = new LoginPage();

                }
                await model.Init();
            }
            else
            {
                var stringBuilder = new StringBuilder();
                await Application.Current.MainPage.DisplayAlert("Unesite ispravne podatke!", stringBuilder.ToString(), "OK");
            }
        }

        private bool ValidateInput()
        {

            if (odabraniGrad == 0)
            {
                errorLabel.Text = "Odaberite grad!";
                return false;
            }

            if (inputKorisnickoIme.Text == null)
            {
                errorLabel.Text = "Unesite korisničko ime!";
                return false;
            }
            if (inputIme.Text == null)
            {
                errorLabel.Text = "Unesite ime!";
                return false;
            }
     
            if (inputPrezime.Text == null)
            {
                errorLabel.Text = "Unesite prezime!";
                return false;
            }
        
            if (inputEmail.Text == null)
            {
                errorLabel.Text = "Unesite e-mail!";
                return false;
            }
             if (inputEmail.Text != null)
            {
            if (!Regex.IsMatch(inputEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errorLabel.Text = "E-mail adresa nije u ispravnom formatu!";
                return false;
            }}
            if (inputLozinka.Text == null)
            {
                errorLabel.Text = "Unesite lozinku!";
                return false;
            }
            if (inputLozinkaPotvrda.Text == null)
            {
                errorLabel.Text = "Unesite potvrdu lozinke!";
                return false;
            }
            if (inputLozinka.Text != inputLozinkaPotvrda.Text)
            {
                errorLabel.Text = "Lozinke se ne podudaraju!";
              
                return false;
            }
                return true;
        }


    }
}
