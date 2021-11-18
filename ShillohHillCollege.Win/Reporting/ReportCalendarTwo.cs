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

namespace ShillohHillCollege.Win.Reporting
{
    public partial class ReportCalendarTwo : Form
    {
        public ReportCalendarTwo()
        {
            InitializeComponent();
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

        private void ReportCalendarTwo_Load(object sender, EventArgs e)
        {
            SetClassesDropdown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetReportInfo();
        }

        private void AllDebtorReport()
        {
            var bulkRpt = new BulkReport();
            bulkRpt.lblStart.Text = dtFrom.Text;
            bulkRpt.lblEnd.Text = dtEnd.Text;
            bulkRpt.lblReportType.Text = lblReportType.Text;
            bulkRpt.lblClassName.Text = drpFeeClass.SelectedItem.ToString();
            bulkRpt.Show();
            this.Hide();
        }

        private void AllPaymentReport()
        {
            var bulkRpt = new BulkReport();
            bulkRpt.lblStart.Text = dtFrom.Text;
            bulkRpt.lblEnd.Text = dtEnd.Text;
            bulkRpt.lblReportType.Text = lblReportType.Text;
            bulkRpt.lblClassName.Text = drpFeeClass.SelectedItem.ToString();
            bulkRpt.Show();
            this.Hide();
        }

        private void SetReportInfo()
        {
            if (lblReportType.Text == "DebtorsReportByClass")
            {
                AllDebtorReport();
            }
            else if (lblReportType.Text == "PaymentsReportByClass")
            {
                AllPaymentReport();
            }
        }


    }
}
