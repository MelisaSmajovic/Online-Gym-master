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
    public class ClanarineVM : BaseViewModel
    {
        private readonly APIService _clanteretana = new APIService("ClanTeretana");
        private readonly APIService _placeneClanarine = new APIService("PlacanjeClanarine");
        public ClanarineVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<ClanTeretana> teretaneList { get; set; } = new ObservableCollection<ClanTeretana>();
        public ObservableCollection<PlacanjeClanarine> ClanarineList { get; set; } = new ObservableCollection<PlacanjeClanarine>();

        ClanTeretana _selectedTeretana = null;

        public ClanTeretana SelectedTeretana
        {
            get { return _selectedTeretana; }
            set
            {
                SetProperty(ref _selectedTeretana, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            if (teretaneList.Count == 0)
            {
                ClanTeretanaSearchRequest request = new ClanTeretanaSearchRequest();
                request.ClanId = Global.LogiraniClanId;
                var teretanelist = await _clanteretana.Get<List<ClanTeretana>>(request);


                ClanTeretana sveTeretane = new ClanTeretana();
                Teretana sveTer = new Teretana
                {
                    TeretanaId = 0,
                    Naziv = "Sve teretane"
                };
                sveTeretane.Teretana = sveTer;
                sveTeretane.ClanTeretanaId = 0;

                teretaneList.Clear();
                teretaneList.Add(sveTeretane);




                
                foreach (var teretana in teretanelist)
                {
                    teretaneList.Add(teretana);
                }
            }


            if (SelectedTeretana != null && SelectedTeretana.TeretanaId == 0)
            {
                PlacanjeClanarineSearchRequest search = new PlacanjeClanarineSearchRequest();
                search.ClanId = Global.LogiraniClanId;

                var list = await _placeneClanarine.Get<IEnumerable<PlacanjeClanarine>>(search);

                ClanarineList.Clear();
                foreach (var clanarina in list)
                {
                    ClanarineList.Add(clanarina);
                }
            }




            if (SelectedTeretana != null && SelectedTeretana.TeretanaId != 0)
            {
                PlacanjeClanarineSearchRequest search = new PlacanjeClanarineSearchRequest();
                search.TeretanaId = SelectedTeretana.TeretanaId;
                search.ClanId = Global.LogiraniClanId;

                var list = await _placeneClanarine.Get<IEnumerable<PlacanjeClanarine>>(search);

                ClanarineList.Clear();
                foreach (var clanarina in list)
                {
                    ClanarineList.Add(clanarina);
                }
            }
        }
    }
}
   
