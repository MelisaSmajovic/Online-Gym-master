using OnlineGym_Desktop.Properties;
using OnlineGym_Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineGym_Desktop.Korisnici
{
    public partial class frm_KorisnikDetalji : Form
    {
        APIService _korisnici = new APIService("Korisnici");
        APIService _uloge = new APIService("Uloge");
        APIService _korisnikUloge = new APIService("KorisnikUloge");
        private int? _id = null;
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
        public frm_KorisnikDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frm_KorisnikDetalji_Load(object sender, EventArgs e)
        {

            var result = await _korisnikUloge.Get<List<OnlineGym_Model.KorisnikUloge>>(new KorisnikUlogaSearchRequest()
            {
                KorisnikId = _id
            });

            var ulogeList = await _uloge.Get<List<OnlineGym_Model.Uloga>>(null);
            clbRole.DataSource = ulogeList;
            clbRole.DisplayMember = "Naziv";



            for (int i = 0; i < ulogeList.Count(); i++)
            {
                for (int j = 0; j < result.Count(); j++)
                {
                    if (result[j].UlogaId == ulogeList[i].UlogaId)
                    {
                        clbRole.SetItemChecked(i, true);
                    }
                }
            }

            if (_id.HasValue)
            {
                var entity = await _korisnici.GetById<OnlineGym_Model.Korisnik>(_id);
                txtEmail.Text = entity.Email;
                txtIme.Text = entity.Ime;
                txtKorisnickoIme.Text = entity.KorisnickoIme;
                txtPrezime.Text = entity.Prezime;
                txtTelefon.Text = entity.Telefon;
                byte[] slikaByteArray = entity.FotografijaThum;
                if (slikaByteArray.Length > 0)
                {
                    Image x = (Bitmap)((new ImageConverter()).ConvertFrom(entity.FotografijaThum));
                    pictureBox.Image = x;
                }
            }
        }
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var entity1 = await _korisnici.GetById<OnlineGym_Model.Korisnik>(_id);
                var roleList = clbRole.CheckedItems.Cast<OnlineGym_Model.Uloga>().Select(x => x.UlogaId).ToList();
            var request = new KorisniciInsertRequest
                {
                Fotografija=entity1.Fotografija,
                FotografijaThum=entity1.FotografijaThum,
                    Email = txtEmail.Text,
                    Ime = txtIme.Text,
                    KorisnickoIme = txtKorisnickoIme.Text,
                    Prezime = txtPrezime.Text,
                    Telefon = txtTelefon.Text,
                    Uloge = roleList
                };
            OnlineGym_Model.Korisnik entity = null;
                    entity = await _korisnici.Update<OnlineGym_Model.Korisnik>(_id.Value, request);
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
                    errorProvider1.SetError(txtEmail, "Unesite email u ispravnom formatu!");
                }
            }
        }
        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text) || txtKorisnickoIme.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
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
            if (string.IsNullOrWhiteSpace(txtTelefon.Text) || txtTelefon.Text.Length < 9 || txtTelefon.Text.Length > 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTelefon, "Broj telefona treba sadržavati devet cifara!");
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
                errorProvider1.SetError(clbRole, "Morate odabrati ulogu/uloge!");
            }
            else
            {
                errorProvider1.SetError(clbRole, null);
            }
        }
    }
}
