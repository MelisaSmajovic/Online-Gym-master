using OnlineGym_Model;
using OnlineGym_Model.Requests;
using ProbnoRS2_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProbnoRS2_Mobile.ViewModels
{
    public class TeretaneDetaljiVM:BaseViewModel
    {

        private readonly APIService _recenzije = new APIService("RecenzijeTeretane");
        private readonly APIService _preporuke = new APIService("SistemPreporukeTeretane/GetPreporukaByTeretana");
        public Teretana Teretana { get; set; }
        public TeretaneDetaljiVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<RecenzijeTeretane> RecenzijeList { get; set; } = new ObservableCollection<RecenzijeTeretane>();
        public ObservableCollection<Teretana> PreporukeList { get; set; } = new ObservableCollection<Teretana>();
        public List<GalerijaModel> TeretanaSlike { get; set; } = new List<GalerijaModel>();
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {

            GalerijaModel slika1 = new GalerijaModel
            {
                Naslov = "Slika 1",
                SlikaThumb = Teretana.Slika1
            };
            TeretanaSlike.Add(slika1);

            GalerijaModel slika2 = new GalerijaModel
            {
                Naslov = "Slika 2",
                SlikaThumb = Teretana.Slika2
            };
            TeretanaSlike.Add(slika2);
            GalerijaModel slika3 = new GalerijaModel
            {
                Naslov = "Slika 3",
                SlikaThumb = Teretana.Slika3
            };
            TeretanaSlike.Add(slika3);
            GalerijaModel slika4 = new GalerijaModel
            {
                Naslov = "Slika 4",
                SlikaThumb = Teretana.Slika4
            };
            TeretanaSlike.Add(slika4);
            GalerijaModel slika5 = new GalerijaModel
            {
                Naslov = "Slika 5",
                SlikaThumb = Teretana.Slika5
            };
            TeretanaSlike.Add(slika5);


            RecenzijeTeretaneSearchRequest search = new RecenzijeTeretaneSearchRequest();
            search.TeretanaId = Teretana.TeretanaId;

            var list = await _recenzije.Get<IEnumerable<RecenzijeTeretane>>(search);

            RecenzijeList.Clear();
            foreach (var recenzija in list)
            {
                RecenzijeList.Add(recenzija);
            }
            Teretana request = new Teretana();
            request.TeretanaId = Teretana.TeretanaId;
            request.GradId = Teretana.GradId;
            var listPreporuke = await _preporuke.Get<IEnumerable<Teretana>>(request);
            PreporukeList.Clear();
            foreach (var preporuka in listPreporuke)
            {
                PreporukeList.Add(preporuka);
            }
        }
        }
    }
