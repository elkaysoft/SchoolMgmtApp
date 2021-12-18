
namespace ShillohHillsCollege.Win.Bursary
{
    partial class DebtPayment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearchId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgDebtStudent = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnOustandingPayment = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtdebtRepaymentAmt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalBalance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPaymentId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDebtStudent)).BeginInit();
            this.pnOustandingPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtSearchId);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(21, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Size = new System.Drawing.Size(470, 131);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record Search ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(311, 79);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSearchId
            // 
            this.txtSearchId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtSearchId.Location = new System.Drawing.Point(165, 31);
            this.txtSearchId.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtSearchId.Name = "txtSearchId";
            this.txtSearchId.Size = new System.Drawing.Size(265, 34);
            this.txtSearchId.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(24, 34);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 28);
            this.label12.TabIndex = 4;
            this.label12.Text = "Student Id";
            // 
            // dgDebtStudent
            // 
            this.dgDebtStudent.AllowUserToAddRows = false;
            this.dgDebtStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDebtStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Column6});
            this.dgDebtStudent.Location = new System.Drawing.Point(21, 247);
            this.dgDebtStudent.Name = "dgDebtStudent";
            this.dgDebtStudent.RowHeadersVisible = false;
            this.dgDebtStudent.RowHeadersWidth = 51;
            this.dgDebtStudent.RowTemplate.Height = 29;
            this.dgDebtStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgDebtStudent.Size = new System.Drawing.Size(538, 188);
            this.dgDebtStudent.TabIndex = 35;
            this.dgDebtStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDebtStudent_CellContentClick);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Reg No";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "FullName";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 170;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Current Class";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "View";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Text = "View";
            this.Column6.UseColumnTextForButtonValue = true;
            this.Column6.Width = 70;
            // 
            // pnOustandingPayment
            // 
            this.pnOustandingPayment.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnOustandingPayment.Controls.Add(this.label11);
            this.pnOustandingPayment.Controls.Add(this.txtdebtRepaymentAmt);
            this.pnOustandingPayment.Controls.Add(this.button2);
            this.pnOustandingPayment.Controls.Add(this.label1);
            this.pnOustandingPayment.Controls.Add(this.txtTotalBalance);
            this.pnOustandingPayment.Controls.Add(this.label9);
            this.pnOustandingPayment.Controls.Add(this.label7);
            this.pnOustandingPayment.Location = new System.Drawing.Point(673, 237);
            this.pnOustandingPayment.Name = "pnOustandingPayment";
            this.pnOustandingPayment.Size = new System.Drawing.Size(476, 303);
            this.pnOustandingPayment.TabIndex = 42;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(362, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 20);
            this.label11.TabIndex = 41;
            this.label11.Text = "label11";
            this.label11.Visible = false;
            // 
            // txtdebtRepaymentAmt
            // 
            this.txtdebtRepaymentAmt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdebtRepaymentAmt.Location = new System.Drawing.Point(28, 181);
            this.txtdebtRepaymentAmt.Name = "txtdebtRepaymentAmt";
            this.txtdebtRepaymentAmt.Size = new System.Drawing.Size(244, 34);
            this.txtdebtRepaymentAmt.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 41);
            this.button2.TabIndex = 40;
            this.button2.Text = "Make Payment";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(19, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 54);
            this.label1.TabIndex = 36;
            this.label1.Text = ".";
            this.label1.Visible = false;
            // 
            // txtTotalBalance
            // 
            this.txtTotalBalance.BackColor = System.Drawing.Color.SteelBlue;
            this.txtTotalBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBalance.Location = new System.Drawing.Point(28, 95);
            this.txtTotalBalance.Name = "txtTotalBalance";
            this.txtTotalBalance.ReadOnly = true;
            this.txtTotalBalance.Size = new System.Drawing.Size(313, 38);
            this.txtTotalBalance.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 23);
            this.label9.TabIndex = 38;
            this.label9.Text = "Amount to pay";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 23);
            this.label7.TabIndex = 38;
            this.label7.Text = "Outstanding Amount";
            // 
            // lblPaymentId
            // 
            this.lblPaymentId.AutoSize = true;
            this.lblPaymentId.Location = new System.Drawing.Point(46, 520);
            this.lblPaymentId.Name = "lblPaymentId";
            this.lblPaymentId.Size = new System.Drawing.Size(85, 20);
            this.lblPaymentId.TabIndex = 43;
            this.lblPaymentId.Text = "paymentId";
            this.lblPaymentId.Visible = false;
            // 
            // DebtPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1236, 606);
            this.Controls.Add(this.lblPaymentId);
            this.Controls.Add(this.pnOustandingPayment);
            this.Controls.Add(this.dgDebtStudent);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebtPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debt Payment";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDebtStudent)).EndInit();
            this.pnOustandingPayment.ResumeLayout(false);
            this.pnOustandingPayment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSearchId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgDebtStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.Panel pnOustandingPayment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtdebtRepaymentAmt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalBalance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPaymentId;
    }
}