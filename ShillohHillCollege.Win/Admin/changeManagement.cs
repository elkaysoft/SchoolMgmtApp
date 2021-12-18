using ShillohHillsCollege.Core.Commands;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShillohHillCollege.Win.Admin
{
    public partial class changeManagement : Form
    {
        public changeManagement()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearchUd.Text == "")
            {
                MessageBox.Show("Kindly supply Student Id",
                    "Information Center", MessageBoxButtons.OK);
                return;
            }

            var studentObj = StudentQuery.GetSingleStudentById(txtSearchUd.Text);
            if(studentObj.FullName != null)
            {
                txtFName.Text = studentObj.FullName;
                txtKlass.Text = studentObj.CurrentClass;
                txtParentName.Text = studentObj.ParentName;
                txtParentNo.Text = studentObj.ParentMobile;
                cmbGender.SelectedItem = studentObj.Gender;
                dtDoB.Text = studentObj.DoB;
            }
            else
            {
                MessageBox.Show("Invalid Student Id supplied, pls retry",
                    "Information Center", MessageBoxButtons.OK);
            }
        }

        private void GetStudentRecord(string studentId)
        {
            var studentObj = StudentQuery.GetSingleStudentById(studentId);
            if (studentObj.FullName != null)
            {
                txtFName.Text = studentObj.FullName;
                txtKlass.Text = studentObj.CurrentClass;
                txtParentName.Text = studentObj.ParentName;
                txtParentNo.Text = studentObj.ParentMobile;
                cmbGender.SelectedItem = studentObj.Gender;
                dtDoB.Text = studentObj.DoB;
            }
            else
            {
                MessageBox.Show("Invalid Student Id supplied, pls retry",
                    "Information Center", MessageBoxButtons.OK);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSearchUd.Text == "")
            {
                MessageBox.Show("Kindly supply Student Id",
                    "Information Center", MessageBoxButtons.OK);
                return;
            }

            if(txtFName.Text == "" || txtKlass.Text == "" || txtParentName.Text == "" || cmbGender.SelectedItem == null 
                || txtParentNo.Text == "")
            {
                MessageBox.Show("No field must be left empty",
                    "Information Center", MessageBoxButtons.OK);
                return;
            }

            var updateObj = new UpdateStudentDto
            {
                CurrentClass = txtKlass.Text,
                DoB = dtDoB.Text,
                FullName = txtFName.Text,
                ParentName = txtParentName.Text,
                Gender = cmbGender.SelectedItem.ToString(),
                ParentMobile = txtParentNo.Text,
                studentId = txtSearchUd.Text
            };

            StudentsCommand.UpdateStudentInfo(updateObj);
            MessageBox.Show("Record Updated Successfully!!",
                   "Information Center", MessageBoxButtons.OK);

            GetStudentRecord(txtSearchUd.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSearchUd.Text == "")
            {
                MessageBox.Show("Kindly supply Student Id",
                    "Information Center", MessageBoxButtons.OK);
                return;
            }

            StudentsCommand.DeleteStudent(txtSearchUd.Text);
            MessageBox.Show("Record Deleted Successfully!!",
                   "Information Center", MessageBoxButtons.OK);
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            txtFName.Text = "";
            txtParentName.Text = string.Empty;
            txtParentName.Text = string.Empty;
            txtParentNo.Text = string.Empty;
            cmbGender.SelectedIndex = 0;
        }

        private void btnSearchPayment_Click(object sender, EventArgs e)
        {
            if (txtPaymentId.Text == "")
            {
                MessageBox.Show("Kindly supply Payment Id",
                    "Information Center", MessageBoxButtons.OK);
                return;
            }

            GetStudentPaymentInfo(txtPaymentId.Text);
        }

        private void GetStudentPaymentInfo(string paymentId)
        {
            var paymentObj = PaymentQuery.GetPaymentsByPaymentId(paymentId);

            dgPayments.Rows.Clear();
            if (paymentObj != null)
            {
                btnUpdatePayment.Enabled = true;
                foreach(var p in paymentObj)
                {
                    dgPayments.Rows.Add(p.Id, p.description, p.currentClass, p.term, p.totalAmount, p.AmountPaid, p.outstandingAmount);
                }
            }
            
        }
               

        private void dgPayments_SelectionChanged_1(object sender, EventArgs e)
        {
            bool selectionFlg = dgPayments.CurrentRow.Selected;

            if (selectionFlg && dgPayments.Rows.Count > 0)
            {
                var amtPaid = Convert.ToDecimal(dgPayments.CurrentRow.Cells[5].Value);
                var Id = Convert.ToInt32(dgPayments.CurrentRow.Cells[0].Value);

                txtAmountPaid.Text = amtPaid.ToString();
                lblPaymentId.Text = Id.ToString();
            }
        }

        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            if (txtPaymentId.Text == "")
            {
                MessageBox.Show("Kindly supply a payment Id",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            if (txtAmountPaid.Text == "")
            {
                MessageBox.Show("Kindly supply amount to paid",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            decimal amtPaid = Convert.ToDecimal(txtAmountPaid.Text);
            if (amtPaid == 0)
            {
                MessageBox.Show("Kindly supply a valid amount to update",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            var totalAmount = Convert.ToDecimal(dgPayments.CurrentRow.Cells[4].Value);
            int requestId = Convert.ToInt32(dgPayments.CurrentRow.Cells[0].Value);

            if(amtPaid > totalAmount)
            {
                MessageBox.Show("Amount to update cannot be greater than total amount",
                         "Information Center", MessageBoxButtons.OK);
                return;
            }

            var outstandingBal = totalAmount - amtPaid;
            PaymentCommand.UpdateStudentPaymentById(requestId, amtPaid, outstandingBal);
            MessageBox.Show("Payment updated successfully!",
                        "Information Center", MessageBoxButtons.OK);
            GetStudentPaymentInfo(txtPaymentId.Text);
        }
    }
}
