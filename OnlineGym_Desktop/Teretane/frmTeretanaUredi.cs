using OnlineGym_Desktop;
using OnlineGym_Desktop.Properties;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineGym_Desktop.Teretane
{
    public partial class frmTeretanaUredi : Form
    {
        private int? _id = null;
        private readonly APIService _teretane = new APIService("Teretana");
        public frmTeretanaUredi(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmTeretanaUredi_Load(object sender, EventArgs e)
        {
            FillForm();
        }
        private async void FillForm()
        {
            var entity = await _teretane.GetById<OnlineGym_Model.Teretana>(_id);
            labNaziv.Text = entity.Naziv;
            labAdresa.Text = entity.Adresa;

            PocetakSati.Value = entity.PocetakRadnoVrijeme.Hours;
            PocetakMinuti.Value = entity.PocetakRadnoVrijeme.Minutes;

            KrajSati.Value = entity.KrajRadnoVrijeme.Hours;
            KrajMinuti.Value = entity.KrajRadnoVrijeme.Minutes;
            byte[] slikaByteArray = entity.SlikaThumb1;
            if (slikaByteArray.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(entity.SlikaThumb1));
                pictureBox1.Image = x;
            }

        }
        TeretanaUpsertRequest request = new TeretanaUpsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var entity1 = await _teretane.GetById<OnlineGym_Model.Teretana>(_id);
                request.Naziv = labNaziv.Text;
                request.Adresa = labAdresa.Text;
                request.GradId = entity1.GradId;


                byte[] slikaThumbByteArray1 = entity1.SlikaThumb1;
                if (slikaThumbByteArray1.Length > 0)
                {
                    request.SlikaThumb1 = entity1.SlikaThumb1;
                }
                byte[] slikaThumbByteArray2 = entity1.SlikaThumb2;
                if (slikaThumbByteArray2.Length > 0)
                {
                    request.SlikaThumb2 = entity1.SlikaThumb2;
                }
                byte[] slikaThumbByteArray3 = entity1.SlikaThumb3;
                if (slikaThumbByteArray3.Length > 0)
                {
                    request.SlikaThumb3 = entity1.SlikaThumb3;
                }
                byte[] slikaThumbByteArray4 = entity1.SlikaThumb4;
                if (slikaThumbByteArray4.Length > 0)
                {
                    request.SlikaThumb4 = entity1.SlikaThumb4;
                }
                byte[] slikaThumbByteArray5 = entity1.SlikaThumb5;
                if (slikaThumbByteArray5.Length > 0)
                {
                    request.SlikaThumb5 = entity1.SlikaThumb5;
                }


                byte[] slikaByteArray1 = entity1.Slika1;
                if (slikaByteArray1.Length > 0)
                {
                    request.Slika1 = entity1.Slika1;
                }
                byte[] slikaByteArray2 = entity1.Slika2;
                if (slikaByteArray2.Length > 0)
                {
                    request.Slika2 = entity1.Slika2;
                }
                byte[] slikaByteArray3 = entity1.Slika3;
                if (slikaByteArray3.Length > 0)
                {
                    request.Slika3 = entity1.Slika3;
                }
                byte[] slikaByteArray4 = entity1.Slika4;
                if (slikaByteArray4.Length > 0)
                {
                    request.Slika4 = entity1.Slika4;
                }
                byte[] slikaByteArray5 = entity1.Slika5;
                if (slikaByteArray5.Length > 0)
                {
                    request.Slika5 = entity1.Slika5;
                }


                int pocetakSati = (int)PocetakSati.Value;
                int pocetakMinute = (int)PocetakMinuti.Value;
                TimeSpan pocetak = new TimeSpan(pocetakSati, pocetakMinute, 0);
                request.PocetakRadnoVrijeme = pocetak;

                int krajSati = (int)KrajSati.Value;
                int krajMinute = (int)KrajMinuti.Value;
                TimeSpan kraj = new TimeSpan(krajSati, krajMinute, 0);
                request.KrajRadnoVrijeme = kraj;

                OnlineGym_Model.Teretana entity = null;
                entity = await _teretane.Update<OnlineGym_Model.Teretana>(_id.Value, request);
                MessageBox.Show("Izmjene spašene!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Unesite potrebne podatke!");
            }
        }

        private async void slika1_Click(object sender, EventArgs e)
        {
            var entity = await _teretane.GetById<OnlineGym_Model.Teretana>(_id);
            byte[] slikaByteArray = entity.SlikaThumb1;
            if (slikaByteArray.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(entity.SlikaThumb1));
                pictureBox1.Image = x;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private async void slika2_Click(object sender, EventArgs e)
        {
            var entity = await _teretane.GetById<OnlineGym_Model.Teretana>(_id);
            byte[] slikaByteArray = entity.SlikaThumb2;
            if (slikaByteArray.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(entity.SlikaThumb2));
                pictureBox1.Image = x;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private async void slika3_Click(object sender, EventArgs e)
        {
            var entity = await _teretane.GetById<OnlineGym_Model.Teretana>(_id);
            byte[] slikaByteArray = entity.SlikaThumb3;
            if (slikaByteArray.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(entity.SlikaThumb3));
                pictureBox1.Image = x;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private async void slika4_Click(object sender, EventArgs e)
        {
            var entity = await _teretane.GetById<OnlineGym_Model.Teretana>(_id);
            byte[] slikaByteArray = entity.SlikaThumb4;
            if (slikaByteArray.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(entity.SlikaThumb4));
                pictureBox1.Image = x;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private async void slika5_Click(object sender, EventArgs e)
        {
            var entity = await _teretane.GetById<OnlineGym_Model.Teretana>(_id);
            byte[] slikaByteArray = entity.SlikaThumb5;
            if (slikaByteArray.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(entity.SlikaThumb5));
                pictureBox1.Image = x;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void labAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labAdresa.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labAdresa, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(labAdresa, null);
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
