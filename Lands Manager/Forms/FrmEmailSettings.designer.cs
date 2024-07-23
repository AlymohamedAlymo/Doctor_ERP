namespace DoctorERP
{
    partial class FrmEmailSettings
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
            this.tbSettings = new System.Windows.Forms.TabControl();
            this.EmailSettings = new System.Windows.Forms.TabPage();
            this.TxtSenderName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblSenderName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtSenderEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblSenderEmail = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.udPort = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.LblSMTPServer = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ChkUseSSL = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.TxtSMTPServer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblPort = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblPassword = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.MessageSettings = new System.Windows.Forms.TabPage();
            this.TxtCCEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtSubject = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtMessageBody = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblCCEmail = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblSubject = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblMessageBody = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tbSettings.SuspendLayout();
            this.EmailSettings.SuspendLayout();
            this.MessageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSettings
            // 
            this.tbSettings.Controls.Add(this.EmailSettings);
            this.tbSettings.Controls.Add(this.MessageSettings);
            this.tbSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSettings.Location = new System.Drawing.Point(0, 0);
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.RightToLeftLayout = true;
            this.tbSettings.SelectedIndex = 0;
            this.tbSettings.Size = new System.Drawing.Size(299, 188);
            this.tbSettings.TabIndex = 1;
            // 
            // EmailSettings
            // 
            this.EmailSettings.Controls.Add(this.TxtSenderName);
            this.EmailSettings.Controls.Add(this.LblSenderName);
            this.EmailSettings.Controls.Add(this.TxtSenderEmail);
            this.EmailSettings.Controls.Add(this.LblSenderEmail);
            this.EmailSettings.Controls.Add(this.udPort);
            this.EmailSettings.Controls.Add(this.LblSMTPServer);
            this.EmailSettings.Controls.Add(this.ChkUseSSL);
            this.EmailSettings.Controls.Add(this.TxtSMTPServer);
            this.EmailSettings.Controls.Add(this.TxtPassword);
            this.EmailSettings.Controls.Add(this.LblPort);
            this.EmailSettings.Controls.Add(this.LblPassword);
            this.EmailSettings.Location = new System.Drawing.Point(4, 22);
            this.EmailSettings.Name = "EmailSettings";
            this.EmailSettings.Padding = new System.Windows.Forms.Padding(3);
            this.EmailSettings.Size = new System.Drawing.Size(291, 162);
            this.EmailSettings.TabIndex = 0;
            this.EmailSettings.Text = "البريد الإلكتروني للإرسال";
            this.EmailSettings.UseVisualStyleBackColor = true;
            // 
            // TxtSenderName
            // 
            this.TxtSenderName.Location = new System.Drawing.Point(6, 14);
            this.TxtSenderName.Name = "TxtSenderName";
            this.TxtSenderName.Size = new System.Drawing.Size(168, 21);
            this.TxtSenderName.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSenderName.TabIndex = 0;
            // 
            // LblSenderName
            // 
            this.LblSenderName.Location = new System.Drawing.Point(180, 16);
            this.LblSenderName.Name = "LblSenderName";
            this.LblSenderName.Size = new System.Drawing.Size(72, 17);
            this.LblSenderName.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSenderName.TabIndex = 18;
            this.LblSenderName.Values.Text = "اسم المرسل";
            // 
            // TxtSenderEmail
            // 
            this.TxtSenderEmail.Location = new System.Drawing.Point(6, 38);
            this.TxtSenderEmail.Name = "TxtSenderEmail";
            this.TxtSenderEmail.Size = new System.Drawing.Size(168, 21);
            this.TxtSenderEmail.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSenderEmail.TabIndex = 1;
            // 
            // LblSenderEmail
            // 
            this.LblSenderEmail.Location = new System.Drawing.Point(180, 40);
            this.LblSenderEmail.Name = "LblSenderEmail";
            this.LblSenderEmail.Size = new System.Drawing.Size(86, 17);
            this.LblSenderEmail.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSenderEmail.TabIndex = 18;
            this.LblSenderEmail.Values.Text = "بريدك الإلكتروني";
            // 
            // udPort
            // 
            this.udPort.Location = new System.Drawing.Point(88, 110);
            this.udPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.udPort.Name = "udPort";
            this.udPort.Size = new System.Drawing.Size(86, 20);
            this.udPort.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udPort.TabIndex = 4;
            // 
            // LblSMTPServer
            // 
            this.LblSMTPServer.Location = new System.Drawing.Point(180, 88);
            this.LblSMTPServer.Name = "LblSMTPServer";
            this.LblSMTPServer.Size = new System.Drawing.Size(64, 17);
            this.LblSMTPServer.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSMTPServer.TabIndex = 18;
            this.LblSMTPServer.Values.Text = "مخدم البريد";
            // 
            // ChkUseSSL
            // 
            this.ChkUseSSL.Location = new System.Drawing.Point(88, 136);
            this.ChkUseSSL.Name = "ChkUseSSL";
            this.ChkUseSSL.Size = new System.Drawing.Size(86, 17);
            this.ChkUseSSL.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkUseSSL.TabIndex = 5;
            this.ChkUseSSL.Values.Text = "إستخدام SSL";
            // 
            // TxtSMTPServer
            // 
            this.TxtSMTPServer.Location = new System.Drawing.Point(6, 86);
            this.TxtSMTPServer.Name = "TxtSMTPServer";
            this.TxtSMTPServer.Size = new System.Drawing.Size(168, 21);
            this.TxtSMTPServer.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSMTPServer.TabIndex = 3;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(6, 62);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '●';
            this.TxtPassword.Size = new System.Drawing.Size(168, 21);
            this.TxtPassword.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // LblPort
            // 
            this.LblPort.Location = new System.Drawing.Point(180, 112);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(59, 17);
            this.LblPort.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPort.TabIndex = 18;
            this.LblPort.Values.Text = "رقم المنفذ";
            // 
            // LblPassword
            // 
            this.LblPassword.Location = new System.Drawing.Point(180, 64);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(63, 17);
            this.LblPassword.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPassword.TabIndex = 18;
            this.LblPassword.Values.Text = "كلمة المرور";
            // 
            // MessageSettings
            // 
            this.MessageSettings.Controls.Add(this.TxtCCEmail);
            this.MessageSettings.Controls.Add(this.TxtSubject);
            this.MessageSettings.Controls.Add(this.TxtMessageBody);
            this.MessageSettings.Controls.Add(this.LblCCEmail);
            this.MessageSettings.Controls.Add(this.LblSubject);
            this.MessageSettings.Controls.Add(this.LblMessageBody);
            this.MessageSettings.Location = new System.Drawing.Point(4, 22);
            this.MessageSettings.Name = "MessageSettings";
            this.MessageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.MessageSettings.Size = new System.Drawing.Size(291, 162);
            this.MessageSettings.TabIndex = 1;
            this.MessageSettings.Text = "الرسالة المرسلة";
            this.MessageSettings.UseVisualStyleBackColor = true;
            // 
            // TxtCCEmail
            // 
            this.TxtCCEmail.Location = new System.Drawing.Point(6, 12);
            this.TxtCCEmail.Name = "TxtCCEmail";
            this.TxtCCEmail.Size = new System.Drawing.Size(168, 21);
            this.TxtCCEmail.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCCEmail.TabIndex = 0;
            // 
            // TxtSubject
            // 
            this.TxtSubject.Location = new System.Drawing.Point(6, 36);
            this.TxtSubject.Name = "TxtSubject";
            this.TxtSubject.Size = new System.Drawing.Size(168, 21);
            this.TxtSubject.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubject.TabIndex = 1;
            // 
            // TxtMessageBody
            // 
            this.TxtMessageBody.Location = new System.Drawing.Point(6, 60);
            this.TxtMessageBody.Multiline = true;
            this.TxtMessageBody.Name = "TxtMessageBody";
            this.TxtMessageBody.Size = new System.Drawing.Size(168, 96);
            this.TxtMessageBody.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMessageBody.TabIndex = 2;
            // 
            // LblCCEmail
            // 
            this.LblCCEmail.Location = new System.Drawing.Point(180, 14);
            this.LblCCEmail.Name = "LblCCEmail";
            this.LblCCEmail.Size = new System.Drawing.Size(92, 17);
            this.LblCCEmail.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCCEmail.TabIndex = 18;
            this.LblCCEmail.Values.Text = "الإيميل المستقبل";
            // 
            // LblSubject
            // 
            this.LblSubject.Location = new System.Drawing.Point(180, 38);
            this.LblSubject.Name = "LblSubject";
            this.LblSubject.Size = new System.Drawing.Size(74, 17);
            this.LblSubject.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubject.TabIndex = 18;
            this.LblSubject.Values.Text = "عنوان الرسالة";
            // 
            // LblMessageBody
            // 
            this.LblMessageBody.Location = new System.Drawing.Point(180, 60);
            this.LblMessageBody.Name = "LblMessageBody";
            this.LblMessageBody.Size = new System.Drawing.Size(65, 17);
            this.LblMessageBody.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMessageBody.TabIndex = 18;
            this.LblMessageBody.Values.Text = "نص الرسالة";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(184, 194);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(83, 25);
            this.BtnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Values.Text = "حفظ";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FrmEmailSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 227);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.tbSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEmailSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات البريد الإلكتروني";
            this.Load += new System.EventHandler(this.FrmEmailSettings_Load);
            this.tbSettings.ResumeLayout(false);
            this.EmailSettings.ResumeLayout(false);
            this.EmailSettings.PerformLayout();
            this.MessageSettings.ResumeLayout(false);
            this.MessageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbSettings;
        private System.Windows.Forms.TabPage EmailSettings;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSenderName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSenderName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSenderEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSenderEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown udPort;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSMTPServer;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox ChkUseSSL;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSMTPServer;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblPort;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblPassword;
        private System.Windows.Forms.TabPage MessageSettings;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSubject;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtMessageBody;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSubject;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblMessageBody;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtCCEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblCCEmail;
    }
}