using OnlineGym_Desktop;
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
    public partial class frmTeretaneIndex : Form
    {
        private readonly APIService _teretane = new APIService("Teretana");
        private readonly APIService _gradovi = new APIService("Grad");
        public frmTeretaneIndex()
        {
            InitializeComponent();
        }
  private async Task LoadGradovi()
        {
            var result = await _gradovi.Get<List<OnlineGym_Model.Gradovi>>(null);
            Gradovi sviGradovi = new Gradovi();
            sviGradovi.GradId = 0;
            sviGradovi.Naziv = "Svi gradovi";
            result.Insert(0, sviGradovi);
            cmbTeretane.DisplayMember = "Naziv";
            cmbTeretane.ValueMember = "GradId";
            cmbTeretane.DataSource = result;
        }
        private async Task LoadTeretane(int gradId) 
        {
            if (gradId == 0)
            {
                await LoadTeretane();
            }
            else
            {
                var result = await _teretane.Get<List<OnlineGym_Model.Teretana>>(new TeretanaSearchRequest()
                {
                    GradId = gradId
                });
                var dgvResult = new List<OnlineGym_Model.Teretana_Rezultat>();

                foreach (var ter in result)
                {
                    Teretana_Rezultat temp = new Teretana_Rezultat(ter);
                    dgvResult.Add(temp);
                    temp = null;
                }
                dgvTeretanee.DataSource = dgvResult;
            }
        }

        private async void frmTeretaneIndex_Load(object sender, EventArgs e)
        {
            await LoadGradovi();
            await LoadTeretane();
        }
        private async Task LoadTeretane()
        {
            var result = await _teretane.Get<List<OnlineGym_Model.Teretana>>(null);
            var dgvResult = new List<OnlineGym_Model.Teretana_Rezultat>();

            foreach (var ter in result)
            {
                Teretana_Rezultat temp = new Teretana_Rezultat(ter);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvTeretanee.AutoGenerateColumns = false;
            dgvTeretanee.DataSource = dgvResult;

        }
        private async void cmbTeretane_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbTeretane.SelectedValue;

              if (int.TryParse(idObj.ToString(), out int id))
               {
                    await LoadTeretane(id);
               }
        }

        private void btnDodajTeretanu_Click(object sender, EventArgs e)
        {
            frmDodajTeretanu frm = new frmDodajTeretanu();
            frm.Show();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new TeretanaSearchRequest()
            {
                Naziv = txtPretragaNaziv.Text
            };

            var list = await _teretane.Get<List<OnlineGym_Model.Teretana>>(search);
            var dgvResult = new List<OnlineGym_Model.Teretana_Rezultat>();

            foreach (var ter in list)
            {
                Teretana_Rezultat temp = new Teretana_Rezultat(ter);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvTeretanee.DataSource = dgvResult;
        }

        private void dgvTeretanee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var teretanaId = int.Parse(dgvTeretanee.SelectedRows[0].Cells[0].Value.ToString());

            frmTeretanaUredi frm = new frmTeretanaUredi(teretanaId);
            frm.Show();
        }
        private void btnUrediTeretanu_Click(object sender, EventArgs e)
        {
            

                if (dgvTeretanee.SelectedRows.Count == 0 || Convert.ToInt32(dgvTeretanee.SelectedRows[0].Cells[0].Value) == 0)
                {
                    MessageBox.Show("Greška! Niste odabrali teretanu koju želite urediti!");
                }
                else
                {
                    frmTeretanaUredi frm = new frmTeretanaUredi(Convert.ToInt32(dgvTeretanee.SelectedRows[0].Cells[0].Value));

                frm.Show();

                }  
           
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            frm_TeretaneIzvjestaj frm = new frm_TeretaneIzvjestaj();
            frm.Show();
        }

        private void btnClanarine_Click(object sender, EventArgs e)
        {
            if (dgvTeretanee.SelectedRows.Count == 0 || Convert.ToInt32(dgvTeretanee.SelectedRows[0].Cells[0].Value)==0)
            {
                MessageBox.Show("Greška! Niste odabrali teretanu za koju želite vidjeti uplaćene članarine!");
            }
            else
            {
                frmTeretaneUplate frm = new frmTeretaneUplate(Convert.ToInt32(dgvTeretanee.SelectedRows[0].Cells[0].Value));

                frm.Show();

            }
        }
    }
}
