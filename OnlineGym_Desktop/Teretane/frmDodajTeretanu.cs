using OnlineGym_Desktop;
using OnlineGym_Desktop.Helper;
using OnlineGym_Desktop.Properties;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineGym_Desktop.Teretane
{
    public partial class frmDodajTeretanu : Form
    {
        private readonly APIService _teretane = new APIService("Teretana");
        private readonly APIService _gradovi = new APIService("Grad");
        public frmDodajTeretanu()
        {
            InitializeComponent();
        }

        TeretanaUpsertRequest request = new TeretanaUpsertRequest();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                request.Naziv = txtNaziv.Text;
                request.Adresa = txtAdresa.Text;

                int pocetakSati = (int)PocetakSati.Value;
                int pocetakMinute = (int)PocetakMinuti.Value;
                TimeSpan pocetak = new TimeSpan(pocetakSati, pocetakMinute,0);
               request.PocetakRadnoVrijeme = pocetak;

                int krajSati = (int)KrajSati.Value;
                int krajMinute = (int)KrajMinuti.Value;
                TimeSpan kraj = new TimeSpan(krajSati, krajMinute, 0);
                request.KrajRadnoVrijeme = kraj;


                var idObj = cmbGradovi.SelectedValue;

                if (int.TryParse(idObj.ToString(), out int id))
                {
                    request.GradId = id;
                }
                try
                {
                    await _teretane.Insert<OnlineGym_Model.Teretana>(request);
                }
                catch(Exception error)
                {
                    MessageBox.Show("Greška!");
                }
                MessageBox.Show("Uspješno ste dodali teretanu!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Unesite potrebne podatke!");
            }
        }

        private async void frmDodajTeretanu_Load(object sender, EventArgs e)
        {
            await LoadGradovi();
        }
        private async Task LoadGradovi()
        {
            var result = await _gradovi.Get<List<OnlineGym_Model.Gradovi>>(null);
            cmbGradovi.DisplayMember = "Naziv";
            cmbGradovi.ValueMember = "GradId";
            cmbGradovi.DataSource = result;
        }
        private void LoadSlike(int SlikaId)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);
                Image image = Image.FromFile(fileName);
                if (SlikaId == 1)
                {
                    request.Slika1 = file;
                    txtSlikaInput1.Text = fileName;

                    int resizedImgWidth = 300;
                    int resizedImgHeight = 300;
                    int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
                    int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

                    //if (image.Width > resizedImgWidth)
                    //{
                        Image resizedImg = UIHelper.ResizeImage(image, new Size(resizedImgWidth, resizedImgHeight));
                        ImageConverter imgCon = new ImageConverter();
                        request.SlikaThumb1 = (byte[])imgCon.ConvertTo(resizedImg, typeof(byte[]));
                        pictureBox1.Image = resizedImg;
                    //}
                }
               else if (SlikaId == 2)
                {
                    request.Slika2 = file;
                    txtSlikaInput2.Text = fileName;
                 

                    int resizedImgWidth = 300;
                    int resizedImgHeight = 300;
                    int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
                    int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

                    //if (image.Width > resizedImgWidth)
                    //{
                        Image resizedImg = UIHelper.ResizeImage(image, new Size(resizedImgWidth, resizedImgHeight));

                            ImageConverter imgCon = new ImageConverter();
                            request.SlikaThumb2 = (byte[])imgCon.ConvertTo(resizedImg, typeof(byte[]));
                            pictureBox2.Image = resizedImg;
                        //}
                }
               else if (SlikaId == 3)
                {
                    request.Slika3 = file;
                    txtSlikaInput3.Text = fileName;


                    int resizedImgWidth = 300;
                    int resizedImgHeight = 300;
                    int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
                    int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

                    //if (image.Width > resizedImgWidth)
                    //{
                        Image resizedImg = UIHelper.ResizeImage(image, new Size(resizedImgWidth, resizedImgHeight));
                            ImageConverter imgCon = new ImageConverter();
                            request.SlikaThumb3 = (byte[])imgCon.ConvertTo(resizedImg, typeof(byte[]));
                            pictureBox3.Image = resizedImg;
                        //}
                }
               else if (SlikaId == 4)
                {
                    request.Slika4 = file;
                    txtSlikaInput4.Text = fileName;
           

                    int resizedImgWidth = 300;
                    int resizedImgHeight = 300;
                    int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
                    int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

                    //if (image.Width > resizedImgWidth)
                    //{
                        Image resizedImg = UIHelper.ResizeImage(image, new Size(resizedImgWidth, resizedImgHeight));

                            ImageConverter imgCon = new ImageConverter();
                            request.SlikaThumb4 = (byte[])imgCon.ConvertTo(resizedImg, typeof(byte[]));
                            pictureBox4.Image = resizedImg;
                        //}
                }
               else if (SlikaId == 5)
                {
                    request.Slika5 = file;
                    txtSlikaInput5.Text = fileName;
                 
                   

                    int resizedImgWidth = 300;
                    int resizedImgHeight = 300; 
                    int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
                    int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);


                        Image resizedImg = UIHelper.ResizeImage(image, new Size(resizedImgWidth, resizedImgHeight));

                            ImageConverter imgCon = new ImageConverter();
                            request.SlikaThumb5 = (byte[])imgCon.ConvertTo(resizedImg, typeof(byte[]));
                            pictureBox5.Image = resizedImg;
                    }
            }
            }
            private void button1_Click(object sender, EventArgs e)
        {
             LoadSlike(1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           LoadSlike(2);
        }

        private  void button3_Click(object sender, EventArgs e)
        {
           LoadSlike(3);
        }

        private  void button4_Click(object sender, EventArgs e)
        {
            LoadSlike(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           LoadSlike(5);
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAdresa, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtAdresa, null);
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
    }
}
