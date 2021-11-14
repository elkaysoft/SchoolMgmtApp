using System;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Bursary
{
    public partial class bursaryDashboard : Form
    {
        public bursaryDashboard()
        {
            InitializeComponent();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newStudent = new NewStudent();
            newStudent.ShowDialog();
        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var recordSearch = new viewStudent();
            recordSearch.ShowDialog();
        }

        private void debtPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dbPayment = new DebtPayment();
            dbPayment.ShowDialog();
        }

        private void bursaryDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            var loginForm = new Form1();
            loginForm.Show();
        }

        private void makePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var makePay = new NewPayment();
            makePay.ShowDialog();
        }

        private void viewPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewPayment = new PaymentHistory();
            viewPayment.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var passChange = new passwordChange();
            passChange.lblUsername.Text = lblUsername.Text;
            passChange.ShowDialog();
        }
    }
}
