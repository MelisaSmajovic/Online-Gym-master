using OnlineGym_Model;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProbnoRS2_Mobile.ViewModels
{
    public class RegistracijaVM : BaseViewModel
    {
        private readonly APIService _gradovi = new APIService("GradTest");
        private readonly APIService _clanovi = new APIService("Clan");

        public RegistracijaVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public ObservableCollection<Gradovi> GradoviList { get; set; } = new ObservableCollection<Gradovi>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {

            if (GradoviList.Count == 0)
            {
                var gradoviList = await _gradovi.Get<List<Gradovi>>(null);

                foreach (var grad in gradoviList)
                {
                    GradoviList.Add(grad);
                }
            }




            APIService.Username = Username;
            APIService.Password = Password;
            APIService.Context = "Clan";


        }
    }
}
