using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProbnoRS2_Mobile.Models;
using ProbnoRS2_Mobile.Views;
using System.Windows.Input;
using OnlineGym_Model;
using System.Collections.Generic;
using OnlineGym_Model.Requests;

namespace ProbnoRS2_Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly APIService _preporuceniProizvodi = new APIService("SistemPreporukeProizvodi/GetPreporukaByClan");
        private readonly APIService _preporuceneTeretane = new APIService("SistemPreporukeTeretane");
        private readonly APIService _clanovi = new APIService("Clan");
        public ObservableCollection<Clan> ClanoviList { get; set; } = new ObservableCollection<Clan>();
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Proizvod> PreporuceniProizvodiList { get; set; } = new ObservableCollection<Proizvod>();
        public ObservableCollection<Teretana> PreporuceneTeretaneList { get; set; } = new ObservableCollection<Teretana>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            ClanSearchRequest search = new ClanSearchRequest();
            search.Username = Global.Username;
            var list = await _clanovi.Get<List<Clan>>(search);

            var clan = list[0];

            ClanoviList.Clear();

            Global.LogiraniClanId = clan.ClanId;
            Global.LogiraniClan = clan;

            ClanoviList.Add(clan);


            Clan clanQuery = Global.LogiraniClan;
            var ProizvodiList = await _preporuceniProizvodi.Get<List<Proizvod>>(clanQuery);
            PreporuceniProizvodiList.Clear();
               foreach (var proizvod in ProizvodiList)
              {
              
                    PreporuceniProizvodiList.Add(proizvod);
           }
            int gradId = 0;
            if (Global.LogiraniClan != null)
            {
               gradId = Global.LogiraniClan.GradId;
            }
      
            var TeretaneList = await _preporuceneTeretane.Get<List<Teretana>>(gradId);
            PreporuceneTeretaneList.Clear();
            if (TeretaneList != null)
            {
                foreach (var teretana in TeretaneList)
                {
                    PreporuceneTeretaneList.Add(teretana);

                }
            }
        }
            async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}