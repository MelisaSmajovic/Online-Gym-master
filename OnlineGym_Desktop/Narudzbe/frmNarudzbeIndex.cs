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
    public partial class frmNarudzbeIndex : Form
    {
        private readonly APIService _narudzbe = new APIService("Narudzba");
        DateTime date = DateTime.Now;
        public frmNarudzbeIndex()
        {
            InitializeComponent();
            dgvNarudzbe.AutoGenerateColumns = false;
        }

        private async void frmNarudzbeIndex_Load(object sender, EventArgs e)
        {
            await LoadNarudzbe();
        }
        private async Task LoadNarudzbe()
        {
            var result = await _narudzbe.Get<List<OnlineGym_Model.Narudzbe>>(null);
            var dgvResult = new List<OnlineGym_Model.NarudzbeRezultat>();

            foreach (var nar in result)
            {
                NarudzbeRezultat temp = new NarudzbeRezultat(nar);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvNarudzbe.AutoGenerateColumns = false;
            dgvNarudzbe.DataSource = dgvResult;

        }
        private void OrderDatePicker_ValueChanged(object sender, EventArgs e)
        {
            BindGrid(OrderDatePicker.Value);
        }
        private async void BindGrid(DateTime value)
        {
            date = value;
            var result = await _narudzbe.Get<List<OnlineGym_Model.Narudzbe>>(new NarudzbaSearchRequest()
            {
                Datum = date
            });
            var dgvResult = new List<OnlineGym_Model.NarudzbeRezultat>();

            foreach (var nar in result)
            {
                NarudzbeRezultat temp = new NarudzbeRezultat(nar);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvNarudzbe.DataSource = dgvResult;
        }

        private async void btnDanas_Click(object sender, EventArgs e)
        {
            await LoadNarudzbe();
            
        }

        private async void rbProcesirana_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProcesirana.Checked == true)
            {
                rbNeprocesirana.Checked = false;
            }
            var result = await _narudzbe.Get<List<OnlineGym_Model.Narudzbe>>(new NarudzbaSearchRequest()
            {
                Procesirana = true
            });
            var dgvResult = new List<OnlineGym_Model.NarudzbeRezultat>();

            foreach (var nar in result)
            {
                NarudzbeRezultat temp = new NarudzbeRezultat(nar);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvNarudzbe.DataSource = dgvResult;
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (dgvNarudzbe.SelectedRows.Count == 0 || Convert.ToInt32(dgvNarudzbe.SelectedRows[0].Cells[0].Value) == 0)
            {
                MessageBox.Show("Greška! Niste odabrali narudzbu!");
            }
            else
            {
                frmNarudzbeDetalji frm = new frmNarudzbeDetalji(Convert.ToInt32(dgvNarudzbe.SelectedRows[0].Cells[0].Value));

                frm.Show();

            }
        }

        private async void rbNeprocesirana_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbNeprocesirana.Checked == true)
            {
                rbProcesirana.Checked = false;
            }
            var result = await _narudzbe.Get<List<OnlineGym_Model.Narudzbe>>(new NarudzbaSearchRequest()
            {
                Procesirana = false
            });

            var dgvResult = new List<OnlineGym_Model.NarudzbeRezultat>();

            foreach (var nar in result)
            {
                NarudzbeRezultat temp = new NarudzbeRezultat(nar);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvNarudzbe.DataSource = dgvResult;
        }    
    }
}
