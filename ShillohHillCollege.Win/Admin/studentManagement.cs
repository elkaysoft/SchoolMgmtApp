using System;
using System.Windows.Forms;

namespace ShillohHillsCollege.Win.Admin
{
    public partial class studentManagement : Form
    {
        public studentManagement()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var singleUpload = new RecordUpload();
            singleUpload.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var recSearch = new RecordSearch();
            recSearch.ShowDialog();
        }
    }
}
