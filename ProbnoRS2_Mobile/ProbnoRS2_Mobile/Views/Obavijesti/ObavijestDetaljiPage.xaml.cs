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
    public partial class ObavijestDetaljiPage : ContentPage
    {
        private ObavijestDetaljiVM model = null;
        int like = 0;
        int dislike = 0;
        public ObavijestDetaljiPage(Obavijest obj)
        {
            InitializeComponent();
            BindingContext = model = new ObavijestDetaljiVM()
            {
                Obavijest = obj
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (like == 0)
            {
                btnLike.TextColor = Color.Black;
            }
            if (like == 1)
            {
                btnLike.TextColor = Color.Gold;
            }
            if (dislike == 1)
            {
                btnDislike.TextColor = Color.Gold;
            }
            if (dislike == 0)
            {
                btnDislike.TextColor = Color.Black;
            }
        }
        private void Like_Clicked(object sender, EventArgs e)
        {

            if (btnLike.TextColor == Color.Black)
            {
                btnLike.TextColor = Color.Blue;
                btnDislike.TextColor = Color.Black;
                dislike = 0;
                like = 1;
            }
            else
            {
                btnLike.TextColor = Color.Black;
                dislike = 1;
                like = 0;
            }

        }
        private void Dislike_Clicked(object sender, EventArgs e)
        {

            if (btnDislike.TextColor == Color.Black)
            {
                btnDislike.TextColor = Color.Red;
                btnLike.TextColor = Color.Black;
                dislike = 1;
                like = 0;
            }
            else
            {
                btnDislike.TextColor = Color.Black;
                dislike = 0;
                like = 1;
            }

        }
    }
}