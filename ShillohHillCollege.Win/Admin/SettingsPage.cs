using ShillohHillsCollege.Core.Commands;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Queries;
using ShillohHillsCollege.Core.Util;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Admin
{
    public partial class SettingsPage : Form
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(drpFeeClass.SelectedIndex == -1 || drpSession.SelectedIndex == -1 || drpTerm.SelectedIndex == -1
                || string.IsNullOrEmpty(txtAmount.Text) || string.IsNullOrEmpty(txtFeeName.Text))
            {
                MessageBox.Show("No Input field must be left empty, pls try again",
                          "Information Center", MessageBoxButtons.OK);
                return;
            }


            string session = drpSession.SelectedItem.ToString();
            string currentClass = drpFeeClass.SelectedItem.ToString();
            string currentTerm = drpTerm.SelectedItem.ToString();
            string feeName = txtFeeName.Text;
            string amount = txtAmount.Text;

            if (SettingsQuery.IsFeesExists(session, currentTerm, currentClass, feeName))
            {
                MessageBox.Show($"You have previously added this detail, pls try again",
                          "Information Center", MessageBoxButtons.OK);
            }
            else
            {
                dgFees.Rows.Add(session, currentTerm, currentClass, feeName, amount);
                txtFeeName.Clear();
                txtAmount.Clear();
            }

        }

        private void btnSubmitSession_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtSessionName.Text))
            //{
            //    MessageBox.Show("Kindly supply session name",
            //           "Information Center", MessageBoxButtons.OK);

            //    return;
            //}

            //var sessionObj = new AddSessionDto
            //{
            //    SessionName = txtSessionName.Text,
            //    submittedBy = "admin",
            //    endDate = helper.FormatDate(dtEndDate.Text),
            //    startDate = helper.FormatDate(dtStartDate.Text)
            //};

            //if (SettingsQuery.IsSessionRecordExists(txtSessionName.Text))
            //{
            //    MessageBox.Show($"Session {txtSessionName.Text} exists",
            //            "Information Center", MessageBoxButtons.OK);
            //}
            //else
            //{
            //    var resp = SettingsCommand.AddAcademicSession(sessionObj);
            //    if (resp.code.Equals(20))
            //    {
            //        txtSessionName.Clear();
            //        MessageBox.Show("Record added succesfully",
            //              "Information Center", MessageBoxButtons.OK);
            //    }
            //    else
            //    {
            //        MessageBox.Show(resp.description,
            //              "Information Center", MessageBoxButtons.OK);
            //    }
            //}          

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgFees.Rows.Count > 0)
                {
                    UploadAcademicFees();
                    dgFees.Rows.Clear();
                    MessageBox.Show("Record Addedd Successfully",
                          "Information Center", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Kindly add record to list",
                          "Information Center", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Ooops! Something went wrong",
                          "Information Center", MessageBoxButtons.OK);
            }            
        }

        private void UploadAcademicFees()
        {
            foreach(DataGridViewRow row in dgFees.Rows)
            {
                var paymentDto = new AddAcademicFeesDto();

                paymentDto.session = row.Cells[0].Value.ToString();
                paymentDto.term = row.Cells[1].Value.ToString();
                paymentDto.studentClass = row.Cells[2].Value.ToString();
                paymentDto.description = row.Cells[3].Value.ToString();
                paymentDto.amount = Convert.ToDecimal(row.Cells[4].Value.ToString());
                paymentDto.createdBy = "admin";

                PaymentCommand.AddAcademicFees(paymentDto);               
            }
        }

        private void SetAcademicSessionsDrp()
        {
            var resp = SettingsQuery.GetAcademicSession().Result;
            if (resp.Any())
            {
                drpSession.Items.Clear();
                resp.ForEach(p =>
                {
                    drpSession.Items.Add(p.Name);
                });
                
            }
        }

        private void SetCollegeClasess()
        {
            var resp = StudentQuery.GetCollegeClasses().Result;
            var allClass = resp.data;
            if (allClass != null)
            {
                dgStudentClasses.Rows.Clear();
                allClass.ForEach(p =>
                {
                    dgStudentClasses.Rows.Add(p.Name);
                });
            }
        }

        private void SetClassesDropdown()
        {
            var resp = StudentQuery.GetCollegeClasses().Result;
            var allClass = resp.data;
            if (allClass != null)
            {
                drpFeeClass.Items.Clear();
                allClass.ForEach(p =>
                {
                    drpFeeClass.Items.Add(p.Name);
                });
            }
        }

        private void SetAcademicSessionsDgView()
        {
            //var resp = SettingsQuery.GetAcademicSession().Result;
            //if (resp.Any())
            //{
            //    dgSessions.Rows.Clear();
            //    resp.ForEach(p =>
            //    {
            //        dgSessions.Rows.Add(p.Name, p.startDate.ToString("dd-MM-yyyy"), 
            //            p.endDate.ToString("dd-MM-yyyy"), p.IsActive, p.DateCreated.ToString("dd-MM-yyyy"));
            //    });

            //}
        }

        private void SetAcademicTermsDgView()
        {
            var resp = SettingsQuery.GetAcademicTerms();
            if (resp.Any())
            {
                dgViewTerm.Rows.Clear();
                
                resp.ForEach(p =>
                {
                    
                    dgViewTerm.Rows.Add(p.Id, p.Term, p.Session, (p.IsActive) ? "Active" : "Not Active", p.StartDate.ToString("dd-MM-yyyy"),
                        p.EndDate.ToString("dd-MM-yyyy"), p.Term);
                    //if (p.IsActive)
                    //{                       

                    //    dgViewTerm.CurrentRow.Cells[3].Style.BackColor = Color.White;
                    //    dgViewTerm.CurrentRow.Cells[3].Style.ForeColor = Color.Green;
                    //}
                    //else
                    //{
                    //    dgViewTerm.CurrentRow.Cells[3].Style.BackColor = Color.White;
                    //    dgViewTerm.CurrentRow.Cells[3].Style.ForeColor = Color.Red;
                    //}
                });

            }
        }


        private void SettingsPage_Load(object sender, EventArgs e)
        {
            SetAcademicSessionsDrp();
            SetAcademicSessionsDgView();
            SetAcademicTermsDgView();
            SetCollegeClasess();
            SetAllClassesBox();
            SetClassesDropdown();
            txtOldPassword.Text = GetPassword();

            txtCurrentSession.Text = StudentQuery.GetCurrentAcademicSession().Name.ToString();
            txtSessionEnd.Text = StudentQuery.GetCurrentAcademicSession().endDate.ToString("dd-MM-yyyy");
        }

        string GetPassword()
        {
            string result = "";
            var username = lblUsername.Text;

            var userInfo = AccountQuery.GetUserInfoByUsername(username);
            result = helper.DecodeFromBase64(userInfo.Password);

            return result;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you perform this action", "Information Centre", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string promptValue = Prompt.ShowPromptDialog("Enter your password", "Password Validation");

                if (promptValue.Equals("Ok"))
                {
                    StudentsCommand.MigratetudentsToAnotherClass("SS 3", "GRADUATED"); //Migrate SS 3 Students
                    StudentsCommand.MigratetudentsToAnotherClass("SS 2", "SS 3"); //Migrate SS 2 Students
                    StudentsCommand.MigratetudentsToAnotherClass("SS 1", "SS 2"); //Migrate SS 1 Students

                    StudentsCommand.MigratetudentsToAnotherClass("JSS 3", "SS 1"); //Migrate JSS 3 Students
                    StudentsCommand.MigratetudentsToAnotherClass("JSS 2", "JSS 3"); //Migrate JSS 2 Students
                    StudentsCommand.MigratetudentsToAnotherClass("JSS 1", "JSS 2"); //Migrate JSS 1 Students

                    MessageBox.Show("Students Promoted successfully!",
                                "Information Center", MessageBoxButtons.OK);
                }


            }
            else
            {
                //do nothing
            }         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtNewPassword.Text == "")
            {
                MessageBox.Show("Kindly supply new password",
                            "Information Center", MessageBoxButtons.OK);
                return;
            }
                       
            var username = lblUsername.Text;

            var updateObj = AccountCommand.UpdateUserPassword(username, helper.EncodeToBase64(txtNewPassword.Text));
            if(updateObj > 0)
            {
                txtOldPassword.Text = GetPassword();
                txtNewPassword.Text = "";
                MessageBox.Show("Password Updated Succesfully!!",
                           "Information Center", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Oops! something went wrong, pls try again later",
                           "Information Center", MessageBoxButtons.OK);
            }

        }

        private void btnCreateTerm_Click(object sender, EventArgs e)
        {
            if(txtTermSession.Text == "" || drpAcademicTerm.SelectedIndex == -1)
            {
                MessageBox.Show("Session/Term cannot be empty",
                          "Information Center", MessageBoxButtons.OK);
                return;
            }

            DateTime fromDate = Convert.ToDateTime(dtStartTerm.Text);
            DateTime endDate = Convert.ToDateTime(dtEndTerm.Text);

            if(fromDate > endDate)
            {
                MessageBox.Show("Start Date cannot be greater than End date",
                          "Information Center", MessageBoxButtons.OK);
                return;
            }


            UploadAcademicTerm();          

        }

        void UploadAcademicTerm()
        {
            var uploadObj = new AddAcademicTermDto
            {
                EndDate = helper.FormatDate(dtEndTerm.Text),
                StartDate = helper.FormatDate(dtStartTerm.Text),
                Session = txtTermSession.Text,
                Term = drpAcademicTerm.SelectedItem.ToString()
            };


            if(SettingsQuery.IsAcademicTermExists(txtTermSession.Text, drpAcademicTerm.SelectedItem.ToString()))
            {
                MessageBox.Show("Record exists, pls try again!",
                                             "Information Center", MessageBoxButtons.OK);
            }
            else
            {
                var resp = SettingsCommand.AddAcademicTerm(uploadObj);
                if (resp.code.Equals(20))
                {
                    SetAcademicTermsDgView();
                    MessageBox.Show("Record uploaded successfully!",
                                             "Information Center", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(resp.description,
                                            "Information Center", MessageBoxButtons.OK);
                }
            }            
        }

        private void dgViewTerm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dgViewTerm.Columns[3].Index)
            {
                //dgViewTerm.Columns[3]
                var Id = Convert.ToInt32(dgViewTerm.CurrentRow.Cells[0].Value.ToString());
                var sessionState = dgViewTerm.CurrentRow.Cells[3].Value.ToString();
                bool status = sessionState == "Active" ? false : true;

                if(!status && SettingsQuery.HasOneActiveTerm())
                {
                    MessageBox.Show("Click another session to deactivate this session");
                }
                else
                {
                    //SettingsCommand.DeactivateAllTerm();
                    SettingsCommand.ToggleTermStatus(Id, status);
                    SetAcademicTermsDgView();
                }
              
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(txtNewClass.Text == "")
            {
                MessageBox.Show("Kindly supply class Name",
                                            "Information Center", MessageBoxButtons.OK);
                return;
            }

            if (!StudentQuery.IsStudentClassExists(txtNewClass.Text))
            {
                var classObj = StudentsCommand.AddStudentClass(txtNewClass.Text, "admin");
                if (classObj.code.Equals(20))
                {
                    txtNewClass.Text = "";
                    MessageBox.Show("Class Successfully uploaded!!",
                                           "Information Center", MessageBoxButtons.OK);
                    SetCollegeClasess();
                }
                else
                {
                    MessageBox.Show(classObj.description,
                                            "Information Center", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Record Exists!!",
                                          "Information Center", MessageBoxButtons.OK);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dgStudentClasses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgViewTerm.Columns[1].Index)
            {                
                var clName = dgStudentClasses.CurrentRow.Cells[0].Value.ToString();

                var edclass = new EditClass();
                edclass.txtClassName.Text = clName;
                edclass.lblName.Text = clName;
                edclass.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetCollegeClasess();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SetCollegeClasess();
        }

        private void SetAllClassesBox()
        {
            //var collegeClasses = StudentQuery.GetCollegeClasses().Result.data;
            //foreach(var r in collegeClasses)
            //{
            //    chkListClasses.Items.Add(r.Name);
            //}
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            SetCollegeClasess();
        }

        //private void dgViewTerm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{

        //}
    }

    public static class Prompt
    {
        public static string ShowPromptDialog(string text, string caption)
        {
            var prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var label = new Label() { Left = 50, Top = 10, Width = 200, Text = text };
            var textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            var confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Height = 50, Top = 90, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(label);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
