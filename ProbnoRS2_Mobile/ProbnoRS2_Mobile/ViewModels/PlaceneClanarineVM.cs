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
   public class PlaceneClanarineVM:BaseViewModel
    {
        private readonly APIService _placeneClanarine = new APIService("PlacanjeClanarine");
        private readonly APIService _teretane = new APIService("Teretana");

        public Teretana Teretanaa { get; set; }
        public int TeretanaId { get; set; }
        public PlaceneClanarineVM()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ObservableCollection<PlacanjeClanarine> ClanarineList { get; set; } = new ObservableCollection<PlacanjeClanarine>();
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            Teretanaa = await _teretane.GetById<Teretana>(TeretanaId);
            PlacanjeClanarineSearchRequest search = new PlacanjeClanarineSearchRequest();
            search.ClanId = Global.LogiraniClanId;
            search.TeretanaId = TeretanaId;

            var list = await _placeneClanarine.Get<IEnumerable<PlacanjeClanarine>>(search);

            ClanarineList.Clear();
            foreach (var uplata in list)
            {
                ClanarineList.Add(uplata);
            }



        }
    }
}
