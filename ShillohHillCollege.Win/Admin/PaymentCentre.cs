using ShillohHillsCollege.Core.Commands;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Queries;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Admin
{
    public partial class PaymentCentre : Form
    {
       

        public PaymentCentre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLoadFees_Click(object sender, EventArgs e)
        {
                   
        }

        private void SetAcademicSessionsDrp()
        {
            //var resp = SettingsQuery.GetAcademicSession().Result;
            //if (resp.Any())
            //{
            //    drpSession.Items.Clear();
            //    resp.ForEach(p =>
            //    {
            //        drpSession.Items.Add(p.Name);
            //    });

            //}
        }


        private void SetAcademicFees()
        {
            //var resp = SettingsQuery.GetAcademicFeesByFilter(txtmySession.Text,
            //    txtmyTerm.Text, txtmyClass.Text);

            //if (resp.Any())
            //{
            //    drpAcademicFees.Items.Clear();
            //    foreach(var r in resp)
            //    {
            //        drpAcademicFees.Items.Add($"{r.FeeDescription} - {r.amount}");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No record found, pls try again",
            //             "Information Center", MessageBoxButtons.OK);
            //}
        }

        private void PaymentCentre_Load(object sender, EventArgs e)
        {
            SetAcademicSessionsDrp();
            SetAllClassesComboBox();
            var currentAcademicInfo = SettingsQuery.GetCurrentAcademicTerm();
            txtCurrSess.Text = currentAcademicInfo.Session;
            txtCurrTerm.Text = currentAcademicInfo.Term;
        }

        private void SetAllClassesComboBox()
        {
            //var collegeClasses = StudentQuery.GetCollegeClasses().Result.data;
            //foreach (var r in collegeClasses)
            //{
            //    cmbCurrentClass.Items.Add(r.Name);
            //}
        }

        private void dgAcademicFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgAcademicFees_SelectionChanged(object sender, EventArgs e)
        {
            //bool selectionFlg = dgAcademicFees.CurrentRow.Selected;

            //if (selectionFlg)
            //{
            //    var descr = dgAcademicFees.CurrentRow.Cells[0].Value.ToString();
            //    var feeAmt = dgAcademicFees.CurrentRow.Cells[1].Value.ToString();
            
            //}

        }

        private void btnMakePayment_Click(object sender, EventArgs e)
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

            if(dgAcademicFees.Rows.Count < 1)
            {
                MessageBox.Show("Kindly add record to the list",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }


            DialogResult result = MessageBox.Show("Are you sure you want to submit this payment", "Information Centre", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
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
                paymentObj.currentClass = txtMyClass.Text;
                paymentObj.session = txtCurrSess.Text;
                paymentObj.term = txtCurrTerm.Text;
                paymentObj.studentId = lblStudRegNum.Text;
                paymentObj.totalAmt = principalAmount;

                var uploadResponse = PaymentCommand.AddStudentPaymentInfo(paymentObj);
                
                if (uploadResponse.code.Equals(20))
                {
                    var outstandingBalance = PaymentQuery.GetStudentCurrentBalance(lblStudRegNum.Text);
                    var newBalance = outstandingBalance + balance;

                    PaymentCommand.AddPaymentHistory(lblStudRegNum.Text, "",
                        "", "", paidAmount, paymentObj.description);
                    PaymentCommand.UpdateStudentOutstandingBalance(lblStudRegNum.Text, newBalance);
                    insertionCount += 1;
                }
                
            }
            

            if (insertionCount > 0)
            {               
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearchParam.Text == "")
            {
                MessageBox.Show("Kindly supply Student Id",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            dgPaymentHistory.Rows.Clear();
            dgStatistics.Rows.Clear();
            SetPaymentHistory();
            SetStatistics();           
        }

        private void SetPaymentHistory()
        {
            var paymentHistoryObj = PaymentQuery.GetPaymentHistoryByStudent(txtSearchParam.Text);
            if (paymentHistoryObj.Any())
            {
                var outstandingAmt = PaymentQuery.GetStudentCurrentBalance(txtSearchParam.Text);
                txtOutstanding.Text = outstandingAmt.ToString();
                foreach (var payment in paymentHistoryObj)
                {
                    dgPaymentHistory.Rows.Add(payment.session, payment.term, payment.studentClass, payment.amountPaid, payment.dateCreated);
                }
            }
            else
            {
                MessageBox.Show("No Record found",
                       "Information Center", MessageBoxButtons.OK);
            }
        }

        private void SetStatistics()
        {
            var paymentStats = PaymentQuery.GetFeesStatisticsByStudent(txtSearchParam.Text);
            if (paymentStats.Any())
            {
                foreach (var payment in paymentStats)
                {
                    dgStatistics.Rows.Add(payment.session, payment.term, payment.currentClass,payment.totalAmount, 
                        payment.AmountPaid, payment.outstandingAmount);
                }
            }
            else
            {
                MessageBox.Show("No Record found",
                       "Information Center", MessageBoxButtons.OK);
            }
        }

        private void SetPaymentForDebt(string studentId)
        {
            var paymentStats = PaymentQuery.GetOustandingDebtById(studentId);
            if (paymentStats.Any())
            {
                foreach (var payment in paymentStats)
                {
                    dgDebtPayment.Rows.Add(payment.Id, payment.session, payment.term, payment.currentClass, payment.totalAmount,
                        payment.AmountPaid, payment.outstandingAmount);
                }
            }
            else
            {
                MessageBox.Show("No Record found",
                       "Information Center", MessageBoxButtons.OK);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
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


        private void dgDebtPayment_SelectionChanged(object sender, EventArgs e)
        {
            bool selectionFlg = dgDebtPayment.CurrentRow.Selected;

            if (selectionFlg && dgDebtPayment.Rows.Count > 0)
            {
                lblPaymentId.Text = dgDebtPayment.CurrentRow.Cells[0]?.Value.ToString();
                var selSession = dgDebtPayment.CurrentRow.Cells[1]?.Value.ToString();
                var selTerm = dgDebtPayment.CurrentRow.Cells[2]?.Value.ToString();
                var selClass = dgDebtPayment.CurrentRow.Cells[3]?.Value.ToString();
                var amountPaid = dgDebtPayment.CurrentRow.Cells[5]?.Value.ToString();
                var balance = dgDebtPayment.CurrentRow.Cells[6]?.Value.ToString();                

                txtSelectedAmount.Text = amountPaid;
                txtSelectedBalance.Text = balance;
                txtSelectedSession.Text = selSession;
                txtSelectedTerm.Text = selTerm;
                txtSelectedClass.Text = selClass;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
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
                var studentObj = label1.Text;
                var studentId = studentObj.Split('-')[1].ToString();

                if (outstanding == 0)
                {
                    MessageBox.Show("You do not have an outstanding amount for the selected record",
                          "Information Center", MessageBoxButtons.OK);
                    return;
                }

                var currentBalance = PaymentQuery.GetStudentCurrentBalance(studentId);
                var newBalance = currentBalance - creditAmt;
                PaymentCommand.AddPaymentHistory(studentId, txtSelectedSession.Text, txtSelectedTerm.Text,
                    txtSelectedClass.Text, creditAmt, "Debt Payment");
                PaymentCommand.UpdateStudentOutstandingBalance(studentId, newBalance);
                PaymentCommand.UpdateAmountPaidAfterDebt(lblPaymentId.Text, creditAmt);

                MessageBox.Show("Payment added successfully!",
                         "Information Center", MessageBoxButtons.OK);

                dgDebtPayment.Rows.Clear();
                txtDebt.Text = "";
              
                SetPaymentForDebt(studentId);
            }
            catch(Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Oops! Something went wrong!",
                        "Information Center", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtStudentId.Text == "")
            {
                MessageBox.Show("Kindly supply Registration Number",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }
            
           
        }


        private void drpAcademicFees_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAddToList_Click(object sender, EventArgs e)
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

        private void dgDebtStudent_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var registrationno = dgDebtStudent.CurrentRow.Cells[0].Value.ToString();
                var studentname = dgDebtStudent.CurrentRow.Cells[1].Value.ToString();
                var availablebalance = PaymentQuery.GetStudentCurrentBalance(registrationno);
                if (availablebalance > 0)
                {
                    label1.Text = $"{studentname} - {registrationno}";
                    label1.Visible = true;
                    dgDebtPayment.Rows.Clear();
                    pnOustandingPayment.Visible = true;
                    SetPaymentForDebt(registrationno);
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
}
