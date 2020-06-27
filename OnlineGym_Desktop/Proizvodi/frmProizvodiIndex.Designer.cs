namespace OnlineGym_Desktop.Proizvodi
{
    partial class frmProizvodiIndex
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
            this.btnUrediProizvod = new System.Windows.Forms.Button();
            this.btnDodajProizvod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKategorije = new System.Windows.Forms.ComboBox();
            this.dgvProizvodi = new System.Windows.Forms.DataGridView();
            this.ProizvodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kategorija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrstaProizvoda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPretragaNaziv = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.btnIzvjestaj = new System.Windows.Forms.Button();
            this.cbxTrening = new System.Windows.Forms.CheckBox();
            this.cbxIshrana = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUrediProizvod
            // 
            this.btnUrediProizvod.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnUrediProizvod.FlatAppearance.BorderSize = 0;
            this.btnUrediProizvod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrediProizvod.ForeColor = System.Drawing.Color.Black;
            this.btnUrediProizvod.Location = new System.Drawing.Point(676, 135);
            this.btnUrediProizvod.Margin = new System.Windows.Forms.Padding(4);
            this.btnUrediProizvod.Name = "btnUrediProizvod";
            this.btnUrediProizvod.Size = new System.Drawing.Size(123, 33);
            this.btnUrediProizvod.TabIndex = 58;
            this.btnUrediProizvod.Text = "Uredi ";
            this.btnUrediProizvod.UseVisualStyleBackColor = false;
            this.btnUrediProizvod.Click += new System.EventHandler(this.btnUrediProizvod_Click);
            // 
            // btnDodajProizvod
            // 
            this.btnDodajProizvod.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDodajProizvod.FlatAppearance.BorderSize = 0;
            this.btnDodajProizvod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodajProizvod.ForeColor = System.Drawing.Color.Black;
            this.btnDodajProizvod.Location = new System.Drawing.Point(807, 135);
            this.btnDodajProizvod.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajProizvod.Name = "btnDodajProizvod";
            this.btnDodajProizvod.Size = new System.Drawing.Size(123, 33);
            this.btnDodajProizvod.TabIndex = 57;
            this.btnDodajProizvod.Text = "Dodaj";
            this.btnDodajProizvod.UseVisualStyleBackColor = false;
            this.btnDodajProizvod.Click += new System.EventHandler(this.btnDodajProizvod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Pretraga po kategoriji";
            // 
            // cmbKategorije
            // 
            this.cmbKategorije.FormattingEnabled = true;
            this.cmbKategorije.Location = new System.Drawing.Point(183, 83);
            this.cmbKategorije.Name = "cmbKategorije";
            this.cmbKategorije.Size = new System.Drawing.Size(220, 24);
            this.cmbKategorije.TabIndex = 59;
            this.cmbKategorije.SelectedIndexChanged += new System.EventHandler(this.cmbKategorije_SelectedIndexChanged);
            // 
            // dgvProizvodi
            // 
            this.dgvProizvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProizvodi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProizvodId,
            this.Naziv,
            this.Grad,
            this.Kategorija,
            this.VrstaProizvoda});
            this.dgvProizvodi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProizvodi.Location = new System.Drawing.Point(0, 291);
            this.dgvProizvodi.Name = "dgvProizvodi";
            this.dgvProizvodi.RowHeadersWidth = 51;
            this.dgvProizvodi.RowTemplate.Height = 24;
            this.dgvProizvodi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProizvodi.Size = new System.Drawing.Size(987, 198);
            this.dgvProizvodi.TabIndex = 60;
            this.dgvProizvodi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProizvodi_CellDoubleClick);
            // 
            // ProizvodId
            // 
            this.ProizvodId.DataPropertyName = "ProizvodId";
            this.ProizvodId.HeaderText = "ProizvodId";
            this.ProizvodId.MinimumWidth = 6;
            this.ProizvodId.Name = "ProizvodId";
            this.ProizvodId.Visible = false;
            this.ProizvodId.Width = 125;
            // 
            // Naziv
            // 
            this.Naziv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            // 
            // Grad
            // 
            this.Grad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Grad.DataPropertyName = "Cijena";
            this.Grad.HeaderText = "Cijena";
            this.Grad.MinimumWidth = 6;
            this.Grad.Name = "Grad";
            // 
            // Kategorija
            // 
            this.Kategorija.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kategorija.DataPropertyName = "KategorijaProizvoda";
            this.Kategorija.HeaderText = "Kategorija";
            this.Kategorija.MinimumWidth = 6;
            this.Kategorija.Name = "Kategorija";
            // 
            // VrstaProizvoda
            // 
            this.VrstaProizvoda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VrstaProizvoda.DataPropertyName = "VrstaProizvoda";
            this.VrstaProizvoda.HeaderText = "Vrsta";
            this.VrstaProizvoda.MinimumWidth = 6;
            this.VrstaProizvoda.Name = "VrstaProizvoda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 61;
            this.label3.Text = "Pretraga po nazivu";
            // 
            // txtPretragaNaziv
            // 
            this.txtPretragaNaziv.Location = new System.Drawing.Point(183, 119);
            this.txtPretragaNaziv.Name = "txtPretragaNaziv";
            this.txtPretragaNaziv.Size = new System.Drawing.Size(220, 22);
            this.txtPretragaNaziv.TabIndex = 62;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnPrikazi.FlatAppearance.BorderSize = 0;
            this.btnPrikazi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrikazi.ForeColor = System.Drawing.Color.Black;
            this.btnPrikazi.Location = new System.Drawing.Point(410, 119);
            this.btnPrikazi.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(96, 25);
            this.btnPrikazi.TabIndex = 63;
            this.btnPrikazi.Text = "Prikazi";
            this.btnPrikazi.UseVisualStyleBackColor = false;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // btnIzvjestaj
            // 
            this.btnIzvjestaj.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnIzvjestaj.FlatAppearance.BorderSize = 0;
            this.btnIzvjestaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzvjestaj.ForeColor = System.Drawing.Color.Black;
            this.btnIzvjestaj.Location = new System.Drawing.Point(807, 94);
            this.btnIzvjestaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzvjestaj.Name = "btnIzvjestaj";
            this.btnIzvjestaj.Size = new System.Drawing.Size(123, 33);
            this.btnIzvjestaj.TabIndex = 65;
            this.btnIzvjestaj.Text = "Izvještaj";
            this.btnIzvjestaj.UseVisualStyleBackColor = false;
            this.btnIzvjestaj.Click += new System.EventHandler(this.btnIzvjestaj_Click);
            // 
            // cbxTrening
            // 
            this.cbxTrening.AutoSize = true;
            this.cbxTrening.Location = new System.Drawing.Point(151, 167);
            this.cbxTrening.Name = "cbxTrening";
            this.cbxTrening.Size = new System.Drawing.Size(114, 21);
            this.cbxTrening.TabIndex = 66;
            this.cbxTrening.Text = "Plan treninga";
            this.cbxTrening.UseVisualStyleBackColor = true;
            this.cbxTrening.CheckedChanged += new System.EventHandler(this.cbxTrening_CheckedChanged);
            // 
            // cbxIshrana
            // 
            this.cbxIshrana.AutoSize = true;
            this.cbxIshrana.Location = new System.Drawing.Point(36, 167);
            this.cbxIshrana.Name = "cbxIshrana";
            this.cbxIshrana.Size = new System.Drawing.Size(109, 21);
            this.cbxIshrana.TabIndex = 67;
            this.cbxIshrana.Text = "Plan ishrane";
            this.cbxIshrana.UseVisualStyleBackColor = true;
            this.cbxIshrana.CheckedChanged += new System.EventHandler(this.cbxIshrana_CheckedChanged);
            // 
            // frmProizvodiIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 489);
            this.Controls.Add(this.cbxIshrana);
            this.Controls.Add(this.cbxTrening);
            this.Controls.Add(this.btnIzvjestaj);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.txtPretragaNaziv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvProizvodi);
            this.Controls.Add(this.cmbKategorije);
            this.Controls.Add(this.btnUrediProizvod);
            this.Controls.Add(this.btnDodajProizvod);
            this.Controls.Add(this.label1);
            this.Name = "frmProizvodiIndex";
            this.Text = "frmProizvodiIndex";
            this.Load += new System.EventHandler(this.frmProizvodiIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUrediProizvod;
        private System.Windows.Forms.Button btnDodajProizvod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKategorije;
        private System.Windows.Forms.DataGridView dgvProizvodi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPretragaNaziv;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.Button btnIzvjestaj;
        private System.Windows.Forms.CheckBox cbxTrening;
        private System.Windows.Forms.CheckBox cbxIshrana;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProizvodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kategorija;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrstaProizvoda;
    }
}