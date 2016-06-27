namespace EasyAsDriverTraining
{
    partial class frmListing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListing));
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSuburbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btNew = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.gbNew = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrainer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSuburb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewClose = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTrainerSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQualification = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTransmission = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRegNo = new System.Windows.Forms.TextBox();
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
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTrainerSearch);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSuburbSearch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 496);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 97);
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
            this.label8.Text = "Suburb";
            // 
            // txtSuburbSearch
            // 
            this.txtSuburbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSuburbSearch.Location = new System.Drawing.Point(102, 25);
            this.txtSuburbSearch.Name = "txtSuburbSearch";
            this.txtSuburbSearch.Size = new System.Drawing.Size(306, 20);
            this.txtSuburbSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(430, 53);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 596);
            this.tableLayoutPanel1.TabIndex = 56;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btNew);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 48);
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
            this.dgView.Size = new System.Drawing.Size(808, 402);
            this.dgView.TabIndex = 58;
            // 
            // gbNew
            // 
            this.gbNew.Controls.Add(this.label9);
            this.gbNew.Controls.Add(this.txtArea);
            this.gbNew.Controls.Add(this.label10);
            this.gbNew.Controls.Add(this.txtRegNo);
            this.gbNew.Controls.Add(this.label7);
            this.gbNew.Controls.Add(this.txtModel);
            this.gbNew.Controls.Add(this.label6);
            this.gbNew.Controls.Add(this.txtTransmission);
            this.gbNew.Controls.Add(this.label4);
            this.gbNew.Controls.Add(this.txtQualification);
            this.gbNew.Controls.Add(this.txtID);
            this.gbNew.Controls.Add(this.label3);
            this.gbNew.Controls.Add(this.txtTrainer);
            this.gbNew.Controls.Add(this.label2);
            this.gbNew.Controls.Add(this.txtSuburb);
            this.gbNew.Controls.Add(this.label1);
            this.gbNew.Controls.Add(this.btnNewClose);
            this.gbNew.Controls.Add(this.btnNewSave);
            this.gbNew.Controls.Add(this.lblSubTitle);
            this.gbNew.Location = new System.Drawing.Point(155, 0);
            this.gbNew.Name = "gbNew";
            this.gbNew.Size = new System.Drawing.Size(524, 350);
            this.gbNew.TabIndex = 57;
            this.gbNew.TabStop = false;
            this.gbNew.Visible = false;
            // 
            // txtID
            // 
            this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Location = new System.Drawing.Point(228, 75);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(226, 20);
            this.txtID.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(70, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 18);
            this.label3.TabIndex = 81;
            this.label3.Text = "Trainer";
            // 
            // txtTrainer
            // 
            this.txtTrainer.Location = new System.Drawing.Point(228, 129);
            this.txtTrainer.Name = "txtTrainer";
            this.txtTrainer.Size = new System.Drawing.Size(226, 20);
            this.txtTrainer.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(70, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 80;
            this.label2.Text = "Suburb";
            // 
            // txtSuburb
            // 
            this.txtSuburb.Location = new System.Drawing.Point(228, 102);
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(226, 20);
            this.txtSuburb.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(70, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 79;
            this.label1.Text = "ID";
            // 
            // btnNewClose
            // 
            this.btnNewClose.Location = new System.Drawing.Point(278, 286);
            this.btnNewClose.Name = "btnNewClose";
            this.btnNewClose.Size = new System.Drawing.Size(156, 31);
            this.btnNewClose.TabIndex = 77;
            this.btnNewClose.Text = "Close (Esc)";
            this.btnNewClose.UseVisualStyleBackColor = false;
            // 
            // btnNewSave
            // 
            this.btnNewSave.Location = new System.Drawing.Point(90, 286);
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
            this.lblSubTitle.Size = new System.Drawing.Size(518, 26);
            this.lblSubTitle.TabIndex = 78;
            this.lblSubTitle.Text = "New Listing Setup";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(25, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Trainer";
            // 
            // txtTrainerSearch
            // 
            this.txtTrainerSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTrainerSearch.Location = new System.Drawing.Point(102, 62);
            this.txtTrainerSearch.Name = "txtTrainerSearch";
            this.txtTrainerSearch.Size = new System.Drawing.Size(306, 20);
            this.txtTrainerSearch.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(70, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 18);
            this.label4.TabIndex = 86;
            this.label4.Text = "Qualification";
            // 
            // txtQualification
            // 
            this.txtQualification.Location = new System.Drawing.Point(228, 155);
            this.txtQualification.Name = "txtQualification";
            this.txtQualification.Size = new System.Drawing.Size(226, 20);
            this.txtQualification.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(70, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 18);
            this.label6.TabIndex = 88;
            this.label6.Text = "Vechicle Transmission";
            // 
            // txtTransmission
            // 
            this.txtTransmission.Location = new System.Drawing.Point(228, 181);
            this.txtTransmission.Name = "txtTransmission";
            this.txtTransmission.Size = new System.Drawing.Size(226, 20);
            this.txtTransmission.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(70, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 18);
            this.label7.TabIndex = 90;
            this.label7.Text = "Vechicle Model";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(228, 207);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(226, 20);
            this.txtModel.TabIndex = 89;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(70, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 18);
            this.label9.TabIndex = 94;
            this.label9.Text = "Area";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(228, 259);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(226, 20);
            this.txtArea.TabIndex = 93;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(70, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 18);
            this.label10.TabIndex = 92;
            this.label10.Text = "Vechicle Registration No.";
            // 
            // txtRegNo
            // 
            this.txtRegNo.Location = new System.Drawing.Point(228, 233);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Size = new System.Drawing.Size(226, 20);
            this.txtRegNo.TabIndex = 91;
            // 
            // frmListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(814, 596);
            this.Controls.Add(this.gbNew);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimizeBox = false;
            this.Name = "frmListing";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code setup";
            this.Load += new System.EventHandler(this.frmListingLoad);
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
        private System.Windows.Forms.TextBox txtSuburbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.GroupBox gbNew;
        private CustomControl.MyCombobox cbRole;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSuburb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewClose;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTrainerSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTransmission;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQualification;

    }
}

