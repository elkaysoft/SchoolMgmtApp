
namespace ShillohHillsCollege.Win.Bursary
{
    partial class NewStudent
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtDob = new System.Windows.Forms.DateTimePicker();
            this.drpClass = new System.Windows.Forms.ComboBox();
            this.drpGender = new System.Windows.Forms.ComboBox();
            this.txtParentMobile = new System.Windows.Forms.TextBox();
            this.txtParent = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SaddleBrown;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(228, 454);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 59);
            this.button1.TabIndex = 18;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtDob
            // 
            this.dtDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDob.Location = new System.Drawing.Point(228, 171);
            this.dtDob.Name = "dtDob";
            this.dtDob.Size = new System.Drawing.Size(194, 30);
            this.dtDob.TabIndex = 16;
            // 
            // drpClass
            // 
            this.drpClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpClass.FormattingEnabled = true;
            this.drpClass.Items.AddRange(new object[] {
            "JSS 1",
            "JSS 2",
            "JSS 3",
            "SS 1",
            "SS 2",
            "SS 3"});
            this.drpClass.Location = new System.Drawing.Point(228, 248);
            this.drpClass.Name = "drpClass";
            this.drpClass.Size = new System.Drawing.Size(194, 31);
            this.drpClass.TabIndex = 14;
            // 
            // drpGender
            // 
            this.drpGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpGender.FormattingEnabled = true;
            this.drpGender.Items.AddRange(new object[] {
            "MALE",
            "FEMALE"});
            this.drpGender.Location = new System.Drawing.Point(228, 96);
            this.drpGender.Name = "drpGender";
            this.drpGender.Size = new System.Drawing.Size(194, 31);
            this.drpGender.TabIndex = 15;
            // 
            // txtParentMobile
            // 
            this.txtParentMobile.Location = new System.Drawing.Point(228, 403);
            this.txtParentMobile.Name = "txtParentMobile";
            this.txtParentMobile.Size = new System.Drawing.Size(325, 30);
            this.txtParentMobile.TabIndex = 11;
            // 
            // txtParent
            // 
            this.txtParent.Location = new System.Drawing.Point(228, 329);
            this.txtParent.Name = "txtParent";
            this.txtParent.Size = new System.Drawing.Size(392, 30);
            this.txtParent.TabIndex = 12;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(228, 26);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(392, 30);
            this.txtFName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Parent/Guardian Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Parent/Guardian Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Class";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date of Birth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Gender";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "FullName";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // NewStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 527);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtDob);
            this.Controls.Add(this.drpClass);
            this.Controls.Add(this.drpGender);
            this.Controls.Add(this.txtParentMobile);
            this.Controls.Add(this.txtParent);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Student";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtDob;
        private System.Windows.Forms.ComboBox drpClass;
        private System.Windows.Forms.ComboBox drpGender;
        private System.Windows.Forms.TextBox txtParentMobile;
        private System.Windows.Forms.TextBox txtParent;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}