namespace OnlineGym_Desktop.Izvjestaji
{
    partial class frm_TeretaneIzvjestaj
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
            this.rpvTeretane = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsTeretane = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsTeretane)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvTeretane
            // 
            this.rpvTeretane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvTeretane.LocalReport.ReportEmbeddedResource = "OnlineGym_Desktop.Izvjestaji.rptTeretane.rdlc";
            this.rpvTeretane.Location = new System.Drawing.Point(0, 0);
            this.rpvTeretane.Name = "rpvTeretane";
            this.rpvTeretane.ServerReport.BearerToken = null;
            this.rpvTeretane.Size = new System.Drawing.Size(800, 450);
            this.rpvTeretane.TabIndex = 0;
            // 
            // frm_TeretaneIzvjestaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvTeretane);
            this.Name = "frm_TeretaneIzvjestaj";
            this.Text = "frm_TeretaneIzvjestaj";
            this.Load += new System.EventHandler(this.frm_TeretaneIzvjestaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsTeretane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvTeretane;
        private System.Windows.Forms.BindingSource bsTeretane;
    }
}