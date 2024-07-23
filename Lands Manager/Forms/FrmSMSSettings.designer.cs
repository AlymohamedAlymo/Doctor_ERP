namespace DoctorERP
{
    partial class FrmSMSSettings
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
            this.TxtMobile = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblMobile = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblHint = new System.Windows.Forms.Label();
            this.TxtUserName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblUserName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblPassword = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtSender = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblSender = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtMessageBody = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblMsg = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.PnlMain.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.TxtMobile);
            this.PnlMain.Controls.Add(this.LblMobile);
            this.PnlMain.Controls.Add(this.LblHint);
            this.PnlMain.Controls.Add(this.TxtUserName);
            this.PnlMain.Controls.Add(this.LblUserName);
            this.PnlMain.Controls.Add(this.TxtPassword);
            this.PnlMain.Controls.Add(this.LblPassword);
            this.PnlMain.Controls.Add(this.TxtSender);
            this.PnlMain.Controls.Add(this.LblSender);
            this.PnlMain.Controls.Add(this.TxtMessageBody);
            this.PnlMain.Controls.Add(this.LblMsg);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(602, 262);
            this.PnlMain.TabIndex = 0;
            // 
            // TxtMobile
            // 
            this.TxtMobile.Location = new System.Drawing.Point(14, 161);
            this.TxtMobile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtMobile.Name = "TxtMobile";
            this.TxtMobile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtMobile.Size = new System.Drawing.Size(460, 24);
            this.TxtMobile.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMobile.TabIndex = 4;
            // 
            // LblMobile
            // 
            this.LblMobile.Location = new System.Drawing.Point(477, 164);
            this.LblMobile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblMobile.Name = "LblMobile";
            this.LblMobile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblMobile.Size = new System.Drawing.Size(72, 21);
            this.LblMobile.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMobile.TabIndex = 15;
            this.LblMobile.Values.Text = "رقم الجوال";
            // 
            // LblHint
            // 
            this.LblHint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHint.Location = new System.Drawing.Point(14, 202);
            this.LblHint.Name = "LblHint";
            this.LblHint.Size = new System.Drawing.Size(460, 57);
            this.LblHint.TabIndex = 13;
            this.LblHint.Text = "الإشتراك عبر\r\nhttps://www.hisms.ws\r\n";
            this.LblHint.Click += new System.EventHandler(this.LblHint_Click);
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(14, 21);
            this.TxtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtUserName.Size = new System.Drawing.Size(460, 24);
            this.TxtUserName.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUserName.TabIndex = 0;
            // 
            // LblUserName
            // 
            this.LblUserName.Location = new System.Drawing.Point(477, 23);
            this.LblUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblUserName.Size = new System.Drawing.Size(104, 21);
            this.LblUserName.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUserName.TabIndex = 2;
            this.LblUserName.Values.Text = "اسم المستخدم";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(14, 57);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPassword.Size = new System.Drawing.Size(460, 24);
            this.TxtPassword.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.TabIndex = 1;
            // 
            // LblPassword
            // 
            this.LblPassword.Location = new System.Drawing.Point(477, 59);
            this.LblPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblPassword.Size = new System.Drawing.Size(77, 21);
            this.LblPassword.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPassword.TabIndex = 4;
            this.LblPassword.Values.Text = "كلمة المرور";
            // 
            // TxtSender
            // 
            this.TxtSender.Location = new System.Drawing.Point(14, 92);
            this.TxtSender.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtSender.Name = "TxtSender";
            this.TxtSender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtSender.Size = new System.Drawing.Size(460, 24);
            this.TxtSender.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSender.TabIndex = 2;
            // 
            // LblSender
            // 
            this.LblSender.Location = new System.Drawing.Point(477, 95);
            this.LblSender.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblSender.Name = "LblSender";
            this.LblSender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblSender.Size = new System.Drawing.Size(89, 21);
            this.LblSender.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSender.TabIndex = 6;
            this.LblSender.Values.Text = "اسم المرسل";
            // 
            // TxtMessageBody
            // 
            this.TxtMessageBody.Location = new System.Drawing.Point(14, 128);
            this.TxtMessageBody.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtMessageBody.Name = "TxtMessageBody";
            this.TxtMessageBody.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtMessageBody.Size = new System.Drawing.Size(460, 24);
            this.TxtMessageBody.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMessageBody.TabIndex = 3;
            // 
            // LblMsg
            // 
            this.LblMsg.Location = new System.Drawing.Point(477, 130);
            this.LblMsg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblMsg.Name = "LblMsg";
            this.LblMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblMsg.Size = new System.Drawing.Size(79, 21);
            this.LblMsg.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMsg.TabIndex = 8;
            this.LblMsg.Values.Text = "نص الرسالة";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(14, 10);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(79, 31);
            this.BtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Values.Text = "خروج";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(394, 10);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(79, 31);
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
            this.PnlBottom.Location = new System.Drawing.Point(0, 262);
            this.PnlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(602, 52);
            this.PnlBottom.TabIndex = 1;
            // 
            // FrmSMSSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 314);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSMSSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات الرسائل";
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
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSender;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSender;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtMessageBody;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblMsg;
        private System.Windows.Forms.Label LblHint;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtMobile;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblMobile;
    }
}