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
    public class ClanTeretaneVM:BaseViewModel
    {
        private readonly APIService _clanTeretane = new APIService("ClanTeretana");
        private readonly APIService _teretane = new APIService("Teretana");
        private readonly APIService _recenzijeTeretane = new APIService("RecenzijeTeretane");
        public Teretana Teretana { get; set; }

        public ClanTeretaneVM()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ObservableCollection<Teretana> TeretaneList { get; set; } = new ObservableCollection<Teretana>();
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
          
                ClanTeretanaSearchRequest search = new ClanTeretanaSearchRequest();
            search.ClanId = Global.LogiraniClanId;

                var list = await _clanTeretane.Get<IEnumerable<ClanTeretana>>(search);

                TeretaneList.Clear();
            foreach (var teretana in list)
            {
   
                Teretana t = await _teretane.GetById<Teretana>(teretana.TeretanaId);
                TeretaneList.Add(t);
                }

        }

        }
}
