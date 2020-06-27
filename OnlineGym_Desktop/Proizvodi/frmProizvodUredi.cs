using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using OnlineGym_Desktop.Helper;
using OnlineGym_Model.Requests;
using OnlineGym_Desktop.Properties;

namespace OnlineGym_Desktop.Proizvodi
{
    public partial class frmProizvodUredi : Form
    {
        private int? _id = null;
        public bool AddSlika = false;
        private readonly APIService _kategorijeProizvoda = new APIService("KategorijeProizvoda");
        private readonly APIService _vrsteProizvoda = new APIService("VrsteProizvoda");
        private readonly APIService _proizvodi = new APIService("Proizvod");
        public frmProizvodUredi(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }
        private void frmProizvodUredi_Load(object sender, EventArgs e)
        {
            FillForm();
            tbOpis.Height = 100;
            tbOpis.Multiline = true;
            tbOpis.ScrollBars = ScrollBars.Vertical;

        }
        private async void FillForm()
        {
            var entity = await _proizvodi.GetById<OnlineGym_Model.Proizvod>(_id);
            labNaziv.Text = entity.Naziv;
            labSifra.Text = entity.Sifra;
            inputCijena.Value = (decimal)entity.Cijena;
            tbOpis.Text = entity.Opis;

            var result = await _vrsteProizvoda.Get<List<OnlineGym_Model.VrsteProizvoda>>(null);
            cmbVrsta.DisplayMember = "Naziv";
            cmbVrsta.ValueMember = "VrstaProizvodaId";
            cmbVrsta.DataSource = result;
            cmbVrsta.SelectedValue = entity.VrstaProizvodaId;


            var result2 = await _kategorijeProizvoda.Get<List<OnlineGym_Model.KategorijeProizvoda>>(null);
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "KategorijaProizvodaId";
            cmbKategorije.DataSource = result2;
            cmbKategorije.SelectedValue = entity.KategorijaProizvodaId;

            byte[] slikaByteArray = entity.SlikaThumb;
            if (slikaByteArray.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(entity.SlikaThumb));
                pictureBox.Image = x;
            }
        }

        ProizvodUpsertRequest request = new ProizvodUpsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var entity1 = await _proizvodi.GetById<OnlineGym_Model.Proizvod>(_id);
                request.Naziv = labNaziv.Text;
                request.Sifra = labSifra.Text;
                request.Opis = tbOpis.Text;
                var idKategorija = cmbKategorije.SelectedValue;

                if (int.TryParse(idKategorija.ToString(), out int idk))
                {
                    request.KategorijaProizvodaId = idk;
                }
                else
                {
                    request.KategorijaProizvodaId = entity1.KategorijaProizvodaId;
                }
                var idVrsta = cmbVrsta.SelectedValue;

                if (int.TryParse(idVrsta.ToString(), out int idv))
                {
                    request.VrstaProizvodaId = idv;
                }
                else
                {
                    request.VrstaProizvodaId = entity1.VrstaProizvodaId;
                }


                if (AddSlika==false)
                {
                    request.Slika = entity1.Slika;
                    request.SlikaThumb = entity1.SlikaThumb;
                }


                request.Cijena = inputCijena.Value;
                OnlineGym_Model.Proizvod entity = null;
                entity = await _proizvodi.Update<OnlineGym_Model.Proizvod>(_id.Value, request);
                if (entity != null)
                {
                    MessageBox.Show("Izmjene spašene!"); 
                    this.Close();
                }
            }
        
    } 
        private void btnDodajSliku_Click(object sender, EventArgs e)
        {

            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                AddSlika = true;
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
                    request.SlikaThumb = (byte[])imgCon.ConvertTo(resizedImg, typeof(byte[]));
                    pictureBox.Image = resizedImg;


            }
        }

        private void labSifra_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labSifra.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labSifra, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(labSifra, null);
            }
        }

        private void labNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labNaziv.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labNaziv, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(labNaziv, null);
            }
        }
    }
}
