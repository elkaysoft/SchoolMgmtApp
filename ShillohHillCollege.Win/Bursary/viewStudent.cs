using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Bursary
{
    public partial class viewStudent : Form
    {
        public viewStudent()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                txtStudentName.Enabled = true;
                drpClass.Enabled = false;
                drpClass.SelectedIndex = -1;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                txtStudentName.Enabled = false;
                txtStudentName.Text = "";
                drpClass.Enabled = true;
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void SetStudentGridView(List<GetStudentDto> response)
        {
            dgStudentInfo.Rows.Clear();
            if (response.Any())
            {
                foreach (var student in response)
                {
                    dgStudentInfo.Rows.Add(student.RegistrationNo, student.FullName,
                        student.Gender, student.CurrentClass, student.DoB, student.ParentName,
                        student.ParentMobile, student.RegistrationDate);
                }
            }
        }


        private void dgStudentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dgStudentInfo.Columns[8].Index)
            //{
            //    var studentName = dgStudentInfo.CurrentRow.Cells[1].Value.ToString();
            //    var studentId = dgStudentInfo.CurrentRow.Cells[0].Value.ToString();
            //    var payHistory = new PaymentHistory();
            //    payHistory.lblStudentId.Text = studentId;
            //    payHistory.txtStudentId.Text = studentName;
            //    payHistory.Text = $"Payment history for ({studentId})";
            //    payHistory.ShowDialog();
            //}
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                var recordSearch = StudentQuery.GetStudentByKeyword(txtStudentName.Text).Result;
                if (recordSearch.code.Equals(20))
                {
                    SetStudentGridView(recordSearch.data);
                }
                else
                {
                    MessageBox.Show($"{recordSearch.description}",
                       "Information Center", MessageBoxButtons.OK);
                }
            }
            else
            {
                var selectedClass = drpClass.SelectedItem.ToString();
                var recordSearch = StudentQuery.GetStudentByClass(selectedClass).Result;
                if (recordSearch.code.Equals(20))
                {
                    SetStudentGridView(recordSearch.data);
                }
                else
                {
                    MessageBox.Show($"{recordSearch.description}",
                       "Information Center", MessageBoxButtons.OK);
                }
            }
        }
    }
}
