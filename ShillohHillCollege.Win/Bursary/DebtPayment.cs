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
                MessageBox.Show("Kindly supply a keywor",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            var query = StudentQuery.GetStudentByKeyword(txtSearchId.Text).Result;
            var arry = query.data;
            dgDebtStudent.Rows.Clear();
            if (arry.Any())
            {
                pnOustandingPayment.Visible = true;
                foreach (var student in arry)
                {
                    dgDebtStudent.Rows.Add(student.RegistrationNo, student.FullName, student.CurrentClass);
                }
            }
            else
            {
                MessageBox.Show($"{query.description}",
                   "Information Center", MessageBoxButtons.OK);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dgDebtStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pnOustandingPayment.Visible = true;
            if (e.ColumnIndex == dgDebtStudent.Columns[3].Index)
            {
                try
                {
                    var registrationno = dgDebtStudent.CurrentRow.Cells[0].Value.ToString();
                    var studentname = dgDebtStudent.CurrentRow.Cells[1].Value.ToString();
                    var availablebalance = PaymentQuery.GetStudentCurrentBalance(registrationno);
                    if (availablebalance > 0)
                    {
                        label1.Visible = true;

                        label1.Text = $"{studentname}";
                        label11.Text = registrationno;
                        pnOustandingPayment.Visible = true;
                        txtTotalBalance.Text = availablebalance.ToString();
                    }
                    else
                    {
                        pnOustandingPayment.Visible = false;
                        label1.Visible = false;
                        MessageBox.Show("This student has no oustanding balance",
                               "information center", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtdebtRepaymentAmt.Text == "" || txtTotalBalance.Text == "")
                {
                    MessageBox.Show("Oustanding Amount/Amount to pay cannot be empty",
                           "Information Center", MessageBoxButtons.OK);
                    return;
                }

                string paymentId = $"SHS/DP/{DateTime.Now.ToString("ddMMyyHmmss")}";
                decimal amtPaid = Convert.ToDecimal(txtdebtRepaymentAmt.Text);
                decimal outstanding = Convert.ToDecimal(txtTotalBalance.Text);

                if (outstanding == 0)
                {
                    MessageBox.Show("You do not have an outstanding amount for the selected record",
                          "Information Center", MessageBoxButtons.OK);
                    return;
                }

                if (amtPaid > outstanding)
                {
                    MessageBox.Show("Amount to pay cannot be greater than outstanding amount",
                          "Information Center", MessageBoxButtons.OK);
                    return;
                }

                var studentId = label11.Text;
                var newBalance = 0.0M;
                newBalance = outstanding - amtPaid;

                PaymentCommand.AddPaymentHistory(studentId, amtPaid, newBalance, "Debt Payment", paymentId, "admin");
                PaymentCommand.UpdateStudentOutstandingBalance(studentId, newBalance);

                MessageBox.Show("Payment added successfully!",
                         "Information Center", MessageBoxButtons.OK);

                txtdebtRepaymentAmt.Text = "";
                var availablebalance = PaymentQuery.GetStudentCurrentBalance(studentId);
                txtTotalBalance.Text = availablebalance.ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Oops! Something went wrong!",
                        "Information Center", MessageBoxButtons.OK);
            }
        }
    }
}
