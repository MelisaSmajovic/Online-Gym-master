using Microsoft.Reporting.WinForms;
using OnlineGym_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineGym_Desktop.Izvjestaji
{
    public partial class frm_TeretaneIzvjestaj : Form
    {
        private readonly APIService _teretane = new APIService("Teretana");
        public frm_TeretaneIzvjestaj()
        {
            InitializeComponent();
        }

        private async void frm_TeretaneIzvjestaj_Load(object sender, EventArgs e)
        {
            var result = await _teretane.Get<List<OnlineGym_Model.Teretana>>(null);

            var dgvResult = new List<OnlineGym_Model.Teretana_Rezultat>();

            foreach (var ter in result)
            {
                Teretana_Rezultat temp = new Teretana_Rezultat(ter);
                dgvResult.Add(temp);
                temp = null;
            }

            bsTeretane.DataSource = dgvResult;

            ReportDataSource rds = new ReportDataSource("ds_TeretaneReport2", bsTeretane);
            this.rpvTeretane.LocalReport.DataSources.Add(rds);
            this.rpvTeretane.RefreshReport();
          
        }
    }
}
