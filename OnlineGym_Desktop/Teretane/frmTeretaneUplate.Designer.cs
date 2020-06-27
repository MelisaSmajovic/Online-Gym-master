namespace OnlineGym_Desktop.Teretane
{
    partial class frmTeretaneUplate
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
            this.dgvUplate = new System.Windows.Forms.DataGridView();
            this.Clan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipClanarine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teretana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumUplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UkupanIznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbClanovi = new System.Windows.Forms.ComboBox();
            this.btnIzvjestaj = new System.Windows.Forms.Button();
            this.OrderDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpGodina = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSviDatumi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUplate
            // 
            this.dgvUplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clan,
            this.TipClanarine,
            this.Teretana,
            this.DatumUplate,
            this.UkupanIznos});
            this.dgvUplate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvUplate.Location = new System.Drawing.Point(0, 184);
            this.dgvUplate.Name = "dgvUplate";
            this.dgvUplate.RowHeadersWidth = 51;
            this.dgvUplate.RowTemplate.Height = 24;
            this.dgvUplate.Size = new System.Drawing.Size(800, 266);
            this.dgvUplate.TabIndex = 1;
            // 
            // Clan
            // 
            this.Clan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Clan.DataPropertyName = "Clan";
            this.Clan.HeaderText = "Clan";
            this.Clan.MinimumWidth = 6;
            this.Clan.Name = "Clan";
            // 
            // TipClanarine
            // 
            this.TipClanarine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TipClanarine.DataPropertyName = "TipClanarine";
            this.TipClanarine.HeaderText = "Tip članarine";
            this.TipClanarine.MinimumWidth = 6;
            this.TipClanarine.Name = "TipClanarine";
            // 
            // Teretana
            // 
            this.Teretana.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Teretana.DataPropertyName = "Teretana";
            this.Teretana.HeaderText = "Teretana";
            this.Teretana.MinimumWidth = 6;
            this.Teretana.Name = "Teretana";
            // 
            // DatumUplate
            // 
            this.DatumUplate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumUplate.DataPropertyName = "DatumUplate";
            this.DatumUplate.HeaderText = "DatumUplate";
            this.DatumUplate.MinimumWidth = 6;
            this.DatumUplate.Name = "DatumUplate";
            // 
            // UkupanIznos
            // 
            this.UkupanIznos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UkupanIznos.DataPropertyName = "UkupanIznos";
            this.UkupanIznos.HeaderText = "Ukupan iznos";
            this.UkupanIznos.MinimumWidth = 6;
            this.UkupanIznos.Name = "UkupanIznos";
            // 
            // cmbClanovi
            // 
            this.cmbClanovi.FormattingEnabled = true;
            this.cmbClanovi.Location = new System.Drawing.Point(23, 66);
            this.cmbClanovi.Name = "cmbClanovi";
            this.cmbClanovi.Size = new System.Drawing.Size(220, 24);
            this.cmbClanovi.TabIndex = 61;
            this.cmbClanovi.SelectedIndexChanged += new System.EventHandler(this.cmbClanovi_SelectedIndexChanged);
            // 
            // btnIzvjestaj
            // 
            this.btnIzvjestaj.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnIzvjestaj.FlatAppearance.BorderSize = 0;
            this.btnIzvjestaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzvjestaj.ForeColor = System.Drawing.Color.Black;
            this.btnIzvjestaj.Location = new System.Drawing.Point(642, 119);
            this.btnIzvjestaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzvjestaj.Name = "btnIzvjestaj";
            this.btnIzvjestaj.Size = new System.Drawing.Size(120, 33);
            this.btnIzvjestaj.TabIndex = 66;
            this.btnIzvjestaj.Text = "Izvještaj";
            this.btnIzvjestaj.UseVisualStyleBackColor = false;
            this.btnIzvjestaj.Click += new System.EventHandler(this.btnIzvjestaj_Click);
            // 
            // OrderDatePicker
            // 
            this.OrderDatePicker.Location = new System.Drawing.Point(267, 68);
            this.OrderDatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.OrderDatePicker.Name = "OrderDatePicker";
            this.OrderDatePicker.Size = new System.Drawing.Size(169, 22);
            this.OrderDatePicker.TabIndex = 72;
            this.OrderDatePicker.ValueChanged += new System.EventHandler(this.OrderDatePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 73;
            this.label1.Text = "Odaberite mjesec:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "Odaberite godinu:";
            // 
            // dtpGodina
            // 
            this.dtpGodina.Location = new System.Drawing.Point(477, 68);
            this.dtpGodina.Margin = new System.Windows.Forms.Padding(4);
            this.dtpGodina.Name = "dtpGodina";
            this.dtpGodina.Size = new System.Drawing.Size(169, 22);
            this.dtpGodina.TabIndex = 75;
            this.dtpGodina.ValueChanged += new System.EventHandler(this.dtpGodina_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 76;
            this.label3.Text = "Odaberite člana:";
            // 
            // btnSviDatumi
            // 
            this.btnSviDatumi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSviDatumi.FlatAppearance.BorderSize = 0;
            this.btnSviDatumi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSviDatumi.ForeColor = System.Drawing.Color.Black;
            this.btnSviDatumi.Location = new System.Drawing.Point(514, 119);
            this.btnSviDatumi.Margin = new System.Windows.Forms.Padding(4);
            this.btnSviDatumi.Name = "btnSviDatumi";
            this.btnSviDatumi.Size = new System.Drawing.Size(120, 33);
            this.btnSviDatumi.TabIndex = 77;
            this.btnSviDatumi.Text = "Svi datumi";
            this.btnSviDatumi.UseVisualStyleBackColor = false;
            this.btnSviDatumi.Click += new System.EventHandler(this.btnSviDatumi_Click);
            // 
            // frmTeretaneUplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSviDatumi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpGodina);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrderDatePicker);
            this.Controls.Add(this.btnIzvjestaj);
            this.Controls.Add(this.cmbClanovi);
            this.Controls.Add(this.dgvUplate);
            this.Name = "frmTeretaneUplate";
            this.Text = "frmTeretaneUplate";
            this.Load += new System.EventHandler(this.frmTeretaneUplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUplate;
        private System.Windows.Forms.ComboBox cmbClanovi;
        private System.Windows.Forms.Button btnIzvjestaj;
        private System.Windows.Forms.DateTimePicker OrderDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpGodina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipClanarine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teretana;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumUplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UkupanIznos;
        private System.Windows.Forms.Button btnSviDatumi;
    }
}