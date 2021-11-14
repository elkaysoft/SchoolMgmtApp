using ShillohHillsCollege.Core.Commands;
using System;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Admin
{
    public partial class EditClass : Form
    {
        public EditClass()
        {
            InitializeComponent();
        }

        private void EditClass_Load(object sender, EventArgs e)
        {
            
        }

        private void SetButton()
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SettingsCommand.DeleteClass(lblName.Text);
            this.Hide();
            //var settings = new SettingsPage();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oldName = lblName.Text;
            var resp = SettingsCommand.UpdateClass(oldName, txtClassName.Text);
            if (resp.code.Equals(20))
            {
                MessageBox.Show("Class Updated Successfully!!",
                                           "Information Center", MessageBoxButtons.OK);
                this.Hide();
            }
        }
    }
}
