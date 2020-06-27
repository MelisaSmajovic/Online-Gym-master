using Microsoft.Reporting.WinForms;
using OnlineGym_Model;
using OnlineGym_Model.Requests;
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
    public partial class frm_TeretaneUplate : Form
    {
        private Clan clan;
        private int teretana;
        private int MjesecUplate;
        private int GodinaUplate;
        private readonly APIService _clanovi = new APIService("ClanTeretana");
        private readonly APIService _uplate = new APIService("PlacanjeClanarine");
        private readonly APIService _teretane = new APIService("Teretana");
        public frm_TeretaneUplate()
        {
            InitializeComponent();
        }
        public frm_TeretaneUplate(Clan clanID,int teretanaID,int mjesec,int godina)
        {
            clan = clanID; 
            teretana = teretanaID;
            MjesecUplate = mjesec;
            GodinaUplate = godina;
            InitializeComponent();
        }

        private async void frm_TeretaneUplate_Load(object sender, EventArgs e)
        {
            Teretana teretanaFind = await _teretane.GetById<Teretana>(teretana);
            ReportParameterCollection rpc = new ReportParameterCollection();
            if (clan != null)
            {              
                rpc.Add(new ReportParameter("Clan", clan.Ime + " " + clan.Prezime));
                rpvUplate.LocalReport.SetParameters(rpc);
                                                       
            }
            else
            {             
                rpc.Add(new ReportParameter("Clan","Svi članovi"));
                rpvUplate.LocalReport.SetParameters(rpc);
            }

            rpc.Add(new ReportParameter("Teretana",teretanaFind.Naziv));
            rpvUplate.LocalReport.SetParameters(rpc);


            PlacanjeClanarineSearchRequest request = new PlacanjeClanarineSearchRequest();
            request.TeretanaId = teretana;
            if(clan!=null)
            request.ClanId = clan.ClanId;

            if (GodinaUplate != 0)
                request.GodinaUplate = GodinaUplate;
            if (MjesecUplate != 0)
                request.MjesecUplate = MjesecUplate;


            var result = await _uplate.Get<List<OnlineGym_Model.PlacanjeClanarine>>(request);

            var dgvResult = new List<OnlineGym_Model.PlacanjeClanarineRezultat>();

            foreach (var p in result)
            {
                PlacanjeClanarineRezultat temp = new PlacanjeClanarineRezultat(p);
                dgvResult.Add(temp);
                temp = null;
            }

            bsUplate.DataSource = dgvResult;

            ReportDataSource rds = new ReportDataSource("dsUplataa", bsUplate);
            this.rpvUplate.LocalReport.DataSources.Add(rds);
            this.rpvUplate.RefreshReport();
        }
    }
}
