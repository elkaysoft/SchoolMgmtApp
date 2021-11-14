using ShillohHillsCollege.Core.Queries;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Admin
{
    public partial class PaymentHistory : Form
    {
        public PaymentHistory()
        {
            InitializeComponent();
        }

        private void PaymentHistory_Load(object sender, EventArgs e)
        {
            GetPaymentHistory();
        }

        private void GetPaymentHistory()
        {
            try
            {
                var paymentHistoryObj = PaymentQuery.GetPaymentHistoryByStudent(lblStudentId.Text);
                if (paymentHistoryObj.Any())
                {
                    foreach (var payment in paymentHistoryObj)
                    {
                        dgPaymentHistory.Rows.Add(payment.session, payment.term, payment.studentClass, payment.amountPaid, payment.description, payment.dateCreated);
                    }
                }
                else
                {
                    MessageBox.Show("No Record found",
                           "Information Center", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Oops! Something went wrong, please try again later",
                        "Information Center", MessageBoxButtons.OK);
            }
        }
    }
}
