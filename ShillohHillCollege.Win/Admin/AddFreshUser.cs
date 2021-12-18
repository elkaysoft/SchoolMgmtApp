using ShillohHillsCollege.Core.Commands;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Queries;
using ShillohHillsCollege.Core.Util;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Admin
{
    public partial class AddFreshUser : Form
    {
        public AddFreshUser()
        {
            //InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UploadNewUser();
        }

        void UploadNewUser()
        {
            if (AccountQuery.IsAccountExists(txtUsername.Text))
            {
                MessageBox.Show("Username Exists, kindly try again",
                         "Information Center", MessageBoxButtons.OK);
            }
            else
            {
                var accountObj = new LoginDto()
                {
                    CreatedBy = "admin",
                    DateCreated = DateTime.Now,
                    FullName = txtFullName.Text,
                    Gender = drpGender.SelectedItem.ToString(),
                    Password = helper.EncodeToBase64(txtPassword.Text),
                    PhoneNumber = txtMobile.Text,
                    Username = txtUsername.Text,
                    UserType = drpRole.SelectedItem.ToString()
                };

                var resp = AccountCommand.UploadUser(accountObj);
                if (resp.code.Equals(20))
                {
                    ClearTextFileds();
                    MessageBox.Show("User uploaded succesfully!",
                       "Information Center", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(resp.description,
                        "Information Center", MessageBoxButtons.OK);
                }

            }
        }

        void ClearTextFileds()
        {
            txtFullName.Text = "";
            txtMobile.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            drpGender.SelectedIndex = -1;
            drpRole.SelectedIndex = -1;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            LoadAllUsers();
        }

        void LoadAllUsers()
        {
            var result = AccountQuery.GetAllUsers();
            if (result.Any())
            {
                foreach(var user in result)
                {
                    dgUsers.Rows.Add(user.Username, user.FullName, user.Gender, user.PhoneNumber,
                        user.UserType, user.DateCreated.ToString("dd-MM-yyyy"));
                }
            }
        }
    }
}
