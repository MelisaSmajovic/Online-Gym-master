namespace OnlineGym_Desktop.Teretane
{
    partial class frmTeretanaUredi
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.labNaziv = new System.Windows.Forms.TextBox();
            this.labAdresa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.slika1 = new System.Windows.Forms.Button();
            this.slika2 = new System.Windows.Forms.Button();
            this.slika3 = new System.Windows.Forms.Button();
            this.slika4 = new System.Windows.Forms.Button();
            this.slika5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.KrajMinuti = new System.Windows.Forms.NumericUpDown();
            this.KrajSati = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.PocetakMinuti = new System.Windows.Forms.NumericUpDown();
            this.PocetakSati = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KrajMinuti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KrajSati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PocetakMinuti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PocetakSati)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 80;
            this.label5.Text = "Radno vrijeme";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSacuvaj.Location = new System.Drawing.Point(612, 261);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(116, 42);
            this.btnSacuvaj.TabIndex = 78;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // labNaziv
            // 
            this.labNaziv.Location = new System.Drawing.Point(124, 118);
            this.labNaziv.Name = "labNaziv";
            this.labNaziv.Size = new System.Drawing.Size(288, 22);
            this.labNaziv.TabIndex = 73;
            this.labNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.labNaziv_Validating);
            // 
            // labAdresa
            // 
            this.labAdresa.Location = new System.Drawing.Point(124, 74);
            this.labAdresa.Name = "labAdresa";
            this.labAdresa.Size = new System.Drawing.Size(288, 22);
            this.labAdresa.TabIndex = 72;
            this.labAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.labAdresa_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 71;
            this.label4.Text = "Adresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 69;
            this.label2.Text = "Naziv";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // slika1
            // 
            this.slika1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.slika1.Location = new System.Drawing.Point(532, 207);
            this.slika1.Name = "slika1";
            this.slika1.Size = new System.Drawing.Size(34, 30);
            this.slika1.TabIndex = 82;
            this.slika1.Text = "1";
            this.slika1.UseVisualStyleBackColor = false;
            this.slika1.Click += new System.EventHandler(this.slika1_Click);
            // 
            // slika2
            // 
            this.slika2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.slika2.Location = new System.Drawing.Point(572, 207);
            this.slika2.Name = "slika2";
            this.slika2.Size = new System.Drawing.Size(34, 30);
            this.slika2.TabIndex = 83;
            this.slika2.Text = "2";
            this.slika2.UseVisualStyleBackColor = false;
            this.slika2.Click += new System.EventHandler(this.slika2_Click);
            // 
            // slika3
            // 
            this.slika3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.slika3.Location = new System.Drawing.Point(612, 207);
            this.slika3.Name = "slika3";
            this.slika3.Size = new System.Drawing.Size(34, 30);
            this.slika3.TabIndex = 84;
            this.slika3.Text = "3";
            this.slika3.UseVisualStyleBackColor = false;
            this.slika3.Click += new System.EventHandler(this.slika3_Click);
            // 
            // slika4
            // 
            this.slika4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.slika4.Location = new System.Drawing.Point(652, 207);
            this.slika4.Name = "slika4";
            this.slika4.Size = new System.Drawing.Size(34, 30);
            this.slika4.TabIndex = 85;
            this.slika4.Text = "4";
            this.slika4.UseVisualStyleBackColor = false;
            this.slika4.Click += new System.EventHandler(this.slika4_Click);
            // 
            // slika5
            // 
            this.slika5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.slika5.Location = new System.Drawing.Point(692, 207);
            this.slika5.Name = "slika5";
            this.slika5.Size = new System.Drawing.Size(34, 30);
            this.slika5.TabIndex = 86;
            this.slika5.Text = "5";
            this.slika5.UseVisualStyleBackColor = false;
            this.slika5.Click += new System.EventHandler(this.slika5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(532, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(354, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 17);
            this.label13.TabIndex = 116;
            this.label13.Text = ":";
            // 
            // KrajMinuti
            // 
            this.KrajMinuti.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.KrajMinuti.Location = new System.Drawing.Point(366, 160);
            this.KrajMinuti.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.KrajMinuti.Name = "KrajMinuti";
            this.KrajMinuti.Size = new System.Drawing.Size(46, 22);
            this.KrajMinuti.TabIndex = 115;
            // 
            // KrajSati
            // 
            this.KrajSati.Location = new System.Drawing.Point(305, 160);
            this.KrajSati.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.KrajSati.Name = "KrajSati";
            this.KrajSati.Size = new System.Drawing.Size(47, 22);
            this.KrajSati.TabIndex = 114;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(276, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 17);
            this.label12.TabIndex = 113;
            this.label12.Text = "do";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(211, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 17);
            this.label11.TabIndex = 112;
            this.label11.Text = ":";
            // 
            // PocetakMinuti
            // 
            this.PocetakMinuti.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PocetakMinuti.Location = new System.Drawing.Point(223, 160);
            this.PocetakMinuti.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.PocetakMinuti.Name = "PocetakMinuti";
            this.PocetakMinuti.Size = new System.Drawing.Size(46, 22);
            this.PocetakMinuti.TabIndex = 111;
            // 
            // PocetakSati
            // 
            this.PocetakSati.Location = new System.Drawing.Point(162, 160);
            this.PocetakSati.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.PocetakSati.Name = "PocetakSati";
            this.PocetakSati.Size = new System.Drawing.Size(47, 22);
            this.PocetakSati.TabIndex = 110;
            // 
            // frmTeretanaUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 344);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.KrajMinuti);
            this.Controls.Add(this.KrajSati);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.PocetakMinuti);
            this.Controls.Add(this.PocetakSati);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.slika5);
            this.Controls.Add(this.slika4);
            this.Controls.Add(this.slika3);
            this.Controls.Add(this.slika2);
            this.Controls.Add(this.slika1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.labNaziv);
            this.Controls.Add(this.labAdresa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "frmTeretanaUredi";
            this.Text = "frmTeretanaUredi";
            this.Load += new System.EventHandler(this.frmTeretanaUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KrajMinuti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KrajSati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PocetakMinuti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PocetakSati)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.TextBox labNaziv;
        private System.Windows.Forms.TextBox labAdresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button slika1;
        private System.Windows.Forms.Button slika2;
        private System.Windows.Forms.Button slika3;
        private System.Windows.Forms.Button slika4;
        private System.Windows.Forms.Button slika5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown KrajMinuti;
        private System.Windows.Forms.NumericUpDown KrajSati;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown PocetakMinuti;
        private System.Windows.Forms.NumericUpDown PocetakSati;
    }
}