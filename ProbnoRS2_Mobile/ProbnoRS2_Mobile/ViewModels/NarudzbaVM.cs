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
   public class NarudzbaVM:BaseViewModel
    {
        private readonly APIService _narudzbe = new APIService("Narudzba");
        private readonly APIService _stavke = new APIService("NarudzbaStavka");
        public NarudzbaVM()
        {
            InitCommand = new Command(async () => await Init());
            UkloniCommand = new Command(async () => await Ukloni(0));
        }
        public Narudzbe Narudzba { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand UkloniCommand { get; set; }
        public string Poruka { get; set; }
        public ObservableCollection<NarudzbeStavke> StavkeList { get; set; } = new ObservableCollection<NarudzbeStavke>();
        public async Task Init()
        {
            decimal Total = 0;
            NarudzbaSearchRequest request = new NarudzbaSearchRequest();
            if (Global.NarudzbaId != 0)
            {
                request.NarudzbaId = Global.NarudzbaId;
                var list = await _stavke.Get<IEnumerable<NarudzbeStavke>>(request);

                StavkeList.Clear();
                foreach (var stavka in list)
                {
                    Total += (decimal)stavka.Proizvod.Cijena;
                    StavkeList.Add(stavka);
                }

                if (StavkeList.Count > 0)
                {
                    Poruka = "";
                }
                else
                {
                    Poruka = "Vaša košarica je prazna!";
                }



            }
            else
            {
                Poruka = "Vaša košarica je prazna!";
            }
            Global.NarudzbaTotal = Total;
        }
        public async Task Ukloni(int stavkaId)
        {
            var id = stavkaId;

            bool obrisi= await _stavke.Delete(stavkaId);
        }
        public bool Provjera()
        {

            if (StavkeList.Count > 0)
                return true;
            return false;
         
        }

    }
}
