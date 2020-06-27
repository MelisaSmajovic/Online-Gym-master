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
   public class TeretaneVM:BaseViewModel
    {
        private readonly APIService _teretane = new APIService("Teretana");
        private readonly APIService _gradovi = new APIService("Grad");

        public TeretaneVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        string _nazivTeretane = string.Empty;
        public string NazivTeretane
        {
            get { return _nazivTeretane; }
            set { SetProperty(ref _nazivTeretane, value); }
        }
        public ObservableCollection<Teretana> TeretaneList { get; set; } = new ObservableCollection<Teretana>();
        public ObservableCollection<Gradovi> GradoviList { get; set; } = new ObservableCollection<Gradovi>();
        Gradovi _selectedGrad = null;

        public Gradovi SelectedGrad
        {
            get { return _selectedGrad; }
            set
            {
                SetProperty(ref _selectedGrad, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }


        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if (GradoviList.Count == 0)
            {
                var gradovilist = await _gradovi.Get<List<Gradovi>>(null);

                Gradovi sviGradovi = new Gradovi();
                sviGradovi.Naziv = "Svi gradovi";
                sviGradovi.GradId = 0;
                GradoviList.Add(sviGradovi);



                foreach (var grad in gradovilist)
                {
                GradoviList.Add(grad);
                }
            }

            if (SelectedGrad != null)
            {
                if (SelectedGrad.GradId == 0)
                {
                    var list = await _teretane.Get<IEnumerable<Teretana>>(null);

                    TeretaneList.Clear();
                    foreach (var trt in list)
                    {
                        TeretaneList.Add(trt);
                    }
                }
                else {
                    TeretanaSearchRequest search = new TeretanaSearchRequest();
                    search.GradId = SelectedGrad.GradId;
                    if (NazivTeretane != null)
                        search.Naziv = NazivTeretane;

                    var list = await _teretane.Get<IEnumerable<Teretana>>(search);

                    TeretaneList.Clear();
                    foreach (var teretana in list)
                    {
                        TeretaneList.Add(teretana);
                    } }
            }
            else
            {

                var list = await _teretane.Get<IEnumerable<Teretana>>(null);

                TeretaneList.Clear();
                foreach (var teretana in list)
                {
                    TeretaneList.Add(teretana);
                }
            }


        }

        public async Task PretragaPoNazivu()
        {
            TeretanaSearchRequest search = new TeretanaSearchRequest();
            search.Naziv = NazivTeretane;
            var list = await _teretane.Get<IEnumerable<Teretana>>(search);

            TeretaneList.Clear();
            foreach (var teretana in list)
            {
                TeretaneList.Add(teretana);
            }

        }

    }
}
