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
    public class ProizvodiVM : BaseViewModel
    {
        private readonly APIService _proizvodi = new APIService("Proizvod");
        private readonly APIService _kategorijeProizvoda = new APIService("KategorijeProizvoda");
        private readonly APIService _vrsteProizvoda = new APIService("VrsteProizvoda");

        public ProizvodiVM()
        {
            InitCommand = new Command(async () => await Init());
            PretragaCommand = new Command(async () => await PretragaPoNazivu());
        }


        string _vrstaProizvoda = string.Empty;
        public string VrstaProizvoda
        {
            get { return _vrstaProizvoda; }
            set { SetProperty(ref _vrstaProizvoda, value); }
        }


        string _nazivProizvoda = string.Empty;
        public string NazivProizvoda
        {
            get { return _nazivProizvoda; }
            set { SetProperty(ref _nazivProizvoda, value); }
        }
        public ObservableCollection<Proizvod> ProizvodiList { get; set; } = new ObservableCollection<Proizvod>();
        public ObservableCollection<KategorijeProizvoda> KategorijeProizvodaList { get; set; } = new ObservableCollection<KategorijeProizvoda>();
        KategorijeProizvoda _selectedKategorijaProizvoda = null;

        public KategorijeProizvoda SelectedKategorijaProizvoda
        {
            get { return _selectedKategorijaProizvoda; }
            set
            {
                SetProperty(ref _selectedKategorijaProizvoda, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }

        bool _selectedIshrana = false;

        public bool SelectedIshrana
        {
            get { return _selectedIshrana; }
            set
            {
                SetProperty(ref _selectedIshrana, value);
                if (value != false)
                {
                    PretragaCommand.Execute(null);
                }

            }
        }


        bool _selectedTrening = false;

        public bool SelectedTrening
        {
            get { return _selectedTrening; }
            set
            {
                SetProperty(ref _selectedTrening, value);
                if (value != false)
                {
                    PretragaCommand.Execute(null);
                }

            }
        }
        public ICommand InitCommand { get; set; }
        public ICommand PretragaCommand { get; set; }

        public async Task Init()
        {
            if (KategorijeProizvodaList.Count == 0)
            {
                var kategorijeProizvodaList = await _kategorijeProizvoda.Get<List<KategorijeProizvoda>>(null);
                KategorijeProizvoda sveKategorije = new KategorijeProizvoda();
                sveKategorije.Naziv = "Sve kategorije";
                sveKategorije.KategorijaProizvodaId = 0;
                kategorijeProizvodaList.Add(sveKategorije);
                foreach (var kategorijaProizvoda in kategorijeProizvodaList)
                {
                    KategorijeProizvodaList.Add(kategorijaProizvoda);
                }
            }

            if (SelectedKategorijaProizvoda != null)
            {
                if (SelectedKategorijaProizvoda.KategorijaProizvodaId == 0)
                {
                    var list = await _proizvodi.Get<IEnumerable<Proizvod>>(null);

                    ProizvodiList.Clear();
                    foreach (var proizvod in list)
                    {
                        ProizvodiList.Add(proizvod);
                    }
                }
                else
                {
                    ProizvodSearchRequest search = new ProizvodSearchRequest();
                    search.KategorijaProizvodaId = SelectedKategorijaProizvoda.KategorijaProizvodaId;

                    var list = await _proizvodi.Get<IEnumerable<Proizvod>>(search);

                    ProizvodiList.Clear();
                    foreach (var proizvod in list)
                    {
                        ProizvodiList.Add(proizvod);
                    }
                    SelectedIshrana = false;
                    SelectedTrening = false;
                }

            }
            else
            {

                var list = await _proizvodi.Get<IEnumerable<Proizvod>>(null);

                ProizvodiList.Clear();
                foreach (var proizvod in list)
                {
                    ProizvodiList.Add(proizvod);
                }
            }


        }
        public async Task PretragaPoNazivu()
        {
            if (NazivProizvoda != string.Empty || SelectedIshrana != false || SelectedTrening != false)
            {
                ProizvodSearchRequest search = new ProizvodSearchRequest();
                if (NazivProizvoda != string.Empty)
                {
                    search.Naziv = NazivProizvoda;
                }
                if ((SelectedIshrana == true && SelectedTrening == false) || (SelectedTrening == true && SelectedIshrana == false))
                {
                    if (SelectedIshrana == true)
                    {
                        search.VrstaProizvodaId = 1;
                    }
                    if (SelectedTrening == true)
                    {
                        search.VrstaProizvodaId = 2;
                    }
                    var list = await _proizvodi.Get<IEnumerable<Proizvod>>(search);

                    ProizvodiList.Clear();
                    foreach (var proizvod in list)
                    {
                        ProizvodiList.Add(proizvod);
                    }
                }
            else
            {
                   
                    if (NazivProizvoda != string.Empty)
                    {
                        var lista = await _proizvodi.Get<IEnumerable<Proizvod>>(search);
                        ProizvodiList.Clear();
                        foreach (var proizvod in lista)
                        {
                            ProizvodiList.Add(proizvod);
                        }
                    }
                    else
                    {
                        var lista= await _proizvodi.Get<IEnumerable<Proizvod>>(null);
                        ProizvodiList.Clear();
                        foreach (var proizvod in lista)
                        {
                            ProizvodiList.Add(proizvod);
                        }
                    }  
            }
           
            }

            else
            {
                var list = await _proizvodi.Get<IEnumerable<Proizvod>>(null);

                ProizvodiList.Clear();
                foreach (var proizvod in list)
                {
                    ProizvodiList.Add(proizvod);
                }
            }

        } }

        }
    
    
