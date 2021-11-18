using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ShillohHillCollege.Win.Reporting;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Reporting
{
    public partial class ReportCalendar : Form
    {
        public ReportCalendar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetReportInfo();
        }

        private void AllDebtorReport()
        {
            var bulkRpt = new BulkReport();
            bulkRpt.lblStart.Text = dtFrom.Text;
            bulkRpt.lblEnd.Text = dtEnd.Text;
            bulkRpt.lblReportType.Text = lblReportType.Text;
            bulkRpt.Show();
            this.Hide();
        }

        private void AllPaymentReport()
        {
            var bulkRpt = new BulkReport();
            bulkRpt.lblStart.Text = dtFrom.Text;
            bulkRpt.lblEnd.Text = dtEnd.Text;
            bulkRpt.lblReportType.Text = lblReportType.Text;
            bulkRpt.Show();
            this.Hide();
        }

        private void SetReportInfo()
        {
            if(lblReportType.Text == "AllDebtors")
            {
                AllDebtorReport();
            }
            else if(lblReportType.Text == "AllPaymentReport")
            {
                AllPaymentReport();
            }
        }

        private void ReportCalendar_Load(object sender, EventArgs e)
        {

        }        

    }
}
