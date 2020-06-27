using OnlineGym_Desktop.Main;
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

namespace OnlineGym_Desktop.Korisnici
{
    public partial class frmMojProfil : Form
    {
        APIService _korisnici = new APIService("Korisnici");
        APIService _uloge = new APIService("Uloge");
        APIService _korisnikUloge = new APIService("KorisnikUloge");
        private int? _id = null;
        public frmMojProfil(int? id = null)
        {
            InitializeComponent();
            _id = id;

        }
        private void frmMojProfil_Load(object sender, EventArgs e)
        {
            FillForm();
            LoadUloge(_id);
        }
        private async void LoadUloge(int? id)
        {
            var result = await _korisnikUloge.Get<List<OnlineGym_Model.KorisnikUloge>>(new KorisnikUlogaSearchRequest()
            {
                KorisnikId = id
            });
            if (result.Count() > 0)
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    labUloge.Text = labUloge.Text + "-" + result[i].Uloga.Naziv + Environment.NewLine;
                }
            }
         
        }
        private async void FillForm()
        {
            if (_id != 0)
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
        }
        private void btnUredi_Click(object sender, EventArgs e)
        {
            var korisnikId = GlobalKorisnik.LogiraniKorisnikId;
            frmUrediProfil frm = new frmUrediProfil(korisnikId);
            this.Close();
            frm.Show();
        }
    }
}
