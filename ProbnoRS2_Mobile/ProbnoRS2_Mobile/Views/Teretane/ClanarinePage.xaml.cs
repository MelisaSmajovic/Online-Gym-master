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
    public partial class ClanarinePage : ContentPage
    {
        private ClanarineVM model = null;
        public ClanarinePage()
        {
            InitializeComponent();
            BindingContext = model = new ClanarineVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
      
     
    }
}