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
    public class ClanProizvodiVM:BaseViewModel
    {
        private readonly APIService _narudzbe = new APIService("Narudzba");
        private readonly APIService _narudzbeStavke = new APIService("NarudzbaStavka");

        public ClanProizvodiVM()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ObservableCollection<Narudzbe> NarudzbeList { get; set; } = new ObservableCollection<Narudzbe>();
        public ObservableCollection<NarudzbeStavke> NarudzbeStavkeList { get; set; } = new ObservableCollection<NarudzbeStavke>();
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            NarudzbeStavkeList.Clear();

            NarudzbaSearchRequest search = new NarudzbaSearchRequest();
            search.ClanId = Global.LogiraniClanId;

            var list = await _narudzbe.Get<IEnumerable<Narudzbe>>(search);

            NarudzbeList.Clear();
            foreach (var narudzba in list)
            {
                NarudzbeList.Add(narudzba);
            }


            if (NarudzbeList.Count > 0) {
                for (int i = 0; i < NarudzbeList.Count; i++)
                {
                    NarudzbaStavkaSearchRequest request = new NarudzbaStavkaSearchRequest();
                    request.NarudzbaId = NarudzbeList[i].NarudzbaId;

                    var stavkeList = await _narudzbeStavke.Get<IEnumerable<NarudzbeStavke>>(request);
                    foreach (var stavka in stavkeList)
                    {
                        NarudzbeStavkeList.Add(stavka);
                    }
                }
            }



        }
    }
}
