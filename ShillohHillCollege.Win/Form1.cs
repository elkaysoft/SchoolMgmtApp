using ShillohHillsCollege.Core.Queries;
using ShillohHillsCollege.Core.Util;
using ShillohHillsCollege.Win.Admin;
using ShillohHillsCollege.Win.Bursary;
using System;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Username/Password cannot be empty",
                        "Information Center", MessageBoxButtons.OK);
                return;
            }

            var result = AccountQuery.CanLogin(txtUsername.Text, helper.EncodeToBase64(txtPassword.Text)).Result;

            if (result.code.Equals(20))
            {
                var userInfo = AccountQuery.GetUserInfoByUsername(txtUsername.Text);
                if(userInfo.UserType.ToLower() == "administrator")
                {
                    var dashboard = new adminDashboard();
                    dashboard.lblFName.Text = $"{ userInfo.FullName},";
                    dashboard.lblUsername.Text = userInfo.Username;
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    var bdashboard = new bursaryDashboard();
                    bdashboard.lblUsername.Text = userInfo.Username;
                    bdashboard.Show();
                    this.Hide();
                }
                
            }
            else
            {
                MessageBox.Show(result.description, "Information Box");
            }           

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
