using ShillohHillCollege.Win.Reporting;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Reporting
{
    public partial class ReportDashboard : Form
    {
        public ReportDashboard()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var rptCalendar = new ReportCalendar();
            rptCalendar.lblReportType.Text = "AllDebtors";
            rptCalendar.ShowDialog();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var rptCalendar = new ReportCalendar();
            rptCalendar.lblReportType.Text = "AllPaymentReport";
            rptCalendar.ShowDialog();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var rptCalendar = new ReportCalendarTwo();
            rptCalendar.lblReportType.Text = "DebtorsReportByClass";            
            rptCalendar.ShowDialog();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var rptCalendar = new ReportCalendarTwo();
            rptCalendar.lblReportType.Text = "PaymentsReportByClass";
            rptCalendar.ShowDialog();
        }
    }
}
