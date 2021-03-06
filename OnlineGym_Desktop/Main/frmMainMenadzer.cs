﻿using OnlineGym_Desktop.Clanovi;
using OnlineGym_Desktop.Korisnici;
using OnlineGym_Desktop.Narudzbe;
using OnlineGym_Desktop.Proizvodi;
using OnlineGym_Desktop.Teretane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineGym_Desktop.Main
{
    public partial class frmMainMenadzer : Form
    {
        private int childFormNumber = 0;
        public frmMainMenadzer()
        {
            InitializeComponent();
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
       
        private void Zatvori()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            frm_Korisnici frm = new frm_Korisnici();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnPocetna_Click(object sender, EventArgs e)
        {
            Zatvori();
            frmPocetna frm = new frmPocetna();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
       private void btnProfil_Click(object sender, EventArgs e)
        {

            var korisnikId = GlobalKorisnik.LogiraniKorisnikId;

              frmMojProfil frm = new frmMojProfil(korisnikId);
                frm.MdiParent = this;
               frm.Dock = DockStyle.Fill;
               frm.Show();
        }

        private void btnTeretane_Click(object sender, EventArgs e)
        {
            frmTeretaneIndex frm = new frmTeretaneIndex();
               frm.MdiParent = this;
               frm.Dock = DockStyle.Fill;
               frm.Show();
        }

        private void btnProizvodi_Click(object sender, EventArgs e)
        {
            frmProizvodiIndex frm = new frmProizvodiIndex();
              frm.MdiParent = this;
              frm.Dock = DockStyle.Fill;
              frm.Show();
        }

        private void btnClanovi_Click(object sender, EventArgs e)
        {
            frmClanoviIndex frm = new frmClanoviIndex();
               frm.MdiParent = this;
               frm.Dock = DockStyle.Fill;
               frm.Show();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            Zatvori();
            frm_Login frm = new frm_Login();
            frm.Show();
            this.Hide();
        }

        private void btnNarudzbe_Click(object sender, EventArgs e)
        {
            frmNarudzbeIndex frm = new frmNarudzbeIndex();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void frmMainMenadzer_Load(object sender, EventArgs e)
        {
            frmPocetna frm = new frmPocetna();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
