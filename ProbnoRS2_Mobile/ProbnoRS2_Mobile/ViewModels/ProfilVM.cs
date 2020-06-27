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
    public class ProfilVM : BaseViewModel
    {
        private readonly APIService _clanovi = new APIService("Clan");
        public ProfilVM()
        {
        }
     
        public ObservableCollection<Clan> ClanoviList { get; set; } = new ObservableCollection<Clan>();
        public ICommand InitCommand { get; set; }
        public Clan LogiraniClan { get; set; }

    }
    }

