using ShillohHillsCollege.Core.Commands;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Queries;
using System;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Bursary
{
    public partial class NewStudent : Form
    {
        public NewStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var regNumber = $"SHS-{SettingsQuery.GetNextStudentRegistrationNumber()}";

                var isExists = StudentQuery.IsStudentExists(txtFName.Text,
                    drpClass.SelectedItem.ToString(), regNumber);
                if (isExists)
                {
                    MessageBox.Show($"Student with Name {txtFName.Text} is already a member of {drpClass.SelectedItem}",
                        "Information Center", MessageBoxButtons.OK);
                }
                else
                {
                    var requestObj = new AddStudentDto()
                    {
                        CreatedBy = "admin",
                        CurrentClass = drpClass.SelectedItem.ToString(),
                        DoB = dtDob.Text,
                        FullName = txtFName.Text,
                        Gender = drpGender.SelectedItem.ToString(),
                        IsDeleted = false,
                        ParentMobile = txtParentMobile.Text,
                        ParentName = txtParent.Text,
                        RegistrationNo = regNumber
                    };

                    var uploadResult = StudentsCommand.AddSingleStudent(requestObj);
                    if (uploadResult.code.Equals(20))
                    {
                        txtFName.Text = "";
                        txtParent.Text = "";
                        txtParentMobile.Text = "";
                        drpClass.SelectedIndex = -1;
                        drpGender.SelectedIndex = -1;

                        //Update the student registration pool
                        SettingsCommand.UpdateAutoRegistrationNumber();
                        MessageBox.Show($"Record saved successfully and student Registration Number is: {uploadResult.data}",
                       "Information Center", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show($"{uploadResult.description}",
                       "Information Center", MessageBoxButtons.OK);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Oops! Something went wrong, pls try again later", "Information Center", MessageBoxButtons.OK);
            }
        }
    }
}
