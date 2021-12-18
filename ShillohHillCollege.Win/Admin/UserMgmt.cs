using ShillohHillsCollege.Core.Commands;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Queries;
using ShillohHillsCollege.Core.Util;
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
    public partial class UserMgmt : Form
    {
        public UserMgmt()
        {
            InitializeComponent();
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
                    LoadAllUsers();
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

        private void UserMgmt_Load(object sender, EventArgs e)
        {
            LoadAllUsers();
        }

        void LoadAllUsers()
        {
            dgUsers.Rows.Clear();
            var result = AccountQuery.GetAllUsers();
            if (result.Any())
            {
                foreach (var user in result)
                {
                    dgUsers.Rows.Add(user.Username, user.FullName, user.Gender, user.PhoneNumber,
                        user.UserType, user.DateCreated.ToString("dd-MM-yyyy"));
                }
            }
        }

        private void btnAddUser_Click_1(object sender, EventArgs e)
        {
            UploadNewUser();
        }

        private void dgUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgUsers.Columns[6].Index)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Information Centre", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var userName = dgUsers.CurrentRow.Cells[0].Value.ToString();
                    AccountCommand.DeleteUser(userName);
                    MessageBox.Show("User record deleted successfully!",
                            "Information Center", MessageBoxButtons.OK);
                    LoadAllUsers();
                }

                   
            }
        }
    }
}
