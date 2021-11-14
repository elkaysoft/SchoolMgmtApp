using ShillohHillsCollege.Core.Commands;
using ShillohHillsCollege.Core.Queries;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Bursary
{
    public partial class DebtPayment : Form
    {
        public DebtPayment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSearchId.Text == "")
            {
                MessageBox.Show("Kindly supply Student Id",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            dgDebtPayment.Rows.Clear();
            SetPaymentForDebt();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }


        private void SetPaymentForDebt()
        {
            var paymentStats = PaymentQuery.GetFeesStatisticsByStudent(txtSearchId.Text);
            if (paymentStats.Any())
            {
                foreach (var payment in paymentStats)
                {
                    dgDebtPayment.Rows.Add(payment.session, payment.term, payment.currentClass, payment.totalAmount,
                        payment.AmountPaid, payment.outstandingAmount, payment.CreatedOn.ToString("dd-MM-yyyy"));
                }
            }
            else
            {
                MessageBox.Show("No Record found",
                       "Information Center", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtSelectedBalance.Text == "" || txtSelectedAmount.Text == "" || txtDebt.Text == "")
            {
                MessageBox.Show("Oustanding Amount/Amount Paid cannot be empty",
                       "Information Center", MessageBoxButtons.OK);
                return;
            }

            decimal amtPaid = Convert.ToDecimal(txtSelectedAmount.Text);
            decimal outstanding = Convert.ToDecimal(txtSelectedBalance.Text);
            decimal creditAmt = Convert.ToDecimal(txtDebt.Text);

            if (outstanding == 0)
            {
                MessageBox.Show("You do not have an outstanding amount for the selected record",
                      "Information Center", MessageBoxButtons.OK);
                return;
            }

            var currentBalance = PaymentQuery.GetStudentCurrentBalance(txtSearchId.Text);
            var newBalance = currentBalance - creditAmt;
            PaymentCommand.AddPaymentHistory(txtSearchId.Text, txtSelectedSession.Text, txtSelectedTerm.Text,
                txtSelectedClass.Text, creditAmt, "Debt Payment");
            PaymentCommand.UpdateStudentOutstandingBalance(txtSearchId.Text, newBalance);
            //PaymentCommand.UpdateAmountPaidAfterDebt(txtSearchId.Text, txtSelectedSession.Text, txtSelectedTerm.Text,
            //    txtSelectedClass.Text, creditAmt);

            MessageBox.Show("Payment added successfully!",
                     "Information Center", MessageBoxButtons.OK);

            dgDebtPayment.Rows.Clear();
            txtDebt.Text = "";
            SetPaymentForDebt();
        }
    }
}
