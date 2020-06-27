using OnlineGym_Model;
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
    public partial class TeretaneDetaljiPage : ContentPage
    {
        private TeretaneDetaljiVM model = null;
        public Teretana teretanaa;
        public TeretaneDetaljiPage(Teretana teretana)
        {
            InitializeComponent();
            BindingContext = model = new TeretaneDetaljiVM()
            {
                Teretana = teretana
            };
            teretanaa = teretana;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void UclaniSe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UclanjivanjePage(teretanaa.TeretanaId));

        }
   


    }
}