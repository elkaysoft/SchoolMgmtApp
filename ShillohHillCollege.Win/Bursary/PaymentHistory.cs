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
            var query = StudentQuery.GetStudentByKeyword(txtSearchParam.Text).Result;
            var arry = query.data;
            dgHistorylookup.Rows.Clear();
            if (arry.Any())
            {
                foreach (var student in arry)
                {
                    dgHistorylookup.Rows.Add(student.RegistrationNo, student.FullName, student.CurrentClass);
                }
            }
            else
            {
                MessageBox.Show($"{query.description}",
                   "Information Center", MessageBoxButtons.OK);
            }          
        }

        private void dgHistorylookup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgHistorylookup.Columns[3].Index)
            {
                var registrationNo = dgHistorylookup.CurrentRow.Cells[0].Value.ToString();
                dgStatistics.Rows.Clear();
                dgStatistics.Visible = true;
                SetPaymentHistory(registrationNo);
            }
        }

        private void SetPaymentHistory(string studentId)
        {
            var paymentHistoryObj = PaymentQuery.GetPaymentHistoryByStudent(studentId);
            if (paymentHistoryObj.Any())
            {
                foreach (var payment in paymentHistoryObj)
                {
                    dgStatistics.Rows.Add(payment.paymentId, payment.description, payment.amountPaid, payment.outstandingAmount, payment.dateCreated);
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
