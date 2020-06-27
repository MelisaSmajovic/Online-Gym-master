namespace OnlineGym_Desktop.Proizvodi
{
    partial class frmProizvodUredi
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.txtSlikaInput = new System.Windows.Forms.TextBox();
            this.labNaziv = new System.Windows.Forms.TextBox();
            this.labSifra = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVrsta = new System.Windows.Forms.ComboBox();
            this.cmbKategorije = new System.Windows.Forms.ComboBox();
            this.inputCijena = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Opis = new System.Windows.Forms.Label();
            this.tbOpis = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCijena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(590, 63);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(120, 120);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 105;
            this.pictureBox.TabStop = false;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSacuvaj.Location = new System.Drawing.Point(594, 300);
            this.btnSacuvaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(120, 44);
            this.btnSacuvaj.TabIndex = 104;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(120, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 102;
            this.label10.Text = "Cijena";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(125, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 17);
            this.label9.TabIndex = 101;
            this.label9.Text = "Naziv";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 100;
            this.label8.Text = "Šifra";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 17);
            this.label7.TabIndex = 99;
            this.label7.Text = "Kategorija proizvoda";
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDodajSliku.Location = new System.Drawing.Point(592, 221);
            this.btnDodajSliku.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(122, 28);
            this.btnDodajSliku.TabIndex = 97;
            this.btnDodajSliku.Text = "Dodaj novu sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = false;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // txtSlikaInput
            // 
            this.txtSlikaInput.Location = new System.Drawing.Point(590, 191);
            this.txtSlikaInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtSlikaInput.Name = "txtSlikaInput";
            this.txtSlikaInput.Size = new System.Drawing.Size(124, 22);
            this.txtSlikaInput.TabIndex = 98;
            this.txtSlikaInput.TabStop = false;
            // 
            // labNaziv
            // 
            this.labNaziv.Location = new System.Drawing.Point(174, 151);
            this.labNaziv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labNaziv.Name = "labNaziv";
            this.labNaziv.Size = new System.Drawing.Size(273, 22);
            this.labNaziv.TabIndex = 95;
            this.labNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.labNaziv_Validating);
            // 
            // labSifra
            // 
            this.labSifra.Location = new System.Drawing.Point(174, 123);
            this.labSifra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labSifra.Name = "labSifra";
            this.labSifra.Size = new System.Drawing.Size(273, 22);
            this.labSifra.TabIndex = 94;
            this.labSifra.Validating += new System.ComponentModel.CancelEventHandler(this.labSifra_Validating);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 109;
            this.label1.Text = "Vrsta proizvoda";
            // 
            // cmbVrsta
            // 
            this.cmbVrsta.FormattingEnabled = true;
            this.cmbVrsta.Location = new System.Drawing.Point(174, 63);
            this.cmbVrsta.Name = "cmbVrsta";
            this.cmbVrsta.Size = new System.Drawing.Size(273, 24);
            this.cmbVrsta.TabIndex = 110;
            // 
            // cmbKategorije
            // 
            this.cmbKategorije.FormattingEnabled = true;
            this.cmbKategorije.Location = new System.Drawing.Point(174, 95);
            this.cmbKategorije.Name = "cmbKategorije";
            this.cmbKategorije.Size = new System.Drawing.Size(273, 24);
            this.cmbKategorije.TabIndex = 111;
            // 
            // inputCijena
            // 
            this.inputCijena.DecimalPlaces = 2;
            this.inputCijena.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.inputCijena.Location = new System.Drawing.Point(174, 183);
            this.inputCijena.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.inputCijena.Name = "inputCijena";
            this.inputCijena.Size = new System.Drawing.Size(85, 22);
            this.inputCijena.TabIndex = 112;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Opis
            // 
            this.Opis.AutoSize = true;
            this.Opis.Location = new System.Drawing.Point(131, 220);
            this.Opis.Name = "Opis";
            this.Opis.Size = new System.Drawing.Size(37, 17);
            this.Opis.TabIndex = 114;
            this.Opis.Text = "Opis";
            // 
            // tbOpis
            // 
            this.tbOpis.Location = new System.Drawing.Point(174, 220);
            this.tbOpis.Name = "tbOpis";
            this.tbOpis.Size = new System.Drawing.Size(307, 22);
            this.tbOpis.TabIndex = 113;
            // 
            // frmProizvodUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 374);
            this.Controls.Add(this.Opis);
            this.Controls.Add(this.tbOpis);
            this.Controls.Add(this.inputCijena);
            this.Controls.Add(this.cmbKategorije);
            this.Controls.Add(this.cmbVrsta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.txtSlikaInput);
            this.Controls.Add(this.labNaziv);
            this.Controls.Add(this.labSifra);
            this.Name = "frmProizvodUredi";
            this.Text = "frmProizvodUredi";
            this.Load += new System.EventHandler(this.frmProizvodUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCijena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.TextBox txtSlikaInput;
        private System.Windows.Forms.TextBox labNaziv;
        private System.Windows.Forms.TextBox labSifra;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVrsta;
        private System.Windows.Forms.ComboBox cmbKategorije;
        private System.Windows.Forms.NumericUpDown inputCijena;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label Opis;
        private System.Windows.Forms.TextBox tbOpis;
    }
}