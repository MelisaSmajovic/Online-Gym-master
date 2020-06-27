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

namespace OnlineGym_Desktop.Korisnici
{
    public partial class frm_Korisnici : Form
    {
        APIService _korisnici = new APIService("Korisnici");
        public frm_Korisnici()
        {
            InitializeComponent();
        }
        private async void frm_Korisnici_Load(object sender, EventArgs e)
        {
            await LoadKorisnici();
        }
        private async Task LoadKorisnici()
        {
            var result = await _korisnici.Get<List<OnlineGym_Model.Korisnik>>(null);

            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = result;

        }
        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await Prikazi();
        }
        private async Task Prikazi()
        {
            var search = new KorisniciSearchRequest()
            {
                Ime = txtPretragaIme.Text
      
            };

            var list = await _korisnici.Get<List<OnlineGym_Model.Korisnik>>(search);
            dgvKorisnici.AutoGenerateColumns = false;

            dgvKorisnici.DataSource = list;
        }

        private void dgvKorisnici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var korisnikId = int.Parse(dgvKorisnici.SelectedRows[0].Cells[0].Value.ToString());

            frm_KorisnikDetalji frm = new frm_KorisnikDetalji(korisnikId);
            frm.Show();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.SelectedRows.Count == 0 || Convert.ToInt32(dgvKorisnici.SelectedRows[0].Cells[0].Value) == 0)
            {
                MessageBox.Show("Greška! Niste odabrali korisnika!");
            }
            else
            {
                frm_KorisnikDetalji frm = new frm_KorisnikDetalji(Convert.ToInt32(dgvKorisnici.SelectedRows[0].Cells[0].Value));

                frm.Show();

            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmKorisnikDodaj frm = new frmKorisnikDodaj();
            frm.Show();
        }
    }
}
