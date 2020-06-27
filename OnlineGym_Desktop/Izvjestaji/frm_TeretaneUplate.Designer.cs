namespace OnlineGym_Desktop.Izvjestaji
{
    partial class frm_TeretaneUplate
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
            this.rpvUplate = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bsUplate = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsUplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvUplate
            // 
            this.rpvUplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvUplate.LocalReport.ReportEmbeddedResource = "OnlineGym_Desktop.Izvjestaji.rptTeretanaUplate.rdlc";
            this.rpvUplate.Location = new System.Drawing.Point(0, 0);
            this.rpvUplate.Name = "rpvUplate";
            this.rpvUplate.ServerReport.BearerToken = null;
            this.rpvUplate.Size = new System.Drawing.Size(800, 450);
            this.rpvUplate.TabIndex = 0;
          
            // 
            // frm_TeretaneUplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvUplate);
            this.Name = "frm_TeretaneUplate";
            this.Text = "frm_TeretaneUplate";
            this.Load += new System.EventHandler(this.frm_TeretaneUplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsUplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvUplate;
        private System.Windows.Forms.BindingSource bsUplate;
    }
}