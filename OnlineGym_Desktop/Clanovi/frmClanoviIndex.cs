using OnlineGym_Desktop;
using OnlineGym_Desktop.Clanovi;
using OnlineGym_Model;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineGym_Desktop.Clanovi
{
    public partial class frmClanoviIndex : Form
    {
        private readonly APIService _clanovi = new APIService("Clan");
        public frmClanoviIndex()
        {
            InitializeComponent();
        }
        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new ClanSearchRequest()
            {
                Ime = txtPretragaIme.Text
            };

            var list = await _clanovi.Get<List<OnlineGym_Model.Clan>>(search);
            var dgvResult = new List<OnlineGym_Model.ClanRezultat>();

            foreach (var cl in list)
            {
                ClanRezultat temp = new ClanRezultat(cl);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvClanovi.AutoGenerateColumns = false;

            dgvClanovi.DataSource = dgvResult;
        }              
    
       private void dgvClanovi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var clanId = int.Parse(dgvClanovi.SelectedRows[0].Cells[0].Value.ToString());

             frmClanDetalji frm = new frmClanDetalji(clanId);
             frm.Show();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (dgvClanovi.SelectedRows.Count == 0 || Convert.ToInt32(dgvClanovi.SelectedRows[0].Cells[0].Value) == 0)
            {
                MessageBox.Show("Greška! Niste odabrali clana!");
            }
            else
            {
                frmClanDetalji frm = new frmClanDetalji(Convert.ToInt32(dgvClanovi.SelectedRows[0].Cells[0].Value));

                frm.Show();

            }
        }
        private async Task LoadClanovi()
        {
            var result = await _clanovi.Get<List<OnlineGym_Model.Clan>>(null);
            var dgvResult = new List<OnlineGym_Model.ClanRezultat>();

            foreach (var cl in result)
            {
                ClanRezultat temp = new ClanRezultat(cl);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvClanovi.AutoGenerateColumns = false;
            dgvClanovi.DataSource = dgvResult;

        }

        private async void frmClanoviIndex_Load_1(object sender, EventArgs e)
        {
            await LoadClanovi();
        }
    }
}
