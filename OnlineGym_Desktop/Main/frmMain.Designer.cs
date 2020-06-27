namespace OnlineGym_Desktop.Main
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.btnProizvodi = new System.Windows.Forms.Button();
            this.btnPocetna = new System.Windows.Forms.Button();
            this.btnNarudzbe = new System.Windows.Forms.Button();
            this.btnProfil = new System.Windows.Forms.Button();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.btnClanovi = new System.Windows.Forms.Button();
            this.btnTeretane = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.Controls.Add(this.btnOdjava);
            this.MenuPanel.Controls.Add(this.btnPocetna);
            this.MenuPanel.Controls.Add(this.btnProfil);
            this.MenuPanel.Controls.Add(this.btnNarudzbe);
            this.MenuPanel.Controls.Add(this.btnClanovi);
            this.MenuPanel.Controls.Add(this.btnProizvodi);
            this.MenuPanel.Controls.Add(this.btnTeretane);
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(1007, 51);
            this.MenuPanel.TabIndex = 1;
            // 
            // btnProizvodi
            // 
            this.btnProizvodi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnProizvodi.Location = new System.Drawing.Point(584, -1);
            this.btnProizvodi.Name = "btnProizvodi";
            this.btnProizvodi.Size = new System.Drawing.Size(139, 50);
            this.btnProizvodi.TabIndex = 2;
            this.btnProizvodi.Text = "Proizvodi";
            this.btnProizvodi.UseVisualStyleBackColor = false;
            this.btnProizvodi.Click += new System.EventHandler(this.btnProizvodi_Click);
            // 
            // btnPocetna
            // 
            this.btnPocetna.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnPocetna.Location = new System.Drawing.Point(-1, -1);
            this.btnPocetna.Name = "btnPocetna";
            this.btnPocetna.Size = new System.Drawing.Size(141, 50);
            this.btnPocetna.TabIndex = 1;
            this.btnPocetna.Text = "Početna";
            this.btnPocetna.UseVisualStyleBackColor = false;
            this.btnPocetna.Click += new System.EventHandler(this.btnPocetna_Click);
            // 
            // btnNarudzbe
            // 
            this.btnNarudzbe.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnNarudzbe.Location = new System.Drawing.Point(716, -1);
            this.btnNarudzbe.Name = "btnNarudzbe";
            this.btnNarudzbe.Size = new System.Drawing.Size(147, 50);
            this.btnNarudzbe.TabIndex = 5;
            this.btnNarudzbe.Text = "Narudžbe";
            this.btnNarudzbe.UseVisualStyleBackColor = false;
            this.btnNarudzbe.Click += new System.EventHandler(this.btnNarudzbe_Click);
            // 
            // btnProfil
            // 
            this.btnProfil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnProfil.Location = new System.Drawing.Point(135, -1);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(161, 50);
            this.btnProfil.TabIndex = 2;
            this.btnProfil.Text = "Moj profil";
            this.btnProfil.UseVisualStyleBackColor = false;
            this.btnProfil.Click += new System.EventHandler(this.btnProfil_Click);
            // 
            // btnOdjava
            // 
            this.btnOdjava.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnOdjava.Location = new System.Drawing.Point(859, -1);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(147, 50);
            this.btnOdjava.TabIndex = 2;
            this.btnOdjava.Text = "Odjavi se";
            this.btnOdjava.UseVisualStyleBackColor = false;
            this.btnOdjava.Click += new System.EventHandler(this.btnOdjava_Click);
            // 
            // btnClanovi
            // 
            this.btnClanovi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnClanovi.Location = new System.Drawing.Point(291, -1);
            this.btnClanovi.Name = "btnClanovi";
            this.btnClanovi.Size = new System.Drawing.Size(150, 50);
            this.btnClanovi.TabIndex = 2;
            this.btnClanovi.Text = "Članovi";
            this.btnClanovi.UseVisualStyleBackColor = false;
            this.btnClanovi.Click += new System.EventHandler(this.btnClanovi_Click);
            // 
            // btnTeretane
            // 
            this.btnTeretane.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTeretane.Location = new System.Drawing.Point(438, -1);
            this.btnTeretane.Name = "btnTeretane";
            this.btnTeretane.Size = new System.Drawing.Size(150, 50);
            this.btnTeretane.TabIndex = 2;
            this.btnTeretane.Text = "Teretane";
            this.btnTeretane.UseVisualStyleBackColor = false;
            this.btnTeretane.Click += new System.EventHandler(this.btnTeretane_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 450);
            this.Controls.Add(this.MenuPanel);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button btnPocetna;
        private System.Windows.Forms.Button btnProfil;
        private System.Windows.Forms.Button btnTeretane;
        private System.Windows.Forms.Button btnProizvodi;
        private System.Windows.Forms.Button btnOdjava;
        private System.Windows.Forms.Button btnClanovi;
        private System.Windows.Forms.Button btnNarudzbe;
    }
}