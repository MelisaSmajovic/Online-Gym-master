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
    public class ProizvodDetaljiVM:BaseViewModel
    {
        private readonly APIService _recenzije = new APIService("RecenzijeProizvoda");
        private readonly APIService _preporuceniProizvodi = new APIService("SistemPreporukeProizvodi");
        public ProizvodDetaljiVM()
        {
            PovecajKolicinuCommand = new Command(() => Kolicina += 1);
            NaruciCommand = new Command(Naruci);
        }

        public Proizvod Proizvod { get; set; }
        public ObservableCollection<Proizvod> PreporuceniProizvodiList { get; set; } = new ObservableCollection<Proizvod>();
        public ObservableCollection<RecenzijeProizvoda> RecenzijeList { get; set; } = new ObservableCollection<RecenzijeProizvoda>();
        decimal _kolicina = 0;

        public decimal Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); }
        }
        public ICommand rattingBarCommand { get; set; }
        public ICommand clickCommand { get; set; }
        public ICommand PovecajKolicinuCommand { get; set; }

        public ICommand NaruciCommand { get; set; }

        private void Naruci()
        {
            if (CartService.Cart.ContainsKey(Proizvod.ProizvodId))
            {
                CartService.Cart.Remove(Proizvod.ProizvodId);
            }
            CartService.Cart.Add(Proizvod.ProizvodId, this);
        }


        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            Proizvod query = new Proizvod();
            query.ProizvodId = Proizvod.ProizvodId;
            query.VrstaProizvodaId = Proizvod.VrstaProizvodaId;
            query.KategorijaProizvodaId = Proizvod.KategorijaProizvodaId;
            var ProizvodiList = await _preporuceniProizvodi.Get<IEnumerable<Proizvod>>(query);
            PreporuceniProizvodiList.Clear();
            foreach (var proizvod in ProizvodiList)
            {    
                    PreporuceniProizvodiList.Add(proizvod);
            }

            //RecenzijeProizvodaSearchRequest search = new RecenzijeProizvodaSearchRequest();
            Proizvod proizvodTemp = new Proizvod();
            proizvodTemp.ProizvodId = Proizvod.ProizvodId;
            proizvodTemp.KategorijaProizvodaId = Proizvod.KategorijaProizvodaId;
            proizvodTemp.VrstaProizvodaId = Proizvod.VrstaProizvodaId;
            //search.ProizvodId = Proizvod.ProizvodId;

            var list = await _recenzije.Get<IEnumerable<RecenzijeProizvoda>>(proizvodTemp);
            int? suma = 0;
            int brojac = 0;
            RecenzijeList.Clear();
            foreach (var recenzija in list)
            {
                RecenzijeList.Add(recenzija);
                suma += recenzija.Ocjena;
                brojac++;
            }         

        }
    }
}
