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

namespace OnlineGym_Desktop.Narudzbe
{
    public partial class frmNarudzbeDetalji : Form
    {
        private readonly APIService _narudzbestavke = new APIService("NarudzbaStavka");
        private readonly APIService _narudzbe = new APIService("Narudzba");
        private int? _id = null;
        public frmNarudzbeDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmNarudzbeDetalji_Load(object sender, EventArgs e)
        {
            var entity = await _narudzbe.GetById<OnlineGym_Model.Narudzbe>(_id);
            var result = await _narudzbestavke.Get<List<OnlineGym_Model.NarudzbeStavke>>(new NarudzbaStavkaSearchRequest()
            {
                NarudzbaId=_id
            });

            var dgvResult = new List<OnlineGym_Model.NarudzbeStavkeRezultat>();

            foreach (var cl in result)
            {
                NarudzbeStavkeRezultat temp = new NarudzbeStavkeRezultat(cl);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvDetalji.AutoGenerateColumns = false;
            dgvDetalji.DataSource = dgvResult;
            labelClan.Text = entity.Clan.Ime + " " + entity.Clan.Prezime;
            labID.Text = entity.NarudzbaId.ToString();
            if (entity.Procesirana == true)
            {
                labProcesirana.Text = "da";
            }
            else
            {
                labProcesirana.Text = "ne";
            }
           
            if (entity.Procesirana == false)
            {
                btnProcesiraj.Visible = true;
            }
           
        }

        private async void btnProcesiraj_Click(object sender, EventArgs e)
        {


            NarudzbaUpsertRequest request = new NarudzbaUpsertRequest();
            var entity1 = await _narudzbe.GetById<OnlineGym_Model.Narudzbe>(_id);
            request.KorisnikId = GlobalKorisnik.LogiraniKorisnikId;
            request.NarudzbaId = _id;
            request.ClanID = entity1.ClanId;
            request.Datum = entity1.Datum;
            request.Procesirana = true;
            request.BrojNarudzbe = entity1.BrojNarudzbe;
            OnlineGym_Model.Narudzbe entity = null;
            try
            {
                entity = await _narudzbe.Update<OnlineGym_Model.Narudzbe>(_id.Value, request);
                MessageBox.Show("Izmjene spašene!");
                this.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Greška!");
                return;
            }
        }
    }
}
