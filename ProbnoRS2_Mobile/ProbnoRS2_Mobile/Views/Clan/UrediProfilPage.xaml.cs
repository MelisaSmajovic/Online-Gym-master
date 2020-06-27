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
    public partial class UrediProfilPage : ContentPage
    {
        private ProfilVM model = null;
        private readonly APIService _clanovi = new APIService("Clan");
        public UrediProfilPage()
        {
            InitializeComponent();
            BindingContext = model = new ProfilVM() {
                LogiraniClan = Global.LogiraniClan
            };
        }

            private async void btnUrediProfil_Clicked(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ClanUpsertRequest request = new ClanUpsertRequest();
                request.KorisnickoIme = inputKorisnickoIme.Text;
                request.StariPassword = inputStaraLozinka.Text;
                request.Password = inputLozinka.Text;
                request.PasswordPotvrda = inputLozinkaPotvrda.Text;
                request.GradId = Global.LogiraniClan.GradId;
                request.Ime = Global.LogiraniClan.Ime;
                request.Prezime = Global.LogiraniClan.Prezime;
                request.Email = Global.LogiraniClan.Email;
                request.DatumRegistracije = Global.LogiraniClan.DatumRegistracije;

           
                int logiraniID = Global.LogiraniClanId;

                var stringBuilder = new StringBuilder();



                ClanSearchRequest query = new ClanSearchRequest();
                query.Username = inputKorisnickoIme.Text;
                var lista = await _clanovi.Get<IEnumerable<Clan>>(query);

               
                if (lista.Count() > 0)
                {
                    Clan proba = Global.LogiraniClan; 
                    foreach(var korisnickoIme in lista)
                    {
                        if (korisnickoIme.KorisnickoIme != Global.Username)
                        {
                            await Application.Current.MainPage.DisplayAlert("Korisničko ime je već zauzeto! Molimo Vas da odaberete neko drugo", stringBuilder.ToString(), "OK");
                            return;
                        }
                    }
                    Clan entity = null;
                    try
                    {
                        entity = await _clanovi.Update<Clan>(logiraniID, request);
                    }
                    catch (Exception exception)
                    {
                        await Application.Current.MainPage.DisplayAlert("Unesite ispravnu staru lozinku!", stringBuilder.ToString(), "OK");
                        return;
                    }
                    APIService.Context = "Clan";
                    Global.Username = inputKorisnickoIme.Text;
                    await Application.Current.MainPage.DisplayAlert("Uspješno ste uredili profil", stringBuilder.ToString(), "OK");
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    Clan entity = null;
                    try
                    {
                        entity = await _clanovi.Update<Clan>(logiraniID, request);
                    }
                    catch(Exception exception)
                    {
                        await Application.Current.MainPage.DisplayAlert("Unesite ispravnu staru lozinku!", stringBuilder.ToString(), "OK");
                        return;
                    }
                    APIService.Context = "Clan";
                    Global.Username = inputKorisnickoIme.Text;
                    await Application.Current.MainPage.DisplayAlert("Uspješno ste uredili profil", stringBuilder.ToString(), "OK");
                    await Navigation.PushAsync(new LoginPage());
                }
            }
     
            else
            {
                var stringBuilder = new StringBuilder();
                await Application.Current.MainPage.DisplayAlert("Unesite ispravne podatke!", stringBuilder.ToString(), "OK");
            }

        }
        private bool ValidateInput()
        {
            if (inputKorisnickoIme.Text == "")
            {
                errorLabel.Text = "Unesite korisničko ime!";
                return false;
            }
            if (inputEmail.Text == "")
            {
                errorLabel.Text = "Unesite e-mail!";
                return false;
            }
            if (!Regex.IsMatch(inputEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errorLabel.Text = "E-mail adresa nije u ispravnom formatu!";
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