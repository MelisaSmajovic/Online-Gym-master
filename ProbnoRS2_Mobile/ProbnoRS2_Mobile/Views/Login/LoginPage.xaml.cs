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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();     
        }
        private void LoginButton_Clicked(object sender, EventArgs e)
        {

        }
            private void RegistrationButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegistracijaPage();
    

        }
    }
}