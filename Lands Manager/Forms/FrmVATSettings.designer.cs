namespace DoctorERP
{
    partial class FrmVATSettings
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
            this.PnlMain = new System.Windows.Forms.Panel();
            this.TxtVATID = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblMobile = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtCompanyName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.PnlMain.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.TxtCompanyName);
            this.PnlMain.Controls.Add(this.kryptonLabel1);
            this.PnlMain.Controls.Add(this.TxtVATID);
            this.PnlMain.Controls.Add(this.LblMobile);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(366, 73);
            this.PnlMain.TabIndex = 0;
            // 
            // TxtVATID
            // 
            this.TxtVATID.Location = new System.Drawing.Point(12, 39);
            this.TxtVATID.Name = "TxtVATID";
            this.TxtVATID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtVATID.Size = new System.Drawing.Size(247, 21);
            this.TxtVATID.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVATID.TabIndex = 1;
            // 
            // LblMobile
            // 
            this.LblMobile.Location = new System.Drawing.Point(265, 41);
            this.LblMobile.Name = "LblMobile";
            this.LblMobile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblMobile.Size = new System.Drawing.Size(75, 17);
            this.LblMobile.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMobile.TabIndex = 15;
            this.LblMobile.Values.Text = "الرقم الضريبي";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 8);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(68, 25);
            this.BtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Values.Text = "خروج";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(191, 8);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(68, 25);
            this.BtnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Values.Text = "حفظ";
            this.BtnSave.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnSave);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 73);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(366, 42);
            this.PnlBottom.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(265, 14);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel1.Size = new System.Drawing.Size(70, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 15;
            this.kryptonLabel1.Values.Text = "اسم الشركة";
            // 
            // TxtCompanyName
            // 
            this.TxtCompanyName.Location = new System.Drawing.Point(12, 12);
            this.TxtCompanyName.Name = "TxtCompanyName";
            this.TxtCompanyName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCompanyName.Size = new System.Drawing.Size(247, 21);
            this.TxtCompanyName.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCompanyName.TabIndex = 0;
            // 
            // FrmVATSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 115);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVATSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات الرقم الضريبي";
            this.Load += new System.EventHandler(this.FrmTable_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSave;
        private System.Windows.Forms.Panel PnlBottom;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtVATID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblMobile;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtCompanyName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}