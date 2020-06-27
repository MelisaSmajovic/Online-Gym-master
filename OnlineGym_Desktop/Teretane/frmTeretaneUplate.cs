using OnlineGym_Desktop.Izvjestaji;
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

namespace OnlineGym_Desktop.Teretane
{
    public partial class frmTeretaneUplate : Form
    {
        DateTime date = DateTime.Now;
        private int _id;
        public int Mjesec = 0;
        public int Godina = 0;
        public int ClanID = 0;
        private readonly APIService _uplate = new APIService("PlacanjeClanarine");
        private readonly APIService _clanovi = new APIService("ClanTeretana");
        private readonly APIService _clanId = new APIService("Clan");
        public frmTeretaneUplate(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmTeretaneUplate_Load(object sender, EventArgs e)
        {
            await LoadClanovi();
            OrderDatePicker.Format = DateTimePickerFormat.Custom;
            OrderDatePicker.CustomFormat= "MMMM";
            OrderDatePicker.ShowUpDown = true;

            dtpGodina.Format = DateTimePickerFormat.Custom;
            dtpGodina.CustomFormat = "yyyy";
            dtpGodina.ShowUpDown = true;
            dgvUplate.AutoGenerateColumns = false;
            BindGrid();
        }
        private async Task LoadClanovi()
        {
            ClanTeretanaSearchRequest request = new ClanTeretanaSearchRequest();
            request.TeretanaId = _id;
            var result = await _clanovi.Get<List<OnlineGym_Model.ClanTeretana>>(request);
            //string ime = result[0].Clan.Ime;


            var dgvResult = new List<OnlineGym_Model.ClanTeretanaRezultat>();

            foreach (var ter in result)
            {
                ClanTeretanaRezultat temp = new ClanTeretanaRezultat(ter);
                dgvResult.Add(temp);
                temp = null;
            }

            ClanTeretana sviClanovi = new ClanTeretana();
            Clan sviClanoviNaziv = new Clan();
            sviClanoviNaziv.Ime = "Svi";
            sviClanoviNaziv.Prezime = " članovi";
            sviClanovi.ClanId = 0;
            sviClanovi.Clan = sviClanoviNaziv;

            ClanTeretanaRezultat sviClanoviRezultat = new ClanTeretanaRezultat(sviClanovi);

            dgvResult.Insert(0, sviClanoviRezultat);
            cmbClanovi.DisplayMember = "Clan";
            cmbClanovi.ValueMember = "ClanId";
            cmbClanovi.DataSource = dgvResult;
        }
        private async Task LoadUplate(int clanID)
        {
            if (clanID != 0)
            {
                var result = await _uplate.Get<List<OnlineGym_Model.PlacanjeClanarine>>(new PlacanjeClanarineSearchRequest()
                {
                    TeretanaId = _id,
                    ClanId = clanID
                });
                var dgvResult = new List<OnlineGym_Model.PlacanjeClanarineRezultat>();

                foreach (var u in result)
                {
                    PlacanjeClanarineRezultat temp = new PlacanjeClanarineRezultat(u);
                    dgvResult.Add(temp);
                    temp = null;
                }
                dgvUplate.AutoGenerateColumns = false;
                dgvUplate.DataSource = dgvResult;
            }
            else
            {
                var result = await _uplate.Get<List<OnlineGym_Model.PlacanjeClanarine>>(new PlacanjeClanarineSearchRequest()
                {
                    TeretanaId = _id
                });
                var dgvResult = new List<OnlineGym_Model.PlacanjeClanarineRezultat>();

                foreach (var u in result)
                {
                    PlacanjeClanarineRezultat temp = new PlacanjeClanarineRezultat(u);
                    dgvResult.Add(temp);
                    temp = null;
                }
                dgvUplate.AutoGenerateColumns = false;
                dgvUplate.DataSource = dgvResult;
            }
          
         
        }
        private async void cmbClanovi_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                var idObj = cmbClanovi.SelectedValue;

                if (int.TryParse(idObj.ToString(), out int id))
                {
                    await LoadUplate(id);
                }
            ClanID = id;
            
        }

        private async void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            if (ClanID != 0)
            {
                Clan odabraniClan = await _clanId.GetById<Clan>(ClanID);
                frm_TeretaneUplate frm = new frm_TeretaneUplate(odabraniClan,_id,Mjesec,Godina);
                frm.Show();
            }
            else
            {
                frm_TeretaneUplate frm = new frm_TeretaneUplate(null, _id, Mjesec, Godina);
                frm.Show();
            }
        }
        private async void BindGrid()
        {
           
            var result = await _uplate.Get<List<OnlineGym_Model.PlacanjeClanarine>>(new PlacanjeClanarineSearchRequest()
            {
                MjesecUplate = Mjesec,
                GodinaUplate=Godina,
                TeretanaId=_id
            });
            var dgvResult = new List<OnlineGym_Model.PlacanjeClanarineRezultat>();

            foreach (var u in result)
            {
                PlacanjeClanarineRezultat temp = new PlacanjeClanarineRezultat(u);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvUplate.AutoGenerateColumns = false;
            dgvUplate.DataSource = dgvResult;
    
        }
        private void OrderDatePicker_ValueChanged(object sender, EventArgs e)
        {
            Mjesec = OrderDatePicker.Value.Month;
            BindGrid();
           
        }

        private void dtpGodina_ValueChanged(object sender, EventArgs e)
        {
            Godina = dtpGodina.Value.Year;
            BindGrid();
 
        }
        private void btnSviDatumi_Click(object sender, EventArgs e)
        {
            Godina = 0;
            Mjesec = 0;
            BindGrid();
        }
    }
}
