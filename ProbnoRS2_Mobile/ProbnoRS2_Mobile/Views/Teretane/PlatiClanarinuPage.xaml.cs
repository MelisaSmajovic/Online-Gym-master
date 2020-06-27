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
    public partial class PlatiClanarinuPage : ContentPage
    {
        private PlatiClanarinuVM model = null;
        int TeretanaID = 0;
        public PlatiClanarinuPage(int TeretanaId)
        {
            InitializeComponent();
            TeretanaID = TeretanaId;
            BindingContext = model = new PlatiClanarinuVM();
          
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Plati_Clicked(object sender, EventArgs e)
        {
            await model.PlatiSnimi();
            await Navigation.PushAsync(new StripePlacanjePage());
    
        }

    }
}