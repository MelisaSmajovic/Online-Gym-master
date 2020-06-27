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
    public partial class frmKorisnikDodaj : Form
    {
        APIService _korisnici = new APIService("Korisnici");
        APIService _uloge = new APIService("Uloge");
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"; 
        public frmKorisnikDodaj()
        {
            InitializeComponent();
        }

        private async void frmKorisnikDodaj_Load(object sender, EventArgs e)
        {
            var ulogeList = await _uloge.Get<List<OnlineGym_Model.Uloga>>(null);

            clbRole.DataSource = ulogeList;
            clbRole.DisplayMember = "Naziv";
        }
        KorisniciInsertRequest request = new KorisniciInsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var roleList = clbRole.CheckedItems.Cast<OnlineGym_Model.Uloga>().Select(x => x.UlogaId).ToList();
                request.Email = txtEmail.Text;
                request.Ime = txtIme.Text;
                request.KorisnickoIme = txtKorisnickoIme.Text;
                request.Password = txtPassword.Text;
                request.PasswordPotvrda = txtPassPotvrda.Text;
                request.Prezime = txtPrezime.Text;
                request.Telefon = txtTelefon.Text;
                request.Uloge = roleList;

                OnlineGym_Model.Korisnik entity = null;

                entity = await _korisnici.Insert<OnlineGym_Model.Korisnik>(request);

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    this.Close();
                }
            }
        }
        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtIme, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtIme, null);
            }
        }
        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrezime, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);
            }
        }

        private async void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text) || txtKorisnickoIme.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtKorisnickoIme, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }

            KorisniciSearchRequest query = new KorisniciSearchRequest();
            query.KorisnickoIme = txtKorisnickoIme.Text;

            var lista = await _korisnici.Get<IEnumerable<Korisnik>>(query);
            if (lista.Count() > 0)
            { 
                        e.Cancel = true;
                errorProvider1.SetError(txtKorisnickoIme, "Korisničko ime je već zauzeto! Odaberite neko drugo!");

            }
            else
            {
                errorProvider1.SetError(txtKorisnickoIme, null);
            }
            }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
                bool isEmailValid = Regex.IsMatch(txtEmail.Text, emailPattern);
                if (isEmailValid == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail,"Unesite email u ispravnom formatu!");
                }
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }
        private void txtPassPotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassPotvrda.Text) || txtPassPotvrda.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassPotvrda, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtPassPotvrda, null);
            }
        }
        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
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
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            string unos = txtTelefon.Text.ToString();
            if (string.IsNullOrWhiteSpace(txtTelefon.Text) || txtTelefon.Text.Length < 9 || txtTelefon.Text.Length>9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTelefon,"Broj telefona treba sadržavati devet cifara!");
            }
            else
            {
                errorProvider1.SetError(txtTelefon, null);

                string pozivniBroj = unos.Substring(0, 2);
                if (pozivniBroj != "03" && pozivniBroj != "06")
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtTelefon, "Unesite telefon sa ispravnim pozivnim brojem!");
                }
                else
                {
                    errorProvider1.SetError(txtTelefon, null);
                    if (IsDigitsOnly(unos) == false) 
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtTelefon, "Telefon treba sadržavati samo brojeve!");
                    }
                    else
                    {
                        errorProvider1.SetError(txtTelefon, null);
                    }
                }
               
            }
         
        }
        private void clbRole_Validating(object sender, CancelEventArgs e)
        {
            var roleList = clbRole.CheckedItems.Cast<OnlineGym_Model.Uloga>().Select(x => x.UlogaId).ToList();
            if (roleList.Count() == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(clbRole,"Morate odabrati ulogu/uloge!");
            }
            else
            {
                errorProvider1.SetError(clbRole, null);
            }
        }
    }
}
