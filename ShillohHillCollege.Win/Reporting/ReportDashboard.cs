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
            var rptCalendar = new ReportCalendar();
            rptCalendar.ShowDialog();
        }
    }
}
