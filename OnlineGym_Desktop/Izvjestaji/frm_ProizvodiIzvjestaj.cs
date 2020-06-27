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
    public partial class frm_ProizvodiIzvjestaj : Form
    {
        private readonly APIService _proizvodi = new APIService("Proizvod");
        public frm_ProizvodiIzvjestaj()
        {
            InitializeComponent();
        }

        private async void frm_ProizvodiIzvjestaj_Load(object sender, EventArgs e)
        {

            var result = await _proizvodi.Get<List<OnlineGym_Model.Proizvod>>(null);

            var dgvResult = new List<OnlineGym_Model.Proizvod_Rezultat>();

            foreach (var pro in result)
            {
                Proizvod_Rezultat temp = new Proizvod_Rezultat(pro);
                dgvResult.Add(temp);
                temp = null;
            }

            bsProizvodi.DataSource = dgvResult;

            ReportDataSource rds = new ReportDataSource("dsPro", bsProizvodi);
            this.rpvProizvodi.LocalReport.DataSources.Add(rds);

            this.rpvProizvodi.RefreshReport();
        }
    }
}
