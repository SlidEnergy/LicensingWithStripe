namespace LicensingWithStripe.License
{
    partial class LicenseInfoForm
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
            this.uxActivate = new DevExpress.XtraEditors.SimpleButton();
            this.uxDeactivate = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.uxLicenseInfo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.uxLicenseInfo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // uxActivate
            // 
            this.uxActivate.Location = new System.Drawing.Point(572, 32);
            this.uxActivate.Name = "uxActivate";
            this.uxActivate.Size = new System.Drawing.Size(102, 32);
            this.uxActivate.TabIndex = 0;
            this.uxActivate.Text = "ActivateLicense";
            this.uxActivate.Click += new System.EventHandler(this.uxActivate_Click);
            // 
            // uxDeactivate
            // 
            this.uxDeactivate.Location = new System.Drawing.Point(572, 70);
            this.uxDeactivate.Name = "uxDeactivate";
            this.uxDeactivate.Size = new System.Drawing.Size(102, 32);
            this.uxDeactivate.TabIndex = 1;
            this.uxDeactivate.Text = "Deactivate";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "License";
            // 
            // uxLicenseInfo
            // 
            this.uxLicenseInfo.Location = new System.Drawing.Point(12, 31);
            this.uxLicenseInfo.Name = "uxLicenseInfo";
            this.uxLicenseInfo.Properties.ReadOnly = true;
            this.uxLicenseInfo.Size = new System.Drawing.Size(554, 347);
            this.uxLicenseInfo.TabIndex = 3;
            // 
            // LicenseInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.uxLicenseInfo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.uxDeactivate);
            this.Controls.Add(this.uxActivate);
            this.Name = "LicenseInfoForm";
            this.Text = "License info";
            ((System.ComponentModel.ISupportInitialize)(this.uxLicenseInfo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton uxActivate;
        private DevExpress.XtraEditors.SimpleButton uxDeactivate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit uxLicenseInfo;
    }
}