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
            var bulkRpt = new BulkReport();
            bulkRpt.lblStart.Text = dtFrom.Text;
            bulkRpt.lblEnd.Text = dtEnd.Text;
        }

        private void ReportCalendar_Load(object sender, EventArgs e)
        {

        }        

    }
}
