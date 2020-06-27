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
public class PlatiClanarinuVM:BaseViewModel
    {

        private readonly APIService _tipoviClanarine = new APIService("TipClanarine");
        private readonly APIService _clanteretana = new APIService("ClanTeretana");
        private readonly APIService _uplateClanarine = new APIService("PlacanjeClanarine");
        public PlatiClanarinuVM()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ObservableCollection<TipClanarine> tipoviClanarineList { get; set; } = new ObservableCollection<TipClanarine>();
        public ObservableCollection<ClanTeretana> teretaneList { get; set; } = new ObservableCollection<ClanTeretana>();
        TipClanarine _selectedTip = null;
        ClanTeretana _selectedTeretana = null;
        public TipClanarine SelectedTip
        {
            get { return _selectedTip; }
            set
            {
                SetProperty(ref _selectedTip, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }
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
            if (tipoviClanarineList.Count == 0)
            {
                var tipoviList = await _tipoviClanarine.Get<List<TipClanarine>>(null);

                foreach (var tip in tipoviList)
                {
                    tipoviClanarineList.Add(tip);
                }
            }
            if (teretaneList.Count == 0)
            {
                ClanTeretanaSearchRequest request = new ClanTeretanaSearchRequest();
                request.ClanId = Global.LogiraniClanId;
                var teretanelist = await _clanteretana.Get<List<ClanTeretana>>(request);

                teretaneList.Clear();
                foreach (var teretana in teretanelist)
                {
                    teretaneList.Add(teretana);
                }
            }
        }

        public async Task PlatiSnimi()
        {
            try
            {
                var request = new PlacanjeClanarineUpsertRequest
                {
                    ClanId = Global.LogiraniClanId,
                    TeretanaId = SelectedTeretana.TeretanaId,
                    TipClanarineId=SelectedTip.TipClanarineId,
                    DatumUplate=DateTime.Now,
                    UkupanIznos=SelectedTip.Cijena

                };

         
                PlacanjeClanarine entity = null;
                entity = await _uplateClanarine.Insert<PlacanjeClanarine>(request);
          
            }

            catch (Exception e)
            {
                string x = "";
            }
        }
    }
}
