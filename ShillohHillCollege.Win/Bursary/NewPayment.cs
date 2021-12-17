using ShillohHillsCollege.Core.Commands;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Queries;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Bursary
{
    public partial class NewPayment : Form
    {
        public NewPayment()
        {
            InitializeComponent();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            var feeArr = drpAcademicFees.SelectedItem.ToString().Split('-');
            var description = feeArr[0].ToString();
            var amount = feeArr[1].ToString();
            var amountPay = txtAmounttoPay.Text;

            dgAcademicFees.Rows.Add(description, amount, amountPay);
            txtAmounttoPay.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = StudentQuery.GetSingleStudentById(txtStudentId.Text);
            if (!string.IsNullOrEmpty(result.FullName))
            {
                lblStudentName.Text = result.FullName;
                lblCurrentClass.Text = result.CurrentClass;
            }
            else
            {
                MessageBox.Show("Invalid Registration Number!",
                   "Information Center", MessageBoxButtons.OK);
            }
        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentId.Text))
            {
                MessageBox.Show("Kindly provide Student Id",
                         "Information Center", MessageBoxButtons.OK);
                return;
            }

            if (!StudentQuery.ValidatedRegistrationNumber(txtStudentId.Text))
            {
                MessageBox.Show("The supplied Student ID is not valid, pls use a valid ID",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            if (dgAcademicFees.Rows.Count < 1)
            {
                MessageBox.Show("Kindly add record to the list",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }


            DialogResult result = MessageBox.Show("Are you sure you want to submit this payment", "Information Centre", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                UploadStudentPayment();
            }
            else
            {
                //do nothing
            }
        }


        private void UploadStudentPayment()
        {
            int insertionCount = 0;

            foreach (DataGridViewRow row in dgAcademicFees.Rows)
            {
                var description = row.Cells[0].Value.ToString();
                decimal principalAmount = Convert.ToDecimal(row.Cells[1].Value.ToString());
                decimal paidAmount = Convert.ToDecimal(row.Cells[2].Value.ToString());
                decimal balance = principalAmount - paidAmount;

                var paymentObj = new AddStudentPaymentInfoDto();

                paymentObj.amtPaid = paidAmount;
                paymentObj.balance = balance;
                paymentObj.description = description;
                paymentObj.currentClass = drpClass.SelectedItem.ToString();
                paymentObj.session = drpSession.SelectedItem.ToString();
                paymentObj.term = drpTerm.SelectedItem.ToString();
                paymentObj.studentId = txtStudentId.Text;
                paymentObj.totalAmt = principalAmount;
                paymentObj.paymentId = txtAutoPaymentId.Text;

                var uploadResponse = PaymentCommand.AddStudentPaymentInfo(paymentObj);

                if (uploadResponse.code.Equals(20))
                {
                    var outstandingBalance = PaymentQuery.GetStudentCurrentBalance(txtStudentId.Text);
                    var newBalance = outstandingBalance + balance;

                    //PaymentCommand.AddPaymentHistory(txtStudentId.Text, paidAmount, paymentObj.description, txtAutoPaymentId.Text);
                    PaymentCommand.UpdateStudentOutstandingBalance(txtStudentId.Text, newBalance);
                    insertionCount += 1;
                }

            }



            if (insertionCount > 0)
            {
                ClearFields();
                MessageBox.Show("Payment Addedd Successfully!",
                    "Information Center", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Record cannot be uploaded at the moment, pls try again later",
                    "Information Center", MessageBoxButtons.OK);
            }
        }

        private void ClearFields()
        {
            drpClass.SelectedIndex = -1;
            drpSession.SelectedIndex = -1;
            drpTerm.SelectedIndex = -1;
            drpAcademicFees.SelectedIndex = -1;
            dgAcademicFees.Rows.Clear();
            txtAmounttoPay.Text = "";
            txtStudentId.Text = "";
            txtCumulative.Text = "";
            lblStudentName.Text = "";
            lblCurrentClass.Text = "";
        }

        private void lblStudentName_Click(object sender, EventArgs e)
        {

        }

        private void NewPayment_Load(object sender, EventArgs e)
        {
            SetAcademicSessionsDrp();
        }

        private void SetAcademicSessionsDrp()
        {
            var resp = SettingsQuery.GetAcademicSession().Result;
            if (resp.Any())
            {
                drpSession.Items.Clear();
                resp.ForEach(p =>
                {
                    drpSession.Items.Add(p);
                });

            }
        }

        private void drpClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpClass.SelectedIndex == -1 || drpSession.SelectedIndex == -1 || drpTerm.SelectedIndex == -1)
            {
                MessageBox.Show("No Input field must be left empty, pls try again",
                          "Information Center", MessageBoxButtons.OK);
                return;
            }

            SetAcademicFees();
        }


        private void SetAcademicFees()
        {
            var resp = SettingsQuery.GetAcademicFeesByFilter(drpSession.SelectedItem.ToString(),
                drpTerm.SelectedItem.ToString(), drpClass.SelectedItem.ToString());

            if (resp.Any())
            {
                drpAcademicFees.Items.Clear();
                foreach (var r in resp)
                {
                    drpAcademicFees.Items.Add($"{r.FeeDescription} - {r.amount}");
                }

                var cumulativeAmount = resp.Sum(x => x.amount);
                txtCumulative.Text = cumulativeAmount.ToString();
            }
            else
            {
                MessageBox.Show("No record found, pls try again",
                         "Information Center", MessageBoxButtons.OK);
            }
        }


    }
}
