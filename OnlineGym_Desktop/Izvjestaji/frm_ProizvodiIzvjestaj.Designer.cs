namespace OnlineGym_Desktop.Izvjestaji
{
    partial class frm_ProizvodiIzvjestaj
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
            this.rpvProizvodi = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsProizvodi = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsProizvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvProizvodi
            // 
            this.rpvProizvodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvProizvodi.LocalReport.ReportEmbeddedResource = "OnlineGym_Desktop.Izvjestaji.rpt_Proizvodi.rdlc";
            this.rpvProizvodi.Location = new System.Drawing.Point(0, 0);
            this.rpvProizvodi.Name = "rpvProizvodi";
            this.rpvProizvodi.ServerReport.BearerToken = null;
            this.rpvProizvodi.Size = new System.Drawing.Size(800, 450);
            this.rpvProizvodi.TabIndex = 0;
            // 
            // frm_ProizvodiIzvjestaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvProizvodi);
            this.Name = "frm_ProizvodiIzvjestaj";
            this.Text = "frm_ProizvodiIzvjestaj";
            this.Load += new System.EventHandler(this.frm_ProizvodiIzvjestaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsProizvodi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvProizvodi;
        private System.Windows.Forms.BindingSource bsProizvodi;
    }
}