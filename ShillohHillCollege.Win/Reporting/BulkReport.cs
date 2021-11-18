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
    public partial class BulkReport : Form
    {
        public BulkReport()
        {
            InitializeComponent();
        }

        

        private void LoadAllDebtorReport()
        {
            var cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"C:\\Reporting\AllDebtorReport.rpt");

            cryRpt.SetParameterValue("@BeginDate", lblStart.Text);
            cryRpt.SetParameterValue("@EndDate", lblEnd.Text);

            crConnectionInfo.ServerName = ConfigurationManager.AppSettings["AppServer"];
            crConnectionInfo.DatabaseName = ConfigurationManager.AppSettings["dbName"];
            crConnectionInfo.UserID = ConfigurationManager.AppSettings["uID"];
            crConnectionInfo.Password = ConfigurationManager.AppSettings["dbPassword"];

            CrTables = cryRpt.Database.Tables;
            foreach (Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer1.ReportSource = cryRpt;

        }
        
        private void LoadAllPaymentReport()
        {
            var cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"C:\\Reporting\AllPaymentReport.rpt");

            cryRpt.SetParameterValue("@beginDate", lblStart.Text);
            cryRpt.SetParameterValue("@endDate", lblEnd.Text);

            crConnectionInfo.ServerName = ConfigurationManager.AppSettings["AppServer"];
            crConnectionInfo.DatabaseName = ConfigurationManager.AppSettings["dbName"];
            crConnectionInfo.UserID = ConfigurationManager.AppSettings["uID"];
            crConnectionInfo.Password = ConfigurationManager.AppSettings["dbPassword"];

            CrTables = cryRpt.Database.Tables;
            foreach (Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer1.ReportSource = cryRpt;

        }

        private void LoadDebtorReportByClass()
        {
            var cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"C:\\Reporting\DebtorReportByClass.rpt");

            cryRpt.SetParameterValue("@beginDate", lblStart.Text);
            cryRpt.SetParameterValue("@endDate", lblEnd.Text);
            cryRpt.SetParameterValue("@className", lblClassName.Text);

            crConnectionInfo.ServerName = ConfigurationManager.AppSettings["AppServer"];
            crConnectionInfo.DatabaseName = ConfigurationManager.AppSettings["dbName"];
            crConnectionInfo.UserID = ConfigurationManager.AppSettings["uID"];
            crConnectionInfo.Password = ConfigurationManager.AppSettings["dbPassword"];

            CrTables = cryRpt.Database.Tables;
            foreach (Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer1.ReportSource = cryRpt;

        }

        private void LoadPaymentReportByClass()
        {
            var cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"C:\\Reporting\PaymentReportByClass.rpt");

            cryRpt.SetParameterValue("@beginDate", lblStart.Text);
            cryRpt.SetParameterValue("@endDate", lblEnd.Text);
            cryRpt.SetParameterValue("@className", lblClassName.Text);

            crConnectionInfo.ServerName = ConfigurationManager.AppSettings["AppServer"];
            crConnectionInfo.DatabaseName = ConfigurationManager.AppSettings["dbName"];
            crConnectionInfo.UserID = ConfigurationManager.AppSettings["uID"];
            crConnectionInfo.Password = ConfigurationManager.AppSettings["dbPassword"];

            CrTables = cryRpt.Database.Tables;
            foreach (Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer1.ReportSource = cryRpt;

        }




        private void BulkReport_Load(object sender, EventArgs e)
        {
            if(lblReportType.Text == "AllDebtors")
            {
                LoadAllDebtorReport();
            }
            else if (lblReportType.Text == "AllPaymentReport")
            {
                LoadAllPaymentReport();
            }
            else if (lblReportType.Text == "DebtorsReportByClass")
            {
                LoadDebtorReportByClass();
            }
            else if (lblReportType.Text == "PaymentsReportByClass")
            {
                LoadPaymentReportByClass();
            }
        }


    }
}
