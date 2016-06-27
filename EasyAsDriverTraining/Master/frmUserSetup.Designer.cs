namespace EasyAsDriverTraining
{
    partial class FrmUserSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserSetup));
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btNew = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.gbNew = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewClose = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.gbNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(808, 31);
            this.lblTitle.TabIndex = 48;
            this.lblTitle.Text = "User Setup";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 472);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 58);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(25, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Name";
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(102, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(306, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(438, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(156, 31);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(638, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 31);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "Close (Esc)";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(430, 7);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(156, 31);
            this.btnDel.TabIndex = 54;
            this.btnDel.Text = "&Delete";
            this.btnDel.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(222, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(156, 31);
            this.btnEdit.TabIndex = 53;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(14, 7);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(156, 31);
            this.btNew.TabIndex = 52;
            this.btNew.Text = "&New";
            this.btNew.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 533);
            this.tableLayoutPanel1.TabIndex = 56;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btNew);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 421);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 45);
            this.panel1.TabIndex = 57;
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.Location = new System.Drawing.Point(3, 34);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgView.Size = new System.Drawing.Size(808, 381);
            this.dgView.TabIndex = 58;
            // 
            // gbNew
            // 
            this.gbNew.Controls.Add(this.label6);
            this.gbNew.Controls.Add(this.chkStatus);
            this.gbNew.Controls.Add(this.txtID);
            this.gbNew.Controls.Add(this.label4);
            this.gbNew.Controls.Add(this.txtPwd);
            this.gbNew.Controls.Add(this.label3);
            this.gbNew.Controls.Add(this.txtUserName);
            this.gbNew.Controls.Add(this.label2);
            this.gbNew.Controls.Add(this.txtUserID);
            this.gbNew.Controls.Add(this.label1);
            this.gbNew.Controls.Add(this.btnNewClose);
            this.gbNew.Controls.Add(this.btnNewSave);
            this.gbNew.Controls.Add(this.lblSubTitle);
            this.gbNew.Location = new System.Drawing.Point(155, 0);
            this.gbNew.Name = "gbNew";
            this.gbNew.Size = new System.Drawing.Size(497, 300);
            this.gbNew.TabIndex = 57;
            this.gbNew.TabStop = false;
            this.gbNew.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(81, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 85;
            this.label6.Text = "Status";
            // 
            // chkStatus
            // 
            this.chkStatus.Location = new System.Drawing.Point(189, 182);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(77, 24);
            this.chkStatus.TabIndex = 75;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Location = new System.Drawing.Point(189, 75);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(226, 20);
            this.txtID.TabIndex = 84;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(81, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 82;
            this.label4.Text = "Password";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(189, 156);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(226, 20);
            this.txtPwd.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(81, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 18);
            this.label3.TabIndex = 81;
            this.label3.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(189, 129);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(226, 20);
            this.txtUserName.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(81, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 80;
            this.label2.Text = "Login Name";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(189, 102);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(226, 20);
            this.txtUserID.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(81, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 18);
            this.label1.TabIndex = 79;
            this.label1.Text = "ID";
            // 
            // btnNewClose
            // 
            this.btnNewClose.Location = new System.Drawing.Point(256, 245);
            this.btnNewClose.Name = "btnNewClose";
            this.btnNewClose.Size = new System.Drawing.Size(156, 31);
            this.btnNewClose.TabIndex = 77;
            this.btnNewClose.Text = "Close (Esc)";
            this.btnNewClose.UseVisualStyleBackColor = false;
            // 
            // btnNewSave
            // 
            this.btnNewSave.Location = new System.Drawing.Point(68, 245);
            this.btnNewSave.Name = "btnNewSave";
            this.btnNewSave.Size = new System.Drawing.Size(156, 31);
            this.btnNewSave.TabIndex = 76;
            this.btnNewSave.Text = "Save";
            this.btnNewSave.UseVisualStyleBackColor = false;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubTitle.Location = new System.Drawing.Point(3, 16);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(491, 26);
            this.lblSubTitle.TabIndex = 78;
            this.lblSubTitle.Text = "New User Setup";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmUserSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(814, 533);
            this.Controls.Add(this.gbNew);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimizeBox = false;
            this.Name = "FrmUserSetup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code setup";
            this.Load += new System.EventHandler(this.FrmUserSetupLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.gbNew.ResumeLayout(false);
            this.gbNew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.GroupBox gbNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkStatus;
        private CustomControl.MyCombobox cbRole;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewClose;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Label lblSubTitle;

    }
}

