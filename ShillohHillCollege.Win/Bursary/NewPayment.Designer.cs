
namespace ShillohHillsCollege.Win.Bursary
{
    partial class NewPayment
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
            this.btnAddToList = new System.Windows.Forms.Button();
            this.lblCurrentClass = new System.Windows.Forms.Label();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnMakePayment = new System.Windows.Forms.Button();
            this.txtCumulative = new System.Windows.Forms.TextBox();
            this.txtAmounttoPay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgAcademicFees = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.drpTerm = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drpAcademicFees = new System.Windows.Forms.ComboBox();
            this.drpClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drpSession = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgAcademicFees)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddToList
            // 
            this.btnAddToList.BackColor = System.Drawing.Color.White;
            this.btnAddToList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddToList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddToList.Location = new System.Drawing.Point(935, 98);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(109, 29);
            this.btnAddToList.TabIndex = 47;
            this.btnAddToList.Text = "Add to List";
            this.btnAddToList.UseVisualStyleBackColor = false;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // lblCurrentClass
            // 
            this.lblCurrentClass.AutoSize = true;
            this.lblCurrentClass.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCurrentClass.Location = new System.Drawing.Point(1029, 245);
            this.lblCurrentClass.Name = "lblCurrentClass";
            this.lblCurrentClass.Size = new System.Drawing.Size(16, 25);
            this.lblCurrentClass.TabIndex = 46;
            this.lblCurrentClass.Text = ",";
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblStudentName.Location = new System.Drawing.Point(1029, 203);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(16, 25);
            this.lblStudentName.TabIndex = 45;
            this.lblStudentName.Text = ".";
            this.lblStudentName.Click += new System.EventHandler(this.lblStudentName_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Wheat;
            this.button3.Location = new System.Drawing.Point(899, 207);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 29);
            this.button3.TabIndex = 44;
            this.button3.Text = "Verify Id";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnMakePayment
            // 
            this.btnMakePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMakePayment.Location = new System.Drawing.Point(697, 341);
            this.btnMakePayment.Name = "btnMakePayment";
            this.btnMakePayment.Size = new System.Drawing.Size(136, 44);
            this.btnMakePayment.TabIndex = 43;
            this.btnMakePayment.Text = "Submit Payment";
            this.btnMakePayment.UseVisualStyleBackColor = false;
            this.btnMakePayment.Click += new System.EventHandler(this.btnMakePayment_Click);
            // 
            // txtCumulative
            // 
            this.txtCumulative.Enabled = false;
            this.txtCumulative.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCumulative.Location = new System.Drawing.Point(29, 217);
            this.txtCumulative.Name = "txtCumulative";
            this.txtCumulative.ReadOnly = true;
            this.txtCumulative.Size = new System.Drawing.Size(158, 34);
            this.txtCumulative.TabIndex = 42;
            // 
            // txtAmounttoPay
            // 
            this.txtAmounttoPay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAmounttoPay.Location = new System.Drawing.Point(935, 47);
            this.txtAmounttoPay.Name = "txtAmounttoPay";
            this.txtAmounttoPay.Size = new System.Drawing.Size(158, 34);
            this.txtAmounttoPay.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 39;
            this.label5.Text = "Grand Total";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(935, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 20);
            this.label19.TabIndex = 40;
            this.label19.Text = "Amount to Pay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(697, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Registration N&o";
            // 
            // dgAcademicFees
            // 
            this.dgAcademicFees.AllowUserToAddRows = false;
            this.dgAcademicFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAcademicFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column15});
            this.dgAcademicFees.Location = new System.Drawing.Point(227, 186);
            this.dgAcademicFees.Name = "dgAcademicFees";
            this.dgAcademicFees.RowHeadersVisible = false;
            this.dgAcademicFees.RowHeadersWidth = 51;
            this.dgAcademicFees.RowTemplate.Height = 29;
            this.dgAcademicFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAcademicFees.Size = new System.Drawing.Size(456, 199);
            this.dgAcademicFees.TabIndex = 37;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Description";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Amount";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Amount Paid";
            this.Column15.MinimumWidth = 6;
            this.Column15.Name = "Column15";
            this.Column15.Width = 125;
            // 
            // txtStudentId
            // 
            this.txtStudentId.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtStudentId.Location = new System.Drawing.Point(697, 203);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(196, 34);
            this.txtStudentId.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(230, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Term";
            // 
            // drpTerm
            // 
            this.drpTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpTerm.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.drpTerm.FormattingEnabled = true;
            this.drpTerm.Items.AddRange(new object[] {
            "FIRST",
            "SECOND",
            "THIRD"});
            this.drpTerm.Location = new System.Drawing.Point(227, 52);
            this.drpTerm.Name = "drpTerm";
            this.drpTerm.Size = new System.Drawing.Size(195, 29);
            this.drpTerm.TabIndex = 34;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label22.Location = new System.Drawing.Point(654, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(138, 20);
            this.label22.TabIndex = 33;
            this.label22.Text = "Fees Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(439, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Class";
            // 
            // drpAcademicFees
            // 
            this.drpAcademicFees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpAcademicFees.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.drpAcademicFees.FormattingEnabled = true;
            this.drpAcademicFees.Location = new System.Drawing.Point(654, 52);
            this.drpAcademicFees.Name = "drpAcademicFees";
            this.drpAcademicFees.Size = new System.Drawing.Size(264, 29);
            this.drpAcademicFees.TabIndex = 31;
            // 
            // drpClass
            // 
            this.drpClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpClass.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.drpClass.FormattingEnabled = true;
            this.drpClass.Items.AddRange(new object[] {
            "JSS 1",
            "JSS 2",
            "JSS 3",
            "SS 1",
            "SS 2",
            "SS 3"});
            this.drpClass.Location = new System.Drawing.Point(436, 52);
            this.drpClass.Name = "drpClass";
            this.drpClass.Size = new System.Drawing.Size(195, 29);
            this.drpClass.TabIndex = 30;
            this.drpClass.SelectedIndexChanged += new System.EventHandler(this.drpClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Academic Session";
            // 
            // drpSession
            // 
            this.drpSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpSession.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.drpSession.FormattingEnabled = true;
            this.drpSession.Location = new System.Drawing.Point(13, 52);
            this.drpSession.Name = "drpSession";
            this.drpSession.Size = new System.Drawing.Size(195, 29);
            this.drpSession.TabIndex = 28;
            // 
            // NewPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 458);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.lblCurrentClass);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnMakePayment);
            this.Controls.Add(this.txtCumulative);
            this.Controls.Add(this.txtAmounttoPay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgAcademicFees);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.drpTerm);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.drpAcademicFees);
            this.Controls.Add(this.drpClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drpSession);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Payment";
            this.Load += new System.EventHandler(this.NewPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAcademicFees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Label lblCurrentClass;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnMakePayment;
        private System.Windows.Forms.TextBox txtCumulative;
        private System.Windows.Forms.TextBox txtAmounttoPay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgAcademicFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drpTerm;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpAcademicFees;
        private System.Windows.Forms.ComboBox drpClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpSession;
    }
}