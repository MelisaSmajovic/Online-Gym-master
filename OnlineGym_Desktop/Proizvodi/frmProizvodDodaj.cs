using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Configuration;
using OnlineGym_Desktop.Helper;
using OnlineGym_Desktop;
using OnlineGym_Model.Requests;
using OnlineGym_Desktop.Properties;

namespace OnlineGym_Desktop.Proizvodi
{
    public partial class frmProizvodDodaj : Form
    {
        private readonly APIService _kategorijeProizvoda = new APIService("KategorijeProizvoda");
        private readonly APIService _vrsteProizvoda = new APIService("VrsteProizvoda");
        private readonly APIService _proizvodi = new APIService("Proizvod");
        public frmProizvodDodaj()
        {
            InitializeComponent();
        }
        private async void frmProizvodDodaj_Load(object sender, EventArgs e)
        {
            await LoadKategorijeProizvoda();
            await LoadVrsteProizvoda();
            tbOpis.Height = 100;
            
        }
        private async Task LoadKategorijeProizvoda()
        {
            var result = await _kategorijeProizvoda.Get<List<OnlineGym_Model.KategorijeProizvoda>>(null);
            cmbKategorijaProizvoda.DisplayMember = "Naziv";
            cmbKategorijaProizvoda.ValueMember = "KategorijaProizvodaId";
            cmbKategorijaProizvoda.DataSource = result;
        }
        private async Task LoadVrsteProizvoda()
        {
            var result = await _vrsteProizvoda.Get<List<OnlineGym_Model.VrsteProizvoda>>(null);
            cmbVrsta.DisplayMember = "Naziv";
            cmbVrsta.ValueMember = "VrstaProizvodaId";
            cmbVrsta.DataSource = result;
        }
        ProizvodUpsertRequest request = new ProizvodUpsertRequest();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var idObj = cmbKategorijaProizvoda.SelectedValue;

                if (int.TryParse(idObj.ToString(), out int kategorijaId))
                {
                    request.KategorijaProizvodaId = kategorijaId;
                }
                var idObje = cmbVrsta.SelectedValue;

                if (int.TryParse(idObje.ToString(), out int vrstaId))
                {
                    request.VrstaProizvodaId = vrstaId;
                }

                request.Naziv = txtNaziv.Text;
                request.Sifra = txtSifra.Text;
                request.Cijena = inputCijena.Value;
                request.Opis = tbOpis.Text;

                await _proizvodi.Insert<OnlineGym_Model.Proizvod>(request);
                MessageBox.Show("Uspješno ste dodali novi proizvod!");
                this.Close();
            }
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                request.Slika = file;
                txtSlikaInput.Text = fileName;

                Image image = Image.FromFile(fileName);


                int resizedImgWidth = 300;
                int resizedImgHeight = 300;
                int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
             int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);


                Image resizedImg = UIHelper.ResizeImage(image, new Size(resizedImgWidth, resizedImgHeight));

                        ImageConverter imgCon = new ImageConverter();
                        request.SlikaThumb= (byte[])imgCon.ConvertTo(resizedImg, typeof(byte[]));
                        pictureBox.Image = resizedImg;


            }
        }
        private void txtSifra_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifra.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSifra, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtSifra, null);
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNaziv, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void inputCijena_Validating(object sender, CancelEventArgs e)
        {
            if (inputCijena.Value==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(inputCijena, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(inputCijena, null);
            }
        }
    }
}
