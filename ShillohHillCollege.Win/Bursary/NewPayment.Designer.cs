
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
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.dgStudentLookup = new System.Windows.Forms.DataGridView();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblStudRegNum = new System.Windows.Forms.Label();
            this.lblCurrName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrTerm = new System.Windows.Forms.TextBox();
            this.txtCurrSess = new System.Windows.Forms.TextBox();
            this.pnInformation = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMakePayment = new System.Windows.Forms.Button();
            this.lblSelOutstandingAmt = new System.Windows.Forms.Label();
            this.txtMyClass = new System.Windows.Forms.TextBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.txtAmounttoPay = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dgAcademicFees = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drpAcademicFees = new System.Windows.Forms.ComboBox();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAutoPaymentId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentLookup)).BeginInit();
            this.pnInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAcademicFees)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(214, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 29);
            this.button4.TabIndex = 37;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Enter Keyword";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtStudentId.Location = new System.Drawing.Point(12, 35);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(196, 34);
            this.txtStudentId.TabIndex = 35;
            // 
            // dgStudentLookup
            // 
            this.dgStudentLookup.AllowUserToAddRows = false;
            this.dgStudentLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudentLookup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column18,
            this.Column16,
            this.Column17,
            this.Column19});
            this.dgStudentLookup.Location = new System.Drawing.Point(12, 116);
            this.dgStudentLookup.Name = "dgStudentLookup";
            this.dgStudentLookup.RowHeadersVisible = false;
            this.dgStudentLookup.RowHeadersWidth = 51;
            this.dgStudentLookup.RowTemplate.Height = 29;
            this.dgStudentLookup.Size = new System.Drawing.Size(602, 188);
            this.dgStudentLookup.TabIndex = 38;
            this.dgStudentLookup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStudentLookup_CellContentClick);
            // 
            // Column18
            // 
            this.Column18.HeaderText = "Reg No";
            this.Column18.MinimumWidth = 6;
            this.Column18.Name = "Column18";
            this.Column18.Width = 125;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "FullName";
            this.Column16.MinimumWidth = 6;
            this.Column16.Name = "Column16";
            this.Column16.Width = 170;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Current Class";
            this.Column17.MinimumWidth = 6;
            this.Column17.Name = "Column17";
            this.Column17.Width = 170;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "Pay";
            this.Column19.MinimumWidth = 6;
            this.Column19.Name = "Column19";
            this.Column19.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column19.Text = "Pay";
            this.Column19.UseColumnTextForButtonValue = true;
            this.Column19.Width = 125;
            // 
            // lblStudRegNum
            // 
            this.lblStudRegNum.AutoSize = true;
            this.lblStudRegNum.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudRegNum.Location = new System.Drawing.Point(1487, 550);
            this.lblStudRegNum.Name = "lblStudRegNum";
            this.lblStudRegNum.Size = new System.Drawing.Size(66, 31);
            this.lblStudRegNum.TabIndex = 45;
            this.lblStudRegNum.Text = "xoxo";
            this.lblStudRegNum.Visible = false;
            // 
            // lblCurrName
            // 
            this.lblCurrName.AutoSize = true;
            this.lblCurrName.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold);
            this.lblCurrName.Location = new System.Drawing.Point(751, 53);
            this.lblCurrName.Name = "lblCurrName";
            this.lblCurrName.Size = new System.Drawing.Size(38, 62);
            this.lblCurrName.TabIndex = 44;
            this.lblCurrName.Text = ".";
            this.lblCurrName.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(1317, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 20);
            this.label10.TabIndex = 42;
            this.label10.Text = "Current Term";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(1101, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "Current Session";
            // 
            // txtCurrTerm
            // 
            this.txtCurrTerm.Location = new System.Drawing.Point(1319, 28);
            this.txtCurrTerm.Name = "txtCurrTerm";
            this.txtCurrTerm.ReadOnly = true;
            this.txtCurrTerm.Size = new System.Drawing.Size(145, 27);
            this.txtCurrTerm.TabIndex = 41;
            // 
            // txtCurrSess
            // 
            this.txtCurrSess.Location = new System.Drawing.Point(1102, 28);
            this.txtCurrSess.Name = "txtCurrSess";
            this.txtCurrSess.ReadOnly = true;
            this.txtCurrSess.Size = new System.Drawing.Size(162, 27);
            this.txtCurrSess.TabIndex = 40;
            // 
            // pnInformation
            // 
            this.pnInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnInformation.Controls.Add(this.label3);
            this.pnInformation.Controls.Add(this.btnMakePayment);
            this.pnInformation.Controls.Add(this.lblSelOutstandingAmt);
            this.pnInformation.Controls.Add(this.txtMyClass);
            this.pnInformation.Controls.Add(this.btnAddToList);
            this.pnInformation.Controls.Add(this.txtAmounttoPay);
            this.pnInformation.Controls.Add(this.label19);
            this.pnInformation.Controls.Add(this.dgAcademicFees);
            this.pnInformation.Controls.Add(this.label22);
            this.pnInformation.Controls.Add(this.label2);
            this.pnInformation.Controls.Add(this.drpAcademicFees);
            this.pnInformation.Location = new System.Drawing.Point(751, 118);
            this.pnInformation.Name = "pnInformation";
            this.pnInformation.Size = new System.Drawing.Size(713, 464);
            this.pnInformation.TabIndex = 39;
            this.pnInformation.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(12, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 31);
            this.label3.TabIndex = 37;
            this.label3.Text = "Outstanding:";
            // 
            // btnMakePayment
            // 
            this.btnMakePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMakePayment.Location = new System.Drawing.Point(299, 359);
            this.btnMakePayment.Name = "btnMakePayment";
            this.btnMakePayment.Size = new System.Drawing.Size(175, 44);
            this.btnMakePayment.TabIndex = 24;
            this.btnMakePayment.Text = "Submit Payment";
            this.btnMakePayment.UseVisualStyleBackColor = false;
            this.btnMakePayment.Click += new System.EventHandler(this.btnMakePayment_Click_1);
            // 
            // lblSelOutstandingAmt
            // 
            this.lblSelOutstandingAmt.AutoSize = true;
            this.lblSelOutstandingAmt.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelOutstandingAmt.Location = new System.Drawing.Point(19, 423);
            this.lblSelOutstandingAmt.Name = "lblSelOutstandingAmt";
            this.lblSelOutstandingAmt.Size = new System.Drawing.Size(56, 28);
            this.lblSelOutstandingAmt.TabIndex = 36;
            this.lblSelOutstandingAmt.Text = "xoxo";
            // 
            // txtMyClass
            // 
            this.txtMyClass.Location = new System.Drawing.Point(21, 49);
            this.txtMyClass.Name = "txtMyClass";
            this.txtMyClass.ReadOnly = true;
            this.txtMyClass.Size = new System.Drawing.Size(177, 27);
            this.txtMyClass.TabIndex = 28;
            // 
            // btnAddToList
            // 
            this.btnAddToList.BackColor = System.Drawing.Color.White;
            this.btnAddToList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddToList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddToList.Location = new System.Drawing.Point(569, 84);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(94, 29);
            this.btnAddToList.TabIndex = 27;
            this.btnAddToList.Text = "Add to List";
            this.btnAddToList.UseVisualStyleBackColor = false;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click_1);
            // 
            // txtAmounttoPay
            // 
            this.txtAmounttoPay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtAmounttoPay.Location = new System.Drawing.Point(505, 44);
            this.txtAmounttoPay.Name = "txtAmounttoPay";
            this.txtAmounttoPay.Size = new System.Drawing.Size(158, 34);
            this.txtAmounttoPay.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(505, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 20);
            this.label19.TabIndex = 22;
            this.label19.Text = "Amount to Pay";
            // 
            // dgAcademicFees
            // 
            this.dgAcademicFees.AllowUserToAddRows = false;
            this.dgAcademicFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAcademicFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column15});
            this.dgAcademicFees.Location = new System.Drawing.Point(18, 142);
            this.dgAcademicFees.Name = "dgAcademicFees";
            this.dgAcademicFees.RowHeadersVisible = false;
            this.dgAcademicFees.RowHeadersWidth = 51;
            this.dgAcademicFees.RowTemplate.Height = 29;
            this.dgAcademicFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAcademicFees.Size = new System.Drawing.Size(480, 199);
            this.dgAcademicFees.TabIndex = 15;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label22.Location = new System.Drawing.Point(222, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(138, 20);
            this.label22.TabIndex = 9;
            this.label22.Text = "Fees Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(20, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Current Class";
            // 
            // drpAcademicFees
            // 
            this.drpAcademicFees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpAcademicFees.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold);
            this.drpAcademicFees.FormattingEnabled = true;
            this.drpAcademicFees.Location = new System.Drawing.Point(222, 49);
            this.drpAcademicFees.Name = "drpAcademicFees";
            this.drpAcademicFees.Size = new System.Drawing.Size(264, 29);
            this.drpAcademicFees.TabIndex = 8;
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
            this.Column15.Width = 150;
            // 
            // txtAutoPaymentId
            // 
            this.txtAutoPaymentId.AutoSize = true;
            this.txtAutoPaymentId.Location = new System.Drawing.Point(470, 563);
            this.txtAutoPaymentId.Name = "txtAutoPaymentId";
            this.txtAutoPaymentId.Size = new System.Drawing.Size(53, 20);
            this.txtAutoPaymentId.TabIndex = 46;
            this.txtAutoPaymentId.Text = "label1";
            this.txtAutoPaymentId.Visible = false;
            // 
            // NewPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 616);
            this.Controls.Add(this.txtAutoPaymentId);
            this.Controls.Add(this.lblStudRegNum);
            this.Controls.Add(this.lblCurrName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCurrTerm);
            this.Controls.Add(this.txtCurrSess);
            this.Controls.Add(this.pnInformation);
            this.Controls.Add(this.dgStudentLookup);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStudentId);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Payment";
            this.Load += new System.EventHandler(this.NewPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentLookup)).EndInit();
            this.pnInformation.ResumeLayout(false);
            this.pnInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAcademicFees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.DataGridView dgStudentLookup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewButtonColumn Column19;
        private System.Windows.Forms.Label lblStudRegNum;
        private System.Windows.Forms.Label lblCurrName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurrTerm;
        private System.Windows.Forms.TextBox txtCurrSess;
        private System.Windows.Forms.Panel pnInformation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMakePayment;
        private System.Windows.Forms.Label lblSelOutstandingAmt;
        private System.Windows.Forms.TextBox txtMyClass;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.TextBox txtAmounttoPay;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dgAcademicFees;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpAcademicFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.Label txtAutoPaymentId;
    }
}