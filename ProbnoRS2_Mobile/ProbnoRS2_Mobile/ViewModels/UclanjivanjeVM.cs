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
    public class UclanjivanjeVM : BaseViewModel
    {
        private readonly APIService _tipoviClanarine = new APIService("TipClanarine");
        private readonly APIService _clanteretana = new APIService("ClanTeretana");
        private readonly APIService _uplateClanarine = new APIService("PlacanjeClanarine");
        public int TeretanaId { get; set; }
        public UclanjivanjeVM()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ObservableCollection<TipClanarine> tipoviClanarineList { get; set; } = new ObservableCollection<TipClanarine>();
        TipClanarine _selectedTip = null;
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
        }

        public async Task UclaniSnimi()
        {
            try
            {
                var request = new ClanTeretanaUpsertRequest
                {
                    ClanId = Global.LogiraniClanId,
                    TeretanaId = TeretanaId,
                    DatumUclanjivanja = DateTime.Now

                };
                ClanTeretana entity = null;
                entity = await _clanteretana.Insert<ClanTeretana>(request);
                var clanarinaRequest = new PlacanjeClanarineUpsertRequest
                {
                    ClanId = Global.LogiraniClanId,
                    TeretanaId = TeretanaId,
                    DatumUplate = DateTime.Now,
                    TipClanarineId = _selectedTip.TipClanarineId,
                    UkupanIznos = _selectedTip.Cijena
                };
                PlacanjeClanarine entity2 = null;
                entity2 = await _uplateClanarine.Insert<PlacanjeClanarine>(clanarinaRequest);
            }

            catch (Exception e)
            {
                string x = "";
            }
            
        }
    }
}
    
