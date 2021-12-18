using ShillohHillCollege.Win.Reporting;
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

        //$"PID-{SettingsQuery.GetNextPaymentId()}";
              

        private void lblStudentName_Click(object sender, EventArgs e)
        {

        }

        private void NewPayment_Load(object sender, EventArgs e)
        {
            var currentAcademicInfo = SettingsQuery.GetCurrentAcademicTerm();
            txtCurrSess.Text = currentAcademicInfo.Session;
            txtCurrTerm.Text = currentAcademicInfo.Term;
        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = StudentQuery.GetStudentByKeyword(txtStudentId.Text).Result;
            var arry = query.data;
            dgStudentLookup.Rows.Clear();
            if (arry.Any())
            {
                foreach (var student in arry)
                {
                    dgStudentLookup.Rows.Add(student.RegistrationNo, student.FullName, student.CurrentClass);
                }
            }
            else
            {
                MessageBox.Show($"{query.description}",
                   "Information Center", MessageBoxButtons.OK);
            }
        }

        private void dgStudentLookup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgStudentLookup.Columns[3].Index)
            {
                var registrationNo = dgStudentLookup.CurrentRow.Cells[0].Value.ToString();

                var result = StudentQuery.GetSingleStudentById(registrationNo);
                if (!string.IsNullOrEmpty(result.FullName))
                {
                    pnInformation.Visible = true;
                    lblCurrName.Visible = true;
                    string currClass = result.CurrentClass;
                    lblCurrName.Text = result.FullName;
                    txtMyClass.Text = currClass;
                    lblStudRegNum.Text = result.RegistrationNo;
                    lblSelOutstandingAmt.Text = result.OutstandingBalance.ToString();

                    var academicFees = SettingsQuery.GetAcademicFeesByFilter(txtCurrSess.Text, txtCurrTerm.Text, currClass);
                    if (academicFees.Any())
                    {
                        foreach (var pp in academicFees)
                        {
                            drpAcademicFees.Items.Add($"{pp.FeeDescription} - {pp.amount}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Registration Number!",
                       "Information Center", MessageBoxButtons.OK);
                }
            }
        }

        private void btnAddToList_Click_1(object sender, EventArgs e)
        {
            if (drpAcademicFees.SelectedIndex == -1 || txtAmounttoPay.Text == "")
            {
                MessageBox.Show("Kindly supply Academic fee",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            AddRecordToList();
        }

        private void AddRecordToList()
        {
            var feeArr = drpAcademicFees.SelectedItem.ToString().Split('-');
            var description = feeArr[0].ToString();
            var amount = feeArr[1].ToString();
            var amountPay = txtAmounttoPay.Text;

            foreach (DataGridViewRow row in dgAcademicFees.Rows)
            {
                var existingColumn = row.Cells[0].Value.ToString();

                if (existingColumn == description)
                {
                    MessageBox.Show("Record already added to the list",
                         "Information Center", MessageBoxButtons.OK);
                    return;
                }
            }

            dgAcademicFees.Rows.Add(description, amount, amountPay);
            txtAmounttoPay.Text = "";
        }

        private void btnMakePayment_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblStudRegNum.Text))
            {
                MessageBox.Show("Kindly provide Student Id",
                         "Information Center", MessageBoxButtons.OK);
                return;
            }

            if (!StudentQuery.ValidatedRegistrationNumber(lblStudRegNum.Text))
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
                string pId = txtAutoPaymentId.Text;
                UploadStudentPayment();
                SettingsCommand.UpdateAutoPaymentId();
                lblCurrName.Visible = false;

                var receipt = new FeeReceipt();
                receipt.lblInvoiceId.Text = pId;
                receipt.Show();
                this.Hide();
            }
            else
            {
                //do nothing
            }
        }

        private void UploadStudentPayment()
        {
            int insertionCount = 0;
            decimal totalBal = 0;
            decimal totalPaid = 0;

            foreach (DataGridViewRow row in dgAcademicFees.Rows)
            {
                var description = row.Cells[0].Value.ToString();
                decimal principalAmount = Convert.ToDecimal(row.Cells[1].Value.ToString());
                decimal paidAmount = Convert.ToDecimal(row.Cells[2].Value.ToString());
                decimal balance = principalAmount - paidAmount;

                totalPaid += paidAmount;
                totalBal += balance;

                var paymentObj = new AddStudentPaymentInfoDto();

                paymentObj.amtPaid = paidAmount;
                paymentObj.balance = balance;
                paymentObj.description = description;
                paymentObj.currentClass = txtMyClass.Text;
                paymentObj.session = txtCurrSess.Text;
                paymentObj.term = txtCurrTerm.Text;
                paymentObj.studentId = lblStudRegNum.Text;
                paymentObj.totalAmt = principalAmount;
                paymentObj.paymentId = txtAutoPaymentId.Text;

                var uploadResponse = PaymentCommand.AddStudentPaymentInfo(paymentObj);

                if (uploadResponse.code.Equals(20))
                {
                    var outstandingBalance = PaymentQuery.GetStudentCurrentBalance(lblStudRegNum.Text);
                    var newBalance = outstandingBalance + balance;

                    PaymentCommand.UpdateStudentOutstandingBalance(lblStudRegNum.Text, newBalance);
                    insertionCount += 1;
                }
            }


            if (insertionCount > 0)
            {
                PaymentCommand.AddPaymentHistory(lblStudRegNum.Text, totalPaid, totalBal, "Initial Payment", txtAutoPaymentId.Text, "admin");

                ClearFieldsForNewPayment();
                MessageBox.Show("Payment Addedd Successfully!",
                    "Information Center", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Record cannot be uploaded at the moment, pls try again later",
                    "Information Center", MessageBoxButtons.OK);
            }
        }

        private void ClearFieldsForNewPayment()
        {
            dgAcademicFees.Rows.Clear();
            dgStudentLookup.Rows.Clear();
            drpAcademicFees.Items.Clear();
            pnInformation.Visible = false;
            txtMyClass.Text = "";
            txtAmounttoPay.Text = "";
            txtStudentId.Text = "";
        }

    }
}
