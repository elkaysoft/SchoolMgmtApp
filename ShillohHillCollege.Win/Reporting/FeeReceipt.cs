using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShillohHillCollege.Win.Reporting
{
    public partial class FeeReceipt : Form
    {
        public FeeReceipt()
        {
            InitializeComponent();
        }

        private void LoadReceiptInvoice()
        {
            var cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"C:\\Reporting\schoolReceipt.rpt");

            cryRpt.SetParameterValue("@paymentId", lblInvoiceId.Text);

            crConnectionInfo.ServerName = ConfigurationManager.AppSettings["AppServer"];
            crConnectionInfo.DatabaseName = ConfigurationManager.AppSettings["dbName"];
            crConnectionInfo.UserID = ConfigurationManager.AppSettings["uID"];
            crConnectionInfo.Password = ConfigurationManager.AppSettings["dbPassword"];

            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer1.ReportSource = cryRpt;

        }

        private void FeeReceipt_Load(object sender, EventArgs e)
        {
            LoadReceiptInvoice();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
