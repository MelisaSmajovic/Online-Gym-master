namespace OnlineGym_Desktop.Teretane
{
    partial class frmTeretaneIndex
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTeretanee = new System.Windows.Forms.DataGridView();
            this.TeretanaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RadnoVrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUrediTeretanu = new System.Windows.Forms.Button();
            this.btnDodajTeretanu = new System.Windows.Forms.Button();
            this.cmbTeretane = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPretragaNaziv = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.btnIzvjestaj = new System.Windows.Forms.Button();
            this.btnClanarine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeretanee)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pretraga po gradu";
            // 
            // dgvTeretanee
            // 
            this.dgvTeretanee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeretanee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeretanaId,
            this.Naziv,
            this.Grad,
            this.Adresa,
            this.RadnoVrijeme});
            this.dgvTeretanee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTeretanee.Location = new System.Drawing.Point(0, 235);
            this.dgvTeretanee.Name = "dgvTeretanee";
            this.dgvTeretanee.RowHeadersWidth = 51;
            this.dgvTeretanee.RowTemplate.Height = 24;
            this.dgvTeretanee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeretanee.Size = new System.Drawing.Size(966, 215);
            this.dgvTeretanee.TabIndex = 3;
            this.dgvTeretanee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeretanee_CellDoubleClick);
            // 
            // TeretanaId
            // 
            this.TeretanaId.DataPropertyName = "TeretanaId";
            this.TeretanaId.HeaderText = "TeretanaId";
            this.TeretanaId.MinimumWidth = 6;
            this.TeretanaId.Name = "TeretanaId";
            this.TeretanaId.Visible = false;
            this.TeretanaId.Width = 125;
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
            this.Grad.DataPropertyName = "Grad";
            this.Grad.HeaderText = "Grad";
            this.Grad.MinimumWidth = 6;
            this.Grad.Name = "Grad";
            // 
            // Adresa
            // 
            this.Adresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.MinimumWidth = 6;
            this.Adresa.Name = "Adresa";
            // 
            // RadnoVrijeme
            // 
            this.RadnoVrijeme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RadnoVrijeme.DataPropertyName = "RadnoVrijeme";
            this.RadnoVrijeme.HeaderText = "Radno vrijeme";
            this.RadnoVrijeme.MinimumWidth = 6;
            this.RadnoVrijeme.Name = "RadnoVrijeme";
            // 
            // btnUrediTeretanu
            // 
            this.btnUrediTeretanu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnUrediTeretanu.FlatAppearance.BorderSize = 0;
            this.btnUrediTeretanu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrediTeretanu.ForeColor = System.Drawing.Color.Black;
            this.btnUrediTeretanu.Location = new System.Drawing.Point(666, 74);
            this.btnUrediTeretanu.Margin = new System.Windows.Forms.Padding(4);
            this.btnUrediTeretanu.Name = "btnUrediTeretanu";
            this.btnUrediTeretanu.Size = new System.Drawing.Size(120, 33);
            this.btnUrediTeretanu.TabIndex = 52;
            this.btnUrediTeretanu.Text = "Uredi ";
            this.btnUrediTeretanu.UseVisualStyleBackColor = false;
            this.btnUrediTeretanu.Click += new System.EventHandler(this.btnUrediTeretanu_Click);
            // 
            // btnDodajTeretanu
            // 
            this.btnDodajTeretanu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDodajTeretanu.FlatAppearance.BorderSize = 0;
            this.btnDodajTeretanu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodajTeretanu.ForeColor = System.Drawing.Color.Black;
            this.btnDodajTeretanu.Location = new System.Drawing.Point(794, 74);
            this.btnDodajTeretanu.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajTeretanu.Name = "btnDodajTeretanu";
            this.btnDodajTeretanu.Size = new System.Drawing.Size(113, 33);
            this.btnDodajTeretanu.TabIndex = 51;
            this.btnDodajTeretanu.Text = "Dodaj";
            this.btnDodajTeretanu.UseVisualStyleBackColor = false;
            this.btnDodajTeretanu.Click += new System.EventHandler(this.btnDodajTeretanu_Click);
            // 
            // cmbTeretane
            // 
            this.cmbTeretane.FormattingEnabled = true;
            this.cmbTeretane.Location = new System.Drawing.Point(152, 78);
            this.cmbTeretane.Name = "cmbTeretane";
            this.cmbTeretane.Size = new System.Drawing.Size(293, 24);
            this.cmbTeretane.TabIndex = 53;
            this.cmbTeretane.SelectedIndexChanged += new System.EventHandler(this.cmbTeretane_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Pretraga po nazivu";
            // 
            // txtPretragaNaziv
            // 
            this.txtPretragaNaziv.Location = new System.Drawing.Point(152, 115);
            this.txtPretragaNaziv.Name = "txtPretragaNaziv";
            this.txtPretragaNaziv.Size = new System.Drawing.Size(293, 22);
            this.txtPretragaNaziv.TabIndex = 63;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnPrikazi.FlatAppearance.BorderSize = 0;
            this.btnPrikazi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrikazi.ForeColor = System.Drawing.Color.Black;
            this.btnPrikazi.Location = new System.Drawing.Point(452, 112);
            this.btnPrikazi.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(81, 25);
            this.btnPrikazi.TabIndex = 64;
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
            this.btnIzvjestaj.Location = new System.Drawing.Point(666, 115);
            this.btnIzvjestaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzvjestaj.Name = "btnIzvjestaj";
            this.btnIzvjestaj.Size = new System.Drawing.Size(120, 33);
            this.btnIzvjestaj.TabIndex = 65;
            this.btnIzvjestaj.Text = "Izvještaj";
            this.btnIzvjestaj.UseVisualStyleBackColor = false;
            this.btnIzvjestaj.Click += new System.EventHandler(this.btnIzvjestaj_Click);
            // 
            // btnClanarine
            // 
            this.btnClanarine.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnClanarine.FlatAppearance.BorderSize = 0;
            this.btnClanarine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClanarine.ForeColor = System.Drawing.Color.Black;
            this.btnClanarine.Location = new System.Drawing.Point(794, 115);
            this.btnClanarine.Margin = new System.Windows.Forms.Padding(4);
            this.btnClanarine.Name = "btnClanarine";
            this.btnClanarine.Size = new System.Drawing.Size(113, 33);
            this.btnClanarine.TabIndex = 67;
            this.btnClanarine.Text = "Uplate";
            this.btnClanarine.UseVisualStyleBackColor = false;
            this.btnClanarine.Click += new System.EventHandler(this.btnClanarine_Click);
            // 
            // frmTeretaneIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 450);
            this.Controls.Add(this.btnClanarine);
            this.Controls.Add(this.btnIzvjestaj);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.txtPretragaNaziv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTeretane);
            this.Controls.Add(this.btnUrediTeretanu);
            this.Controls.Add(this.btnDodajTeretanu);
            this.Controls.Add(this.dgvTeretanee);
            this.Controls.Add(this.label1);
            this.Name = "frmTeretaneIndex";
            this.Text = "frmPretragaTeretana";
            this.Load += new System.EventHandler(this.frmTeretaneIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeretanee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTeretanee;
        private System.Windows.Forms.Button btnUrediTeretanu;
        private System.Windows.Forms.Button btnDodajTeretanu;
        private System.Windows.Forms.ComboBox cmbTeretane;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPretragaNaziv;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.Button btnIzvjestaj;
        private System.Windows.Forms.Button btnClanarine;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeretanaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn RadnoVrijeme;
    }
}