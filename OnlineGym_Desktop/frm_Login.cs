using Microsoft.CSharp.RuntimeBinder;
using OnlineGym_Model.Requests;
using OnlineGym_Desktop.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineGym_Model;

namespace OnlineGym_Desktop
{
    public partial class frm_Login : Form
    {
        APIService _korisnici = new APIService("Korisnici");
        private readonly APIService _teretane = new APIService("Teretana");
        public frm_Login()
        {
            InitializeComponent();
        }
      
        private async void btnPrijava_Click(object sender, EventArgs e)
        {
            APIService.Username = txtKorisnickoIme.Text;
            APIService.Password = txtLozinka.Text;
            try
            {
                KorisniciSearchRequest request = new KorisniciSearchRequest();
                request.KorisnickoIme = txtKorisnickoIme.Text;
                request.IsUlogeLoadingEnabled = cbxMenadzer.Checked;
                if (cbxMenadzer.Checked == true)
                {
                    request.AdminChecked = true;
                }
                else
                {
                    request.AdminChecked = false;
                }
                var response = await _korisnici.Get<dynamic>(request);            
                if (response.Count > 0 && cbxMenadzer.Checked)
                {
                    GlobalKorisnik.Username = txtKorisnickoIme.Text;

                    KorisniciSearchRequest search = new KorisniciSearchRequest();
                    search.KorisnickoIme = GlobalKorisnik.Username;
                    var list = await _korisnici.Get<List<Korisnik>>(search);

                    var korisnik = list[0];

                    GlobalKorisnik.LogiraniKorisnikId = korisnik.KorisnikId;
                    GlobalKorisnik.LogiraniKorisnik = korisnik;
                    frmMainMenadzer frm = new frmMainMenadzer();
          
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    GlobalKorisnik.Username = txtKorisnickoIme.Text;

                    KorisniciSearchRequest search = new KorisniciSearchRequest();
                    search.KorisnickoIme = GlobalKorisnik.Username;
                    var list = await _korisnici.Get<List<Korisnik>>(search);

                    var korisnik = list[0];
                    GlobalKorisnik.LogiraniKorisnikId = korisnik.KorisnikId;
                    GlobalKorisnik.LogiraniKorisnik = korisnik;
                    frmMain frm = new frmMain();
                  
                    frm.Show();
                    this.Hide();

                }
               
            }
            catch (Exception ex)
            {
                if(cbxMenadzer.Checked==true)
                MessageBox.Show("Niste administrator sistema!Molimo Vas da se prijavite kao uposlenik/menadžer!");
               
            }
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }
    }
}


