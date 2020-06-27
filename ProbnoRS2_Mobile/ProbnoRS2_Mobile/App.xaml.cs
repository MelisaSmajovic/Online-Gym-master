using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProbnoRS2_Mobile.Services;
using ProbnoRS2_Mobile.Views;
namespace ProbnoRS2_Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
