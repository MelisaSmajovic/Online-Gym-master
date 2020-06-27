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

namespace OnlineGym_Desktop.Proizvodi
{
    public partial class frmProizvodiIndex : Form
    {
        private readonly APIService _kategorijeProizvoda = new APIService("KategorijeProizvoda");
        private readonly APIService _proizvodi = new APIService("Proizvod");
        public frmProizvodiIndex()
        {
            InitializeComponent();
        }
        private async void frmProizvodiIndex_Load(object sender, EventArgs e)
        {
            await LoadKategorijeProizvoda();
      
            cbxIshrana.Checked = true;
            cbxTrening.Checked = true;
            await LoadProizvodi();

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
        private async Task LoadProizvodi()
        {
            var result = await _proizvodi.Get<List<OnlineGym_Model.Proizvod>>(null);
            var dgvResult = new List<OnlineGym_Model.Proizvod_Rezultat>();

            foreach (var pro in result)
            {
                Proizvod_Rezultat temp = new Proizvod_Rezultat(pro);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvProizvodi.AutoGenerateColumns = false;
            dgvProizvodi.DataSource = dgvResult;
           
        }
        private async Task LoadProizvodiByKategorija(int kategorijaId)
        {
            if (kategorijaId ==0)
            {
                await LoadProizvodi();
            }
            else {
                var result = await _proizvodi.Get<List<OnlineGym_Model.Proizvod>>(new ProizvodSearchRequest()
                {
                    KategorijaProizvodaId = kategorijaId
                });

                var dgvResult = new List<OnlineGym_Model.Proizvod_Rezultat>();

                foreach(var pro in result)
                {
                    Proizvod_Rezultat temp = new Proizvod_Rezultat(pro);
                    dgvResult.Add(temp);
                    temp = null;
                }

                dgvProizvodi.AutoGenerateColumns = false;
                dgvProizvodi.DataSource = dgvResult; }
        }
        private async void cmbKategorije_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbKategorije.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadProizvodiByKategorija(id);
            }
        }

        private void btnDodajProizvod_Click(object sender, EventArgs e)
        {
            frmProizvodDodaj frm = new frmProizvodDodaj();
            frm.Show();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new ProizvodSearchRequest()
            {
                Naziv = txtPretragaNaziv.Text
            };

            var list = await _proizvodi.Get<List<OnlineGym_Model.Proizvod>>(search);
            var dgvResult = new List<OnlineGym_Model.Proizvod_Rezultat>();

            foreach (var pro in list)
            {
                Proizvod_Rezultat temp = new Proizvod_Rezultat(pro);
                dgvResult.Add(temp);
                temp = null;
            }
            dgvProizvodi.AutoGenerateColumns = false;

            dgvProizvodi.DataSource = dgvResult;
        }

        private void dgvProizvodi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var proizvodId = int.Parse(dgvProizvodi.SelectedRows[0].Cells[0].Value.ToString());

             frmProizvodUredi frm = new frmProizvodUredi(proizvodId);
              frm.Show();
        }

        private void btnUrediProizvod_Click(object sender, EventArgs e)
        {
            if (dgvProizvodi.SelectedRows.Count == 0 || Convert.ToInt32(dgvProizvodi.SelectedRows[0].Cells[0].Value) == 0)
          {
               MessageBox.Show("Greška! Niste odabrali proizvod koji želite urediti!");
           }
         else
          {
              frmProizvodUredi frm = new frmProizvodUredi(Convert.ToInt32(dgvProizvodi.SelectedRows[0].Cells[0].Value));
                       frm.Show();

                }
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            frm_ProizvodiIzvjestaj izvjestaj = new frm_ProizvodiIzvjestaj();
            izvjestaj.Show();
        }

        private async void cbxTrening_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTrening.Checked == true && cbxIshrana.Checked == true)
            {
                await LoadProizvodi();
            }
            else if (cbxTrening.Checked == true && cbxIshrana.Checked == false)
            {

                var result = await _proizvodi.Get<List<OnlineGym_Model.Proizvod>>(new ProizvodSearchRequest()
                {
                    VrstaProizvodaId = 2
                });

                var dgvResult = new List<OnlineGym_Model.Proizvod_Rezultat>();

                foreach (var pro in result)
                {
                    Proizvod_Rezultat temp = new Proizvod_Rezultat(pro);
                    dgvResult.Add(temp);
                    temp = null;
                }

                dgvProizvodi.AutoGenerateColumns = false;
                dgvProizvodi.DataSource = dgvResult;
            }
            else if (cbxTrening.Checked == false && cbxIshrana.Checked == true)
            {

                var result = await _proizvodi.Get<List<OnlineGym_Model.Proizvod>>(new ProizvodSearchRequest()
                {
                    VrstaProizvodaId = 1
                });

                var dgvResult = new List<OnlineGym_Model.Proizvod_Rezultat>();

                foreach (var pro in result)
                {
                    Proizvod_Rezultat temp = new Proizvod_Rezultat(pro);
                    dgvResult.Add(temp);
                    temp = null;
                }

                dgvProizvodi.AutoGenerateColumns = false;
                dgvProizvodi.DataSource = dgvResult;

            }
            else if (cbxTrening.Checked == false && cbxIshrana.Checked == false)

            {
                dgvProizvodi.AutoGenerateColumns = false;
                dgvProizvodi.DataSource = null;

            }
        
        }

        private async void cbxIshrana_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTrening.Checked == true && cbxIshrana.Checked == true)
            {
                await LoadProizvodi();
            }
            else if (cbxTrening.Checked == true && cbxIshrana.Checked == false)
            {

                var result = await _proizvodi.Get<List<OnlineGym_Model.Proizvod>>(new ProizvodSearchRequest()
                {
                    VrstaProizvodaId = 2
                });

                var dgvResult = new List<OnlineGym_Model.Proizvod_Rezultat>();

                foreach (var pro in result)
                {
                    Proizvod_Rezultat temp = new Proizvod_Rezultat(pro);
                    dgvResult.Add(temp);
                    temp = null;
                }

                dgvProizvodi.AutoGenerateColumns = false;
                dgvProizvodi.DataSource = dgvResult;
            }
            else if (cbxTrening.Checked == false && cbxIshrana.Checked == true)
            {

                var result = await _proizvodi.Get<List<OnlineGym_Model.Proizvod>>(new ProizvodSearchRequest()
                {
                    VrstaProizvodaId = 1
                });

                var dgvResult = new List<OnlineGym_Model.Proizvod_Rezultat>();

                foreach (var pro in result)
                {
                    Proizvod_Rezultat temp = new Proizvod_Rezultat(pro);
                    dgvResult.Add(temp);
                    temp = null;
                }

                dgvProizvodi.AutoGenerateColumns = false;
                dgvProizvodi.DataSource = dgvResult;
            }
            else if (cbxTrening.Checked == false && cbxIshrana.Checked == false)

            {
                dgvProizvodi.AutoGenerateColumns = false;
                dgvProizvodi.DataSource = null;

            }

        }
    }
}
