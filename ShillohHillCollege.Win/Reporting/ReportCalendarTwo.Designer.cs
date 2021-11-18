
namespace ShillohHillCollege.Win.Reporting
{
    partial class ReportCalendarTwo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblReportType = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.drpFeeClass = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Location = new System.Drawing.Point(43, 171);
            this.lblReportType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(82, 20);
            this.lblReportType.TabIndex = 10;
            this.lblReportType.Text = "debtorRpt";
            this.lblReportType.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(262, 155);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Generate Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(262, 106);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(204, 27);
            this.dtEnd.TabIndex = 5;
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(11, 106);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(204, 27);
            this.dtFrom.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Class";
            // 
            // drpFeeClass
            // 
            this.drpFeeClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpFeeClass.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.drpFeeClass.FormattingEnabled = true;
            this.drpFeeClass.Location = new System.Drawing.Point(12, 41);
            this.drpFeeClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drpFeeClass.Name = "drpFeeClass";
            this.drpFeeClass.Size = new System.Drawing.Size(160, 31);
            this.drpFeeClass.TabIndex = 13;
            // 
            // ReportCalendarTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 207);
            this.Controls.Add(this.drpFeeClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReportType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtFrom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportCalendarTwo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Calendar";
            this.Load += new System.EventHandler(this.ReportCalendarTwo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpFeeClass;
    }
}