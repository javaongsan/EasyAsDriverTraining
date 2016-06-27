namespace  EasyAsDriverTraining

{
    sealed partial class FrmInit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInit));
            this.blbMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // blbMsg
            // 
            this.blbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blbMsg.Location = new System.Drawing.Point(0, 0);
            this.blbMsg.Name = "blbMsg";
            this.blbMsg.Size = new System.Drawing.Size(476, 156);
            this.blbMsg.TabIndex = 0;
            this.blbMsg.Text = "Initialising! Please wait...";
            this.blbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(476, 156);
            this.ControlBox = false;
            this.Controls.Add(this.blbMsg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyAs Driver Training Australia";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label blbMsg;
    }
}