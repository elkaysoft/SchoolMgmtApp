using ShillohHillsCollege.Core.Commands;
using ShillohHillsCollege.Core.Queries;
using ShillohHillsCollege.Core.Util;
using System;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Bursary
{
    public partial class passwordChange : Form
    {
        public passwordChange()
        {
            InitializeComponent();
        }

        string GetPassword()
        {
            string result = "";
            var username = lblUsername.Text;

            var userInfo = AccountQuery.GetUserInfoByUsername(username);
            result = helper.DecodeFromBase64(userInfo.Password);

            return result;
        }

        private void passwordChange_Load(object sender, EventArgs e)
        {
            txtOldPassword.Text = GetPassword();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "")
            {
                MessageBox.Show("Kindly supply new password",
                            "Information Center", MessageBoxButtons.OK);
                return;
            }

            var username = lblUsername.Text;

            var updateObj = AccountCommand.UpdateUserPassword(username, helper.EncodeToBase64(txtNewPassword.Text));
            if (updateObj > 0)
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
    }
}
