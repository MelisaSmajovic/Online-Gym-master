using OnlineGym_Model;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineGym_Desktop.Clanovi
{
    public partial class frmClanDetalji : Form
    {
        private int _id;
        private readonly APIService _clanovi = new APIService("Clan");
        private readonly APIService _teretane = new APIService("Teretana");
        private readonly APIService _clanteretana = new APIService("ClanTeretana");
        private readonly APIService _placanjeClanarine = new APIService("PlacanjeClanarine");
        private readonly APIService _tipoviClanarine = new APIService("TipClanarine");
        private readonly APIService _narudzbe = new APIService("Narudzba");
        private readonly APIService _narudzbeStavke = new APIService("NarudzbaStavka");
        private readonly APIService _kategorijeProizvoda = new APIService("KategorijeProizvoda");
        public frmClanDetalji(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmClanDetalji_Load(object sender, EventArgs e)
        {
                var entity = await _clanovi.GetById<OnlineGym_Model.Clan>(_id);
                txtIme.Text = entity.Ime;
                txtPrezime.Text = entity.Prezime;
                txtEmail.Text = entity.Email;
                txtKorisnickoIme.Text = entity.KorisnickoIme;
                txtDatum.Text = entity.DatumRegistracije.ToString("dd.MM.yyyy");

            LoadTipoviClanarine();
            LoadKategorijeProizvoda();
            LoadTeretane();
            LoadClanarine(0);
            LoadProizvodi(0);
        }

        private async Task LoadTipoviClanarine()
        {
            var result = await _tipoviClanarine.Get<List<OnlineGym_Model.TipClanarine>>(null);
            TipClanarine sveClanarine = new TipClanarine();
            sveClanarine.TipClanarineId = 0;
            sveClanarine.Tip = "Svi tipovi";
            result.Insert(0, sveClanarine);
            cmbTipClanarine.DisplayMember = "Tip";
            cmbTipClanarine.ValueMember = "TipClanarineId";
            cmbTipClanarine.DataSource = result;
        }
        private async Task LoadKategorijeProizvoda()
        {
            var result = await _kategorijeProizvoda.Get<List<OnlineGym_Model.KategorijeProizvoda>>(null);
            KategorijeProizvoda sveKategorije = new KategorijeProizvoda();
            sveKategorije.KategorijaProizvodaId = 0;
            sveKategorije.Naziv = "Sve kategorije";
            result.Insert(0, sveKategorije);
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "KategorijaProizvodaId";
            cmbKategorije.DataSource = result;
        }
        private async void LoadTeretane()
        {
            dgvTeretane.AutoGenerateColumns = false;
            var result = await _clanteretana.Get<List<OnlineGym_Model.ClanTeretana>>(new ClanTeretanaSearchRequest()
            {
                ClanId = _id
            });
            var dgvResult = new List<OnlineGym_Model.ClanTeretanaRezultat>();

            foreach (var ter in result)
            {
                ClanTeretanaRezultat temp = new ClanTeretanaRezultat(ter);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvTeretane.DataSource = dgvResult;
            
        }

        private async Task LoadClanarine(int tipId)
        {
            if (tipId != 0)
            {
                var result = await _placanjeClanarine.Get<List<OnlineGym_Model.PlacanjeClanarine>>(new PlacanjeClanarineSearchRequest()
                {
                    ClanId = _id,
                    TipClanarineId = tipId
                });

                var dgvResult = new List<OnlineGym_Model.PlacanjeClanarineRezultat>();

                foreach (var cl in result)
                {
                    PlacanjeClanarineRezultat temp = new PlacanjeClanarineRezultat(cl);
                    dgvResult.Add(temp);
                    temp = null;
                }
                dgvClanarine.AutoGenerateColumns = false;
                dgvClanarine.DataSource = dgvResult;

            }
            else
            {
                var result = await _placanjeClanarine.Get<List<OnlineGym_Model.PlacanjeClanarine>>(new PlacanjeClanarineSearchRequest()
                {
                    ClanId = _id
                    
                });
                var dgvResult = new List<OnlineGym_Model.PlacanjeClanarineRezultat>();

                foreach (var cl in result)
                {
                    PlacanjeClanarineRezultat temp = new PlacanjeClanarineRezultat(cl);
                    dgvResult.Add(temp);
                    temp = null;
                }
                dgvClanarine.AutoGenerateColumns = false;
                dgvClanarine.DataSource = dgvResult;
            }
        }
        private async Task LoadProizvodi(int tipId) {
            var NarudzbeStavkeList = new List<OnlineGym_Model.NarudzbeStavke>();
            var NarudzbeList = new List<OnlineGym_Model.Narudzbe>();
            if (tipId == 0) { 
            NarudzbaSearchRequest search = new NarudzbaSearchRequest();
            search.ClanId =_id;

            var list = await _narudzbe.Get<IEnumerable<OnlineGym_Model.Narudzbe>>(search);
            foreach (var narudzba in list)
            {
                NarudzbeList.Add(narudzba);
            }

                if (NarudzbeList.Count > 0)
                {
                    for (int i = 0; i < NarudzbeList.Count; i++)
                    {
                        NarudzbaStavkaSearchRequest request = new NarudzbaStavkaSearchRequest();
                        request.NarudzbaId = NarudzbeList[i].NarudzbaId;

                        var stavkeList = await _narudzbeStavke.Get<IEnumerable<NarudzbeStavke>>(request);
                        foreach (var stavka in stavkeList)
                        {
                            NarudzbeStavkeList.Add(stavka);
                        }
                    }

                    var dgvResult = new List<OnlineGym_Model.NarudzbeStavkeRezultat>();

                    foreach (var cl in NarudzbeStavkeList)
                    {
                        NarudzbeStavkeRezultat temp = new NarudzbeStavkeRezultat(cl);
                        dgvResult.Add(temp);
                        temp = null;
                    }
                    dgvProizvodi.AutoGenerateColumns = false;
                    dgvProizvodi.DataSource = dgvResult;

                }

            }
            else
            {
                NarudzbaSearchRequest search = new NarudzbaSearchRequest();
                search.ClanId = _id;
       
                var list = await _narudzbe.Get<IEnumerable<OnlineGym_Model.Narudzbe>>(search);
                foreach (var narudzba in list)
                {
                    NarudzbeList.Add(narudzba);
                }


                if (NarudzbeList.Count > 0)
                {
                    for (int i = 0; i < NarudzbeList.Count; i++)
                    {
                        NarudzbaStavkaSearchRequest request = new NarudzbaStavkaSearchRequest();
                        request.NarudzbaId = NarudzbeList[i].NarudzbaId;
                        request.KategorijaId = tipId;
                        var stavkeList = await _narudzbeStavke.Get<IEnumerable<NarudzbeStavke>>(request);
                        foreach (var stavka in stavkeList)
                        {
                            NarudzbeStavkeList.Add(stavka);
                        }
                    }

                    var dgvResult = new List<OnlineGym_Model.NarudzbeStavkeRezultat>();

                    foreach (var cl in NarudzbeStavkeList)
                    {
                        NarudzbeStavkeRezultat temp = new NarudzbeStavkeRezultat(cl);
                        dgvResult.Add(temp);
                        temp = null;
                    }
                    dgvProizvodi.AutoGenerateColumns = false;
                    dgvProizvodi.DataSource = dgvResult;

                }

            }

        }
        private async void cmbTipClanarine_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbTipClanarine.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadClanarine(id);
            }
        }

        private async void cmbKategorije_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbKategorije.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadProizvodi(id);
            }
        }
    }
}
