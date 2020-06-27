namespace OnlineGym_Desktop.Narudzbe
{
    partial class frmNarudzbeDetalji
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
            this.dgvDetalji = new System.Windows.Forms.DataGridView();
            this.btnProcesiraj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelClan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labProcesirana = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            this.NarudzbaStavkaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proizvod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalji)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetalji
            // 
            this.dgvDetalji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalji.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NarudzbaStavkaId,
            this.Proizvod,
            this.Kolicina});
            this.dgvDetalji.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDetalji.Location = new System.Drawing.Point(0, 126);
            this.dgvDetalji.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDetalji.Name = "dgvDetalji";
            this.dgvDetalji.ReadOnly = true;
            this.dgvDetalji.RowHeadersWidth = 51;
            this.dgvDetalji.Size = new System.Drawing.Size(630, 251);
            this.dgvDetalji.TabIndex = 43;
            // 
            // btnProcesiraj
            // 
            this.btnProcesiraj.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnProcesiraj.FlatAppearance.BorderSize = 0;
            this.btnProcesiraj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesiraj.ForeColor = System.Drawing.Color.Black;
            this.btnProcesiraj.Location = new System.Drawing.Point(446, 76);
            this.btnProcesiraj.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcesiraj.Name = "btnProcesiraj";
            this.btnProcesiraj.Size = new System.Drawing.Size(171, 34);
            this.btnProcesiraj.TabIndex = 110;
            this.btnProcesiraj.Text = "Procesiraj narudzbu";
            this.btnProcesiraj.UseVisualStyleBackColor = false;
            this.btnProcesiraj.Visible = false;
            this.btnProcesiraj.Click += new System.EventHandler(this.btnProcesiraj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 112;
            this.label1.Text = "Ime i prezime člana:";
            // 
            // labelClan
            // 
            this.labelClan.AutoSize = true;
            this.labelClan.Location = new System.Drawing.Point(166, 41);
            this.labelClan.Name = "labelClan";
            this.labelClan.Size = new System.Drawing.Size(0, 17);
            this.labelClan.TabIndex = 113;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 114;
            this.label2.Text = "Procesirana";
            // 
            // labProcesirana
            // 
            this.labProcesirana.AutoSize = true;
            this.labProcesirana.Location = new System.Drawing.Point(464, 41);
            this.labProcesirana.Name = "labProcesirana";
            this.labProcesirana.Size = new System.Drawing.Size(0, 17);
            this.labProcesirana.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 116;
            this.label3.Text = "ID narudžbe:";
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(122, 76);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(0, 17);
            this.labID.TabIndex = 117;
            // 
            // NarudzbaStavkaId
            // 
            this.NarudzbaStavkaId.DataPropertyName = "NarudzbeStavkeId";
            this.NarudzbaStavkaId.HeaderText = "NarudzbaStavkaId";
            this.NarudzbaStavkaId.MinimumWidth = 6;
            this.NarudzbaStavkaId.Name = "NarudzbaStavkaId";
            this.NarudzbaStavkaId.ReadOnly = true;
            this.NarudzbaStavkaId.Visible = false;
            this.NarudzbaStavkaId.Width = 125;
            // 
            // Proizvod
            // 
            this.Proizvod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Proizvod.DataPropertyName = "Proizvod";
            this.Proizvod.HeaderText = "Proizvod";
            this.Proizvod.MinimumWidth = 6;
            this.Proizvod.Name = "Proizvod";
            this.Proizvod.ReadOnly = true;
            // 
            // Kolicina
            // 
            this.Kolicina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kolicina.DataPropertyName = "Kolicina";
            this.Kolicina.HeaderText = "Kolicina";
            this.Kolicina.MinimumWidth = 6;
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            // 
            // frmNarudzbeDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 377);
            this.Controls.Add(this.labID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labProcesirana);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelClan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcesiraj);
            this.Controls.Add(this.dgvDetalji);
            this.Name = "frmNarudzbeDetalji";
            this.Text = "frmNarudzbeDetalji";
            this.Load += new System.EventHandler(this.frmNarudzbeDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalji)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalji;
        private System.Windows.Forms.Button btnProcesiraj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelClan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labProcesirana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarudzbaStavkaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proizvod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina;
    }
}