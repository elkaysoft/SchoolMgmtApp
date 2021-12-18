using ShillohHillCollege.Win.Admin;
using ShillohHillsCollege.Win.Reporting;
using System;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Admin
{
    public partial class adminDashboard : Form
    {
        public adminDashboard()
        {
            InitializeComponent();
        }

        private void adminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            var login = new Form1();
            login.Show();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var studentMgmt = new studentManagement();
            studentMgmt.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var payment = new PaymentCentre();
            payment.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var settings = new SettingsPage();
            settings.lblUsername.Text = lblUsername.Text;
            settings.ShowDialog();
        }

        private void adminDashboard_Load(object sender, EventArgs e)
        {
            //UpdateStudentClass();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var umgmt = new UserMgmt();
            umgmt.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var rptDashboard = new ReportDashboard();
            rptDashboard.ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cManagement = new changeManagement();
            cManagement.ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddFreshUser fd = new AddFreshUser();
            fd.ShowDialog();
        }
    }
}
