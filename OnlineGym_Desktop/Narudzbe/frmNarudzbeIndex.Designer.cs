namespace OnlineGym_Desktop.Narudzbe
{
    partial class frmNarudzbeIndex
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
            this.btnDanas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbNeprocesirana = new System.Windows.Forms.RadioButton();
            this.rbProcesirana = new System.Windows.Forms.RadioButton();
            this.OrderDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dgvNarudzbe = new System.Windows.Forms.DataGridView();
            this.NarudzbaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Procesirana = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDetalji = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzbe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDanas
            // 
            this.btnDanas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDanas.FlatAppearance.BorderSize = 0;
            this.btnDanas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanas.ForeColor = System.Drawing.Color.Black;
            this.btnDanas.Location = new System.Drawing.Point(422, 97);
            this.btnDanas.Margin = new System.Windows.Forms.Padding(4);
            this.btnDanas.Name = "btnDanas";
            this.btnDanas.Size = new System.Drawing.Size(96, 25);
            this.btnDanas.TabIndex = 68;
            this.btnDanas.Text = "Svi datumi";
            this.btnDanas.UseVisualStyleBackColor = false;
            this.btnDanas.Click += new System.EventHandler(this.btnDanas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "Odaberi datum";
            // 
            // rbNeprocesirana
            // 
            this.rbNeprocesirana.AutoSize = true;
            this.rbNeprocesirana.Location = new System.Drawing.Point(245, 142);
            this.rbNeprocesirana.Name = "rbNeprocesirana";
            this.rbNeprocesirana.Size = new System.Drawing.Size(122, 21);
            this.rbNeprocesirana.TabIndex = 70;
            this.rbNeprocesirana.TabStop = true;
            this.rbNeprocesirana.Text = "Neprocesirana";
            this.rbNeprocesirana.UseVisualStyleBackColor = true;
            this.rbNeprocesirana.CheckedChanged += new System.EventHandler(this.rbNeprocesirana_CheckedChanged_1);
            // 
            // rbProcesirana
            // 
            this.rbProcesirana.AutoSize = true;
            this.rbProcesirana.Location = new System.Drawing.Point(134, 142);
            this.rbProcesirana.Name = "rbProcesirana";
            this.rbProcesirana.Size = new System.Drawing.Size(105, 21);
            this.rbProcesirana.TabIndex = 69;
            this.rbProcesirana.TabStop = true;
            this.rbProcesirana.Text = "Procesirana";
            this.rbProcesirana.UseVisualStyleBackColor = true;
            this.rbProcesirana.CheckedChanged += new System.EventHandler(this.rbProcesirana_CheckedChanged);
            // 
            // OrderDatePicker
            // 
            this.OrderDatePicker.Location = new System.Drawing.Point(134, 100);
            this.OrderDatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.OrderDatePicker.Name = "OrderDatePicker";
            this.OrderDatePicker.Size = new System.Drawing.Size(261, 22);
            this.OrderDatePicker.TabIndex = 71;
            this.OrderDatePicker.ValueChanged += new System.EventHandler(this.OrderDatePicker_ValueChanged);
            // 
            // dgvNarudzbe
            // 
            this.dgvNarudzbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNarudzbe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NarudzbaId,
            this.Datum,
            this.TotalPrice,
            this.Clan,
            this.Procesirana});
            this.dgvNarudzbe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNarudzbe.Location = new System.Drawing.Point(0, 242);
            this.dgvNarudzbe.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNarudzbe.Name = "dgvNarudzbe";
            this.dgvNarudzbe.ReadOnly = true;
            this.dgvNarudzbe.RowHeadersWidth = 51;
            this.dgvNarudzbe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNarudzbe.Size = new System.Drawing.Size(965, 208);
            this.dgvNarudzbe.TabIndex = 72;
            // 
            // NarudzbaId
            // 
            this.NarudzbaId.DataPropertyName = "NarudzbaId";
            this.NarudzbaId.HeaderText = "NarudzbaId";
            this.NarudzbaId.MinimumWidth = 6;
            this.NarudzbaId.Name = "NarudzbaId";
            this.NarudzbaId.ReadOnly = true;
            this.NarudzbaId.Visible = false;
            this.NarudzbaId.Width = 125;
            // 
            // Datum
            // 
            this.Datum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Datum";
            this.Datum.MinimumWidth = 6;
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalPrice.DataPropertyName = "BrojNarudzbe";
            this.TotalPrice.HeaderText = "Broj narudzbe";
            this.TotalPrice.MinimumWidth = 6;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            // 
            // Clan
            // 
            this.Clan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Clan.DataPropertyName = "Clan";
            this.Clan.HeaderText = "Clan";
            this.Clan.MinimumWidth = 6;
            this.Clan.Name = "Clan";
            this.Clan.ReadOnly = true;
            // 
            // Procesirana
            // 
            this.Procesirana.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Procesirana.DataPropertyName = "Procesirana";
            this.Procesirana.FalseValue = "false";
            this.Procesirana.HeaderText = "Procesirana";
            this.Procesirana.MinimumWidth = 6;
            this.Procesirana.Name = "Procesirana";
            this.Procesirana.ReadOnly = true;
            this.Procesirana.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Procesirana.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Procesirana.TrueValue = "true";
            // 
            // btnDetalji
            // 
            this.btnDetalji.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDetalji.FlatAppearance.BorderSize = 0;
            this.btnDetalji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalji.ForeColor = System.Drawing.Color.Black;
            this.btnDetalji.Location = new System.Drawing.Point(790, 95);
            this.btnDetalji.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(117, 37);
            this.btnDetalji.TabIndex = 73;
            this.btnDetalji.Text = "Detalji";
            this.btnDetalji.UseVisualStyleBackColor = false;
            this.btnDetalji.Click += new System.EventHandler(this.btnDetalji_Click);
            // 
            // frmNarudzbeIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 450);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.dgvNarudzbe);
            this.Controls.Add(this.OrderDatePicker);
            this.Controls.Add(this.rbNeprocesirana);
            this.Controls.Add(this.rbProcesirana);
            this.Controls.Add(this.btnDanas);
            this.Controls.Add(this.label3);
            this.Name = "frmNarudzbeIndex";
            this.Text = "frmNarudzbeIndex";
            this.Load += new System.EventHandler(this.frmNarudzbeIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzbe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDanas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbNeprocesirana;
        private System.Windows.Forms.RadioButton rbProcesirana;
        private System.Windows.Forms.DateTimePicker OrderDatePicker;
        private System.Windows.Forms.DataGridView dgvNarudzbe;
        private System.Windows.Forms.Button btnDetalji;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarudzbaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Procesirana;
    }
}