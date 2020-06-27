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
    public class ObavijestiVM : BaseViewModel
    {
        private readonly APIService _obavijesti = new APIService("Obavijest");

        public ObavijestiVM()
        {
            InitCommand = new Command(async () => await Init());
            DatumCommand = new Command(async () => await CalcDatum(null));
        }
        public ObservableCollection<Obavijest> ObavijestiList { get; set; } = new ObservableCollection<Obavijest>();

        DateTime _datum;
        public DateTime Datum
        {
            get { return _datum; }
            set { SetProperty(ref _datum, value); }
        }

        public ICommand DatumCommand { get; set; }

        public ICommand InitCommand { get; set; }
        public DateTime maxDate = DateTime.Now;
        public DateTime Date = DateTime.Now;
        public async Task Init()
        {
            ObavijestSearchRequest search = new ObavijestSearchRequest();

            var list = await _obavijesti.Get<IEnumerable<Obavijest>>(null);

            ObavijestiList.Clear();
            foreach (var obavijest in list)
            {
                ObavijestiList.Add(obavijest);
            }

        }
        public async Task CalcDatum(DateTime? date)
        {
            ObavijestSearchRequest search = new ObavijestSearchRequest();
            search.DatumObjave = date;

            var list = await _obavijesti.Get<IEnumerable<Obavijest>>(search);

            ObavijestiList.Clear();
            foreach (var obavijest in list)
            {
              
                ObavijestiList.Add(obavijest);
            }

        }

    }
    }
