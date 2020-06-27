using OnlineGym_Desktop.Helper;
using OnlineGym_Desktop.Properties;
using OnlineGym_Model;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineGym_Desktop.Korisnici
{
    public partial class frmUrediProfil : Form
    {
        private int? _id = null;
        public bool AddSlika = false;
        APIService _korisnici = new APIService("Korisnici");
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
        public frmUrediProfil(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmUrediProfil_Load(object sender, EventArgs e)
        {
            FillForm();
        }
        private async void FillForm()
        {
            var entity = await _korisnici.GetById<OnlineGym_Model.Korisnik>(_id);
            labIme.Text = entity.Ime;
            labPrezime.Text = entity.Prezime;
            labTelefon.Text = entity.Telefon;
            labEmail.Text = entity.Email;
            labAdresa.Text = entity.Adresa;
            labKorisnickoIme.Text = entity.KorisnickoIme;
            byte[] slikaByteArray = entity.FotografijaThum;
            if (slikaByteArray.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(entity.FotografijaThum));
                pictureBox.Image = x;
            }

        }
        KorisniciInsertRequest request = new KorisniciInsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
         
            if (ValidateChildren())
            {
                var entity1 = await _korisnici.GetById<OnlineGym_Model.Korisnik>(_id);
                if (AddSlika == false) 
                {
                    request.Fotografija = entity1.Fotografija;
                    request.FotografijaThum = entity1.FotografijaThum;
                }
                request.Ime = labIme.Text;
                request.Prezime = labPrezime.Text;
                request.Telefon = labTelefon.Text;
                request.Email = labEmail.Text;
                request.Adresa = labAdresa.Text;
                request.KorisnickoIme = labKorisnickoIme.Text;
                request.StariPassword = labStaraLozinka.Text;
                request.Password = labLozinka.Text;
                request.PasswordPotvrda = labLozinkaPotvrda.Text;
                
                OnlineGym_Model.Korisnik entity = null;

                    entity = await _korisnici.Update<OnlineGym_Model.Korisnik>(_id.Value, request);
  
                if (entity == null)
                {
                   
                    MessageBox.Show("Unesite ispravnu staru lozinku!");
                    return;
                }
                GlobalKorisnik.Username = labKorisnickoIme.Text;
                APIService.Username = GlobalKorisnik.Username;
                APIService.Password = labLozinka.Text;
                MessageBox.Show("Izmjene spašene!");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                AddSlika = true;
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                request.Fotografija = file;
                txtSlikaInput.Text = fileName;

                Image image = Image.FromFile(fileName);
                int resizedImgWidth = 300;
                int resizedImgHeight = 300;
                int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
                int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

                    Image resizedImg = UIHelper.ResizeImage(image, new Size(resizedImgWidth, resizedImgHeight));
                    ImageConverter imgCon = new ImageConverter();
                    request.FotografijaThum = (byte[])imgCon.ConvertTo(resizedImg, typeof(byte[]));
                    pictureBox.Image = resizedImg;


            }
        }

        private void labIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labIme.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labIme, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(labIme, null);
            }
        }

        private void labPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labPrezime.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labPrezime, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(labPrezime, null);
            }
        }

        private void labEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labEmail, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(labEmail, null);
                bool isEmailValid = Regex.IsMatch(labEmail.Text, emailPattern);
                if (isEmailValid == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(labEmail, "Unesite email u ispravnom formatu!");
                }
            }
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void labTelefon_Validating(object sender, CancelEventArgs e)
        {
            string unos = labTelefon.Text.ToString();
            if (string.IsNullOrWhiteSpace(labTelefon.Text) || labTelefon.Text.Length < 9 || labTelefon.Text.Length > 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(labTelefon, "Broj telefona treba sadržavati devet cifara!");
            }
            else
            {
                errorProvider1.SetError(labTelefon, null);

                string pozivniBroj = unos.Substring(0, 2);
                if (pozivniBroj != "03" && pozivniBroj != "06")
                {
                    e.Cancel = true;
                    errorProvider1.SetError(labTelefon, "Unesite telefon sa ispravnim pozivnim brojem!");
                }
                else
                {
                    errorProvider1.SetError(labTelefon, null);
                    if (IsDigitsOnly(unos) == false) 
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(labTelefon, "Telefon treba sadržavati samo brojeve!");
                    }
                    else
                    {
                        errorProvider1.SetError(labTelefon, null);
                    }
                }

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

        private async void labKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labKorisnickoIme.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labKorisnickoIme, Resources.Validation_RequiredField);
            }

            else
            {
                errorProvider1.SetError(labKorisnickoIme, null);
            }
            KorisniciSearchRequest query = new KorisniciSearchRequest();
            query.KorisnickoIme = labKorisnickoIme.Text;

            var lista = await _korisnici.Get<IEnumerable<Korisnik>>(query);
            if (lista.Count() > 0)
            {
                Korisnik proba = GlobalKorisnik.LogiraniKorisnik;
                foreach (var korisnickoIme in lista)
                {
                    if (korisnickoIme.KorisnickoIme != GlobalKorisnik.Username)
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(labKorisnickoIme,"Korisničko ime je već zauzeto! Odaberite neko drugo!");
                    }
                    else
                    {
                        errorProvider1.SetError(labKorisnickoIme, null);
                    }
                }
            }
        }
        private void labLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labLozinka.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labLozinka, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(labLozinka, null);
            }
        }
        private void labLozinkaPotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labLozinkaPotvrda.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labLozinkaPotvrda, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(labLozinkaPotvrda, null);
            }
            if (labLozinkaPotvrda.Text != labLozinka.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(labLozinkaPotvrda,"Lozinke se ne podudaraju!");
            }
            else
            {
                errorProvider1.SetError(labLozinkaPotvrda, null);
            }
        }

        private void labStaraLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labStaraLozinka.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(labStaraLozinka, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(labStaraLozinka, null);
            }
        }
    }
}
