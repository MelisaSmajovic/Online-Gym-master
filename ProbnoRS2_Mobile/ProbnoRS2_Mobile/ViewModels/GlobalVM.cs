using OnlineGym_Model;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProbnoRS2_Mobile.ViewModels
{
    public class GlobalVM:BaseViewModel
    {
        private readonly APIService _clanovi = new APIService("Clan");
        public ObservableCollection<Clan> ClanoviList { get; set; } = new ObservableCollection<Clan>();
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
            //vidi da li da premjestis negdje ovaj global !! -probacu u itemsPage da premjestim

        }
    }
}
