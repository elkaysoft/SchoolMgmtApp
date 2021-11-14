using ShillohHillsCollege.Core.Queries;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Bursary
{
    public partial class PaymentHistory : Form
    {
        public PaymentHistory()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchParam.Text == "")
            {
                MessageBox.Show("Kindly supply Student Id",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            dgStatistics.Rows.Clear();
            SetStatistics();
        }

        private void SetStatistics()
        {
            var paymentStats = PaymentQuery.GetFeesStatisticsByStudent(txtSearchParam.Text);
            if (paymentStats.Any())
            {
                foreach (var payment in paymentStats)
                {
                    dgStatistics.Rows.Add(payment.session, payment.term, payment.currentClass, payment.totalAmount,
                        payment.AmountPaid, payment.outstandingAmount);
                }
            }
            else
            {
                MessageBox.Show("No Record found",
                       "Information Center", MessageBoxButtons.OK);
            }
        }


    }
}
